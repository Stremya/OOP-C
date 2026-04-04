#include <iostream>
#include <thread>
#include <chrono>
#include <functional>
#include <stdexcept>
using namespace std;

class ThreadGuard {
private:
    thread t;

public:
    template<typename Callable, typename... Args>
    explicit ThreadGuard(Callable&& func, Args&&... args)
        : t(forward<Callable>(func), forward<Args>(args)...) {
        cout << "Поток запущен" << endl;
    }

    ~ThreadGuard() {
        if (t.joinable()) {
            cout << "Автоматическое завершение потока..." << endl;
            t.join();
            cout << "Поток завершен" << endl;
        }
    }

    ThreadGuard(const ThreadGuard&) = delete;
    ThreadGuard& operator=(const ThreadGuard&) = delete;

    ThreadGuard(ThreadGuard&& other) noexcept
        : t(move(other.t)) {
    }

    ThreadGuard& operator=(ThreadGuard&& other) noexcept {
        if (this != &other) {
            if (t.joinable()) {
                t.join();
            }
            t = move(other.t);
        }
        return *this;
    }
};

// Функция для теста
void simpleFunction() {
    cout << "Простая функция выполняется..." << endl;
    this_thread::sleep_for(chrono::seconds(2));
    cout << "Простая функция завершена" << endl;
}

int main() {
    setlocale(LC_ALL, "ru");

    cout << "=== ТЕСТ: Простая функция ===" << endl;
    {
        ThreadGuard guard1(simpleFunction);
        cout << "Основной поток продолжает работу..." << endl;
    } 

    cout << "\n=== ТЕСТ: Лямбда с задержкой ===" << endl;
    {
        ThreadGuard guard2([]() {
            cout << "Лямбда началась" << endl;
            for (int i = 1; i <= 5; i++) {
                cout << "  Итерация " << i << endl;
                this_thread::sleep_for(chrono::milliseconds(500));
            }
            cout << "Лямбда завершена" << endl;
            });
        cout << "Ждем завершения лямбды..." << endl;
    }

    cout << "\n=== ТЕСТ: Функция с аргументами ===" << endl;
    {
        ThreadGuard guard3([](int a, int b) {
            cout << "Сумма: " << a << " + " << b
                << " = " << (a + b) << endl;
            this_thread::sleep_for(chrono::seconds(1));
            }, 10, 20);
    }

    cout << "\n=== ТЕСТ: Перемещение ThreadGuard ===" << endl;
    {
        ThreadGuard guard4([]() {
            cout << "Поток для перемещения" << endl;
            this_thread::sleep_for(chrono::seconds(1));
            });

        ThreadGuard guard5 = move(guard4);
    }

    cout << "\nПрограмма завершена!" << endl;
    return 0;
}