
#ifndef __LOGGER_HPP

#define __LOGGER_HPP

#include <fstream>
#include <string>
#include <cstdarg>

namespace ddohook {

    class logger {
    private:

        std::wfstream stream_;
        
        static logger inst_;

    public:

        inline static logger & inst (void) {
            return inst_;
        }   

        logger (void);
        virtual ~logger (void);

        void open (void);
        void close (void);

        void message (const wchar_t *prefix, const wchar_t *fmt, va_list lst);
        void error (const wchar_t *msg, ...);
        void info (const wchar_t *msg, ...);
        void warning (const wchar_t *msg, ...);
    };

};

#endif
