#include <iostream>
#include <stdexcept>
#include <string>
using namespace std;

class BankAccount {
private:
    string owner;
    double balance;

public:
    BankAccount(const string& owner, double initialBalance)
        : owner(owner), balance(initialBalance) {
        if (initialBalance < 0) {
            throw invalid_argument("Начальный баланс не может быть отрицательным!");
        }
    }

    void withdraw(double amount) {
        if (amount < 0) {
            throw invalid_argument("Сумма снятия не может быть отрицательной!");
        }
        if (amount > balance) {
            throw runtime_error("Недостаточно средств на счете!");
        }
        balance -= amount;
    }

    double getBalance() const { return balance; }
    string getOwner() const { return owner; }
};

int main() {
    setlocale(LC_ALL, "ru");

    try {
        cout << "=== ТЕСТ: Создание счета ===" << endl;
        BankAccount account1("Иванов", 1000);
        cout << "Счет создан: " << account1.getOwner()
            << ", баланс: " << account1.getBalance() << endl;

        cout << "\n=== ТЕСТ: Отрицательный баланс ===" << endl;
        BankAccount account2("Петров", -100);  
    }
    catch (const invalid_argument& e) {
        cout << "invalid_argument: " << e.what() << endl;
    }

    try {
        cout << "\n=== ТЕСТ: Снятие средств ===" << endl;
        BankAccount account3("Сидоров", 500);
        account3.withdraw(200);
        cout << "После снятия: " << account3.getBalance() << endl;

        cout << "\n=== ТЕСТ: Недостаточно средств ===" << endl;
        account3.withdraw(1000);  
    }
    catch (const runtime_error& e) {
        cout << "runtime_error: " << e.what() << endl;
    }
    catch (const invalid_argument& e) {
        cout << "invalid_argument: " << e.what() << endl;
    }

    try {
        cout << "\n=== ТЕСТ: Отрицательная сумма снятия ===" << endl;
        BankAccount account4("Козлов", 1000);
        account4.withdraw(-50);  
    }
    catch (const invalid_argument& e) {
        cout << "invalid_argument: " << e.what() << endl;
    }

    return 0;
}