#include <iostream>
#include "Array.h"
using namespace std;

int main() {
    setlocale(LC_ALL, "ru");

    Array arr(5);
    arr.fillArray();
    cout << "arr: ";
    arr.printArray();

    cout << "arr[0] = " << arr[0] << endl;
    cout << "arr[2] = " << arr[2] << endl;

    arr[0] = 100;
    arr[3] = 200;
    cout << "После изменения: ";
    arr.printArray();

    cout << "arr до: ";
    arr.printArray();
    arr(10);  
    cout << "arr после arr(10): ";
    arr.printArray();

    Array arr2(4);
    arr2.fillValue(5); 
    arr2.printArray();

    int sum = (int)arr2;  
    cout << "Сумма элементов: " << sum << endl;  

    Array arr3(5);
    arr3.fillValue(42);
    cout << "arr3: ";
    arr3.printArray();

    char* str = arr3;  
    cout << "Строковое представление: " << str << endl;
    delete[] str;  
    return 0;
}