
#include <include/ddohook.hpp>
#include <include/logger.hpp>
#include <include/pipe_client.hpp>
#include <easyhook/EasyHook.h>
#include <Windows.h>

/**
 * DDO does something like this:
 *
 * 1: wcsncpy(channel, L"Standard", 8);
 * 2: wcscnpy(delim, L"): ", 3);
 * 3: wcscnpy(message, L"<msg>", 8);
 * ...
 * 4: wcsncpy(combinedbuffer, L"<channel>0x01<delim>0x01<message>", 8);
 *
 * With => <msg> = Actual chat message.
 *         <channel> = Content of the previous wcsncpy, containing the channel.
 *         <delim> = The delimiter between <channel> and <message>, literal L"): "
 *         <message> = Actual message.
 *
 * The old method used the string at 4 which was potentially unsafe and not a good
 * way of doing it. Since the wcsncpy() hook was written in C# then, any other method
 * would have slowed the game down too much. Now that we are in C, a safer method can
 * be used that parses strings 1-3. The message is always received n * 2 times, where n
 * is the number of chat windows that display the message. Only the case were n = 1 is
 * handled, for n > 1 the message duplicates are processed as well.
 */

struct accepted_header {
    // Channel name, in the native tongue
    const wchar_t *header;
    // Length of  ^^^^^^^
    size_t length;
};

ddohook::pipe_client client_;

// List of accepted headers.
accepted_header headers[] =  { {L"Combat", 6},
                               {L"Standard", 8},
                               {L"Say", 3}
                             };

const int header_count = sizeof(headers)/sizeof(accepted_header);

extern "C" {
    enum message_status {
        invalid,
        had_header,
        had_delimiter,
        had_message = invalid,
        duplicate = invalid
    };

    wchar_t * __cdecl wcsncpy_hooked (wchar_t *s1, const wchar_t *s2, size_t s) {
        static wchar_t *type = NULL;
        static message_status status;

        static wchar_t *last_type = NULL;
        static wchar_t *last_msg = NULL;

        if (s>=3) {
            if (status == invalid) {
                for (int i = 0; i < header_count; i++) {
                    if (wcsncmp(s2, headers[i].header, headers[i].length) == 0) {
                        if (type != NULL) {
                            free(type);
                            type = NULL;
                        }
                        type = _wcsdup(s2); 
                        status = had_header;
                        break;
                    }
                }
            } else if (status == had_header) {
                status = (wcsncmp(s2, L"): ", 3) == 0) ? had_delimiter : invalid;
                if (status == invalid && type) {
                    free(type);
                    type = NULL;
                }
            } else if (status == had_delimiter) {
                if ((last_type && wcscmp(type, last_type) == 0) &&
                    (last_msg && wcscmp(s2, last_msg) == 0)) { // duplicate
                    // Mark as invalid as it is a duplicate.
                    status = duplicate; 
                    free(type);
                    type = NULL;

                    free(last_type);
                    last_type = NULL;

                    free(last_msg);
                    last_msg = NULL;
                } else {
                    client_.message(type, s2);

                    last_type = _wcsdup(type);
                    last_msg = _wcsdup(s2);

                    free(type);
                    type = NULL;

                    status = had_message; // Done
               }                
            }
        }
        return wcsncpy(s1, s2, s);
    }

    DDOHOOK_EXPORT void __stdcall NativeInjectionEntryPoint(unsigned int unused) {
        HOOK_TRACE_INFO wcsncpy_hook = {0};
        HMODULE msvcr = NULL;
        wchar_t pipename[100] = {0};
        DWORD pid = GetCurrentProcessId();

        try {
            ddohook::logger::inst().open();
            ddohook::logger &log = ddohook::logger::inst();

            _snwprintf(pipename, 99, L"ddohook%d", pid);
            pipename[99] = L'\0';

            log.info(L"Got hooked onto %d.", pid);
            log.info(L"Got the following pipe name: %s.", pipename);

            msvcr = GetModuleHandle(L"MSVCR80.DLL");

            if (msvcr == NULL) {
                log.error(L"Could not load MSVCR80.DLL.");
            }

            NTSTATUS ret = LhInstallHook(GetProcAddress(msvcr, "wcsncpy"),
                                        wcsncpy_hooked,
                                        NULL,
                                        &wcsncpy_hook
                                        );

            if (!NT_SUCCESS(ret)) {
                log.error(L"Failed to install wcsncpy hook: %s", RtlGetLastErrorString());
                return;
            }
            log.info(L"Successfully installed wcsncpy hook.");

            unsigned long threads[] = {0};

            ret = LhSetExclusiveACL(threads, 1, &wcsncpy_hook);

            if (!NT_SUCCESS(ret)) {
                log.error(L"Failed to set exclusive thread ACL for wcsncpy hook: %s", RtlGetLastErrorString());
                return;
            }

            log.info(L"Successfully set exclusive thread ACL.");
        
            client_.open(pipename);
            log.info(L"Successfully set up the pipe.");
        } catch (const std::exception &) {            
        }
    }
}