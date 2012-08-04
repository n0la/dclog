
#include <include/logger.hpp>
#include <fstream>
#include <cstdio>
#include <cstring>
#include <stdexcept>
#include <cwchar>

using namespace ddohook;

logger logger::inst_;

logger::logger (void) {
}

logger::~logger (void) {
}

void logger::open (void) {
#ifndef _DEBUG
    return;
#endif

    stream_.open("d:\\ddohook.log.txt", std::ios::app | std::ios::out);

    if (!stream_.good()) {
        // **TODO** Error.
        throw std::runtime_error("Could not open log file.");
    }
}

void logger::close (void) {
#ifndef _DEBUG
    return;
#endif

    stream_.flush();
}

void logger::message (const wchar_t *prefix, const wchar_t *msg, va_list lst) {
#ifndef _DEBUG
    return;
#endif

    wchar_t buff[4086] = {0};
    wchar_t everything[9000] = {0};

    _vsnwprintf(buff, sizeof(buff)-2, msg, lst);
    _snwprintf(everything, sizeof(everything)-2, L"%s: %s", prefix, buff);

    stream_ << everything << std::endl;
    stream_.flush();
}

void logger::info (const wchar_t *msg, ...) {
#ifndef _DEBUG
    return;
#endif

    va_list lst;

    va_start(lst, msg);
    message(L"INFO", msg, lst);
    va_end(lst);
}

void logger::error (const wchar_t *msg, ...) {
#ifndef _DEBUG
    return;
#endif

    va_list lst;

    va_start(lst, msg);
    message(L"ERROR", msg, lst);
    va_end(lst);
}

void logger::warning (const wchar_t *msg, ...) {
#ifndef _DEBUG
    return;
#endif

    va_list lst;

    va_start(lst, msg);
    message(L"WARNING", msg, lst);
    va_end(lst);
}
