#include <iostream>
#include "Complex.h"
using namespace std;

int main() {
    setlocale(LC_ALL, "ru");

    Complex c1;                    
    Complex c2(3.0, 4.0);         
    Complex c3(5.0);              
    Complex c4 = c2;             

    cout << "\nc1: " << c1 << endl;
    cout << "c2: " << c2 << endl;
    cout << "c3: " << c3 << endl;
    cout << "c4: " << c4 << endl;

    Complex c5;
    cout << "Введите комплексное число:" << endl;
    cin >> c5;
    cout << "Вы ввели: " << c5 << endl;

    Complex c6(2.0, 3.0);
    Complex c7(1.0, 2.0);

    Complex sum = c6 + c7;
    Complex diff = c6 - c7;

    cout << c6 << " + " << c7 << " = " << sum << endl;
    cout << c6 << " - " << c7 << " = " << diff << endl;

    Complex c8(3.0, 4.0);
    Complex c9(1.0, 2.0);

    Complex prod = c8 * c9;
    Complex quot = c8 / c9;

    cout << c8 << " * " << c9 << " = " << prod << endl;
    cout << c8 << " / " << c9 << " = " << quot << endl;

    Complex c10(5.0, 3.0);
    Complex c11(5.0, 3.0);
    Complex c12(5.0, 4.0);

    cout << c10 << " == " << c11 << ": " << (c10 == c11 ? "true" : "false") << endl;
    cout << c10 << " == " << c12 << ": " << (c10 == c12 ? "true" : "false") << endl;

    Complex c13;
    cout << "c13 до: " << c13 << endl;
    c13(7.0, 8.0);
    cout << "c13(7.0, 8.0): " << c13 << endl;

    return 0;
}