#include <iostream>
#include <string>
#include <fstream>
using namespace std;

namespace Logger {
    enum LogLevel { INFO, WARNING, ERROR };

    string getLevelPrefix(LogLevel level) {
        switch (level) {
        case INFO: return "[INFO] ";
        case WARNING: return "[WARNING] ";
        case ERROR: return "[ERROR] ";
        default: return "[UNKNOWN] ";
        }
    }

    void log(LogLevel level, const string& message) {
        cout << getLevelPrefix(level) << message << endl;
    }

    namespace FileLogger {
        void logToFile(const string& filename, const string& message) {
            ofstream file(filename, ios::app);
            if (file.is_open()) {
                file << message << endl;
                file.close();
                cout << "Сообщение записано в файл: " << filename << endl;
            }
            else {
                cerr << "Ошибка открытия файла!" << endl;
            }
        }
    }
}

int main() {
    setlocale(LC_ALL, "ru");

    cout << "=== ТЕСТ: Полная квалификация ===" << endl;
    Logger::log(Logger::INFO, "Информационное сообщение");
    Logger::log(Logger::WARNING, "Предупреждение");
    Logger::log(Logger::ERROR, "Ошибка!");

    cout << "\n=== ТЕСТ: Using directive внутри функции ===" << endl;
    {
        using namespace Logger;
        log(INFO, "Краткая запись через using namespace");
        log(WARNING, "Еще одно сообщение");

        FileLogger::logToFile("log.txt", "Сообщение в файл");
    }

    cout << "\n=== ТЕСТ: Смешанное использование ===" << endl;
    using Logger::LogLevel;
    using Logger::log;

    log(LogLevel::INFO, "Смешанный стиль");

    return 0;
}