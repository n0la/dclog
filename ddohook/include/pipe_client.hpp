
#ifndef __PIPE_CLIENT_HPP

#define __PIPE_CLIENT_HPP

#include <string>
#include <Windows.h>
#include <queue>

namespace ddohook {

    class pipe_client {
    private:

        HANDLE handle_;
        HANDLE thread_;
        bool running_;

        std::wstring pipename_;
        std::queue<std::wstring> queue_;
        static LPVOID write_handler (void *data);

        void open_pipe (void);
        void run_thread (void);
        void reconnect (void);
    
    public:

        pipe_client (void);
        virtual ~pipe_client (void);

        void open (const std::wstring &name);
        void close (void);

        void message (const std::wstring &type, const std::wstring &message);
        void message (const std::wstring &fullmessage);
    
    };

};

#endif
