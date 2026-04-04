#include <iostream>
#include <exception>
#include <string>
using namespace std;

// Собственное исключение
class DivisionByZeroException : public exception {
private:
    string message;
public:
    DivisionByZeroException(const string& msg = "Деление на ноль!")
        : message(msg) {
    }

    const char* what() const noexcept override {
        return message.c_str();
    }
};

class SafeDivision {
public:
    static double divide(double a, double b) {
        if (b == 0) {
            throw DivisionByZeroException("Попытка деления на ноль!");
        }
        return a / b;
    }
};

int main() {
    setlocale(LC_ALL, "ru");

    double values[] = { 10.0, 5.0, 0.0, 2.0 };

    for (int i = 0; i < 4; i++) {
        for (int j = 0; j < 4; j++) {
            try {
                double result = SafeDivision::divide(values[i], values[j]);
                cout << values[i] << " / " << values[j]
                    << " = " << result << endl;
            }
            catch (const DivisionByZeroException& e) {
                cout << "Ошибка: " << e.what() << endl;
            }
        }
        cout << endl;
    }

    return 0;
}