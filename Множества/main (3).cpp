#include <iostream>
#include "SetOfInt.h"
using namespace std;

int main() {
    setlocale(LC_ALL, "ru");

    int arr1[] = { 3, 8, 46, 5, 11 };
    int arr2[] = { 18, 8, 90, 11, 2 };

    SetOfInt A(arr1, 5);
    SetOfInt B(arr2, 5);

    cout << "A = " << A << endl;
    cout << "B = " << B << endl;

    cout << "\nA + 4 = " << (A + 4) << endl;
    cout << "A + B = " << (A + B) << endl;
    cout << "A - B = " << (A - B) << endl;
    cout << "A * B = " << (A * B) << endl;

    cout << "\nA == B: " << (A == B ? "да" : "нет") << endl;
    cout << "11 принадлежит A: " << (A.belongs(11) ? "да" : "нет") << endl;

    SetOfInt C;
    cin >> C;
    cout << "Введено: " << C << endl;

    return 0;
}