#include <iostream>
#include <thread> 
#include <memory>
#include <chrono>
#include <string>
using namespace std;

class Timer {
private:
    chrono::steady_clock::time_point startTime;
    string name;

public:
    Timer(const string& timerName = "Timer")
        : name(timerName), startTime(chrono::steady_clock::now()) {
        cout << name << " создан" << endl;
    }

    ~Timer() {
        auto endTime = chrono::steady_clock::now();
        auto duration = chrono::duration_cast<chrono::milliseconds>(
            endTime - startTime
        ).count();

        cout << name << " уничтожен" << endl;
        cout << "Прошло времени: " << duration << " мс" << endl;
    }
};

unique_ptr<Timer> createTimer(const string& name = "Timer") {
    return make_unique<Timer>(name);
}

void demonstrateTimer() {
    cout << "\n=== Демонстрация Timer ===" << endl;
    auto timer = createTimer("Функция demonstrateTimer");

    this_thread::sleep_for(chrono::milliseconds(100));
    cout << "Выполнение работы..." << endl;

} 

int main() {
    setlocale(LC_ALL, "ru");

    cout << "=== ТЕСТ: Базовое использование ===" << endl;
    {
        unique_ptr<Timer> timer1 = createTimer("Timer 1");
        this_thread::sleep_for(chrono::milliseconds(50));
    } 

    cout << "\n=== ТЕСТ: Функция с timer ===" << endl;
    demonstrateTimer();

    cout << "\n=== ТЕСТ: Перемещение unique_ptr ===" << endl;
    {
        unique_ptr<Timer> timer2 = createTimer("Timer 2");
        unique_ptr<Timer> timer3 = move(timer2);

        if (!timer2) {
            cout << "timer2 теперь пустой" << endl;
        }
        if (timer3) {
            cout << "timer3 владеет объектом" << endl;
        }

        this_thread::sleep_for(chrono::milliseconds(75));
    } 

    cout << "\n=== ТЕСТ: Массив timers ===" << endl;
    {
        unique_ptr<Timer> timers[3];
        for (int i = 0; i < 3; i++) {
            timers[i] = createTimer("Timer " + to_string(i));
        }
        this_thread::sleep_for(chrono::milliseconds(30));
    } 

    cout << "\nПрограмма завершена!" << endl;
    return 0;
}