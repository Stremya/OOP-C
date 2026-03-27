#include <iostream>
#include "Circle.h"
using namespace std;

int main() {
    setlocale(LC_ALL, "ru");

    cout << "=== ТЕСТ Создание кругов ===" << endl;
    Circle c1(5.0);
    Circle c2(3.0);
    Circle c3(5.0);

    cout << "c1: " << c1 << endl;
    cout << "c2: " << c2 << endl;
    cout << "c3: " << c3 << endl;

    cout << "\n=== ТЕСТ Оператор == ===" << endl;
    cout << "c1 == c2: " << (c1 == c2 ? "true" : "false") << endl;  
    cout << "c1 == c3: " << (c1 == c3 ? "true" : "false") << endl;  

    cout << "\n=== ТЕСТ Оператор > ===" << endl;
    cout << "c1 > c2: " << (c1 > c2 ? "true" : "false") << endl;    
    cout << "c2 > c1: " << (c2 > c1 ? "true" : "false") << endl;    
    cout << "c1 > c3: " << (c1 > c3 ? "true" : "false") << endl;    

    cout << "\n=== ТЕСТ Оператор += ===" << endl;
    cout << "c2 до: " << c2 << endl;
    c2 += 2.0;
    cout << "c2 += 2.0: " << c2 << endl;

    cout << "\n=== ТЕСТ Оператор -= ===" << endl;
    cout << "c1 до: " << c1 << endl;
    c1 -= 1.0;
    cout << "c1 -= 1.0: " << c1 << endl;

    return 0;
}