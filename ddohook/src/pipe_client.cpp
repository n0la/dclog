
#include <include/pipe_client.hpp>
#include <include/logger.hpp>
#include <stdexcept>
#include <sstream>

using namespace ddohook;

pipe_client::pipe_client (void)
  : handle_(NULL), running_(false) {
}

pipe_client::~pipe_client (void) {
}

void pipe_client::open_pipe (void) {
    std::wstring name = L"\\\\.\\pipe\\" + pipename_;
    
    WaitNamedPipe(name.c_str(), NMPWAIT_WAIT_FOREVER);
    
    handle_ = CreateFile(name.c_str(), GENERIC_WRITE, 0, NULL, OPEN_EXISTING, 0, NULL);

    if (handle_ == INVALID_HANDLE_VALUE) {
        throw std::runtime_error("Failed to connect to the named pipe server.");
    }
}

void pipe_client::run_thread(void) {
    running_ = true;

    thread_ = CreateThread(NULL, 0, 
                           (LPTHREAD_START_ROUTINE)&pipe_client::write_handler, 
                           (void*)this, 0, NULL
                          );
    if (thread_ == NULL) {
        CloseHandle(handle_);
        handle_ = NULL;
        throw std::runtime_error("Unable to start worker thread.");
    }
}

void pipe_client::open (const std::wstring &n) {
    if (handle_) {
        throw std::runtime_error("pipe_client is already connected.");
    }

    pipename_ = n;

    open_pipe();
    run_thread();
}

void pipe_client::reconnect (void) {
    while (true) {
        try {
            open_pipe();
            Sleep(1000*1);
        } catch (const std::exception &) {
        }
    }
}

void pipe_client::close (void) {
    // **TODO**
}

void *pipe_client::write_handler (void *arg) {

    pipe_client *me = (pipe_client*)arg;
    ddohook::logger &log = ddohook::logger::inst();
                    

    while (me->running_) {

        Sleep(100);

        while (me->queue_.size()) {
            std::wstring p = me->queue_.front();
            DWORD written = 0;

            log.info(L"Sending: %s", p.c_str());

            if (!WriteFile(me->handle_, (LPCVOID)p.c_str(), p.size()*sizeof(wchar_t), &written, NULL)) {
                DWORD error = GetLastError();
                if (error == ERROR_BROKEN_PIPE || error == ERROR_NO_DATA) {
                    log.warning(L"Server has gone away, trying a reconnect...");
                    try {
                        CloseHandle(me->handle_);
                        me->handle_ = NULL;
                        me->reconnect();
                        log.info(L"Successfully reconnected...");
                    } catch (const std::exception &) {
                        log.warning(L"Reconnect failed. Bye bye.");
                        return NULL;
                    }
                } else {
                    log.error(L"Failed to send information over pipe: %d.", error);
                }
            } else {
                me->queue_.pop();
                log.info(L"Sending complete: %d bytes written from %d.", written, p.size()*sizeof(wchar_t));
            }
        }
    }

    return NULL;
}

void pipe_client::message (const std::wstring &type, const std::wstring &msg) {
    std::wstringstream str;

    str << "(" << type << "): " << msg;
    message(str.str());
}

void pipe_client::message (const std::wstring &s) {
    std::wstringstream str;

    str << "MSG:" << s << "\r\n";
    queue_.push(str.str());
}
