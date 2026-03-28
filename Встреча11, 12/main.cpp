#include <iostream>
#include "Array.h"
using namespace std;

int main() {
    setlocale(LC_ALL, "ru");

    Array<int> arr1;
    cout << "arr1 создан, size = " << arr1.GetSize() << endl;
    cout << "arr1 пуст? " << (arr1.IsEmpty() ? "да" : "нет") << endl;

    Array<int> arr2(5, 3); 
    cout << "arr2 создан с размером 5, size = " << arr2.GetSize() << endl;

    arr2[0] = 10;
    arr2[1] = 20;
    arr2[2] = 30;
    arr2.SetAt(3, 40);
    arr2.SetAt(4, 50);

    cout << "arr2: ";
    for (int i = 0; i < arr2.GetSize(); i++) {
        cout << arr2[i] << " ";
    }
    cout << endl;

    cout << "\n=== Add (добавление с ростом) ===" << endl;
    Array<int> arr3(5, 5);  
    for (int i = 0; i < 12; i++) {
        arr3.Add(i * 10);
        cout << "Добавлен элемент " << i << ", size = " << arr3.GetSize() << endl;
    }

    cout << "\n=== GetUpperBound ===" << endl;
    cout << "arr3.GetUpperBound() = " << arr3.GetUpperBound() << endl;

    cout << "\n=== Конструктор копирования ===" << endl;
    Array<int> arr4 = arr3;
    cout << "arr4 (копия arr3), size = " << arr4.GetSize() << endl;

    cout << "\n=== Append (добавление массива) ===" << endl;
    Array<int> arr5;
    arr5.Append(arr3);
    cout << "arr5 после append arr3, size = " << arr5.GetSize() << endl;

    cout << "\n=== InsertAt (вставка) ===" << endl;
    Array<int> arr6(3);
    arr6[0] = 1;
    arr6[1] = 2;
    arr6[2] = 3;
    cout << "arr6 до вставки: ";
    for (int i = 0; i < arr6.GetSize(); i++) cout << arr6[i] << " ";
    cout << endl;

    arr6.InsertAt(1, 999); 
    cout << "arr6 после InsertAt(1, 999): ";
    for (int i = 0; i < arr6.GetSize(); i++) cout << arr6[i] << " ";
    cout << endl;

    cout << "\n=== RemoveAt (удаление) ===" << endl;
    arr6.RemoveAt(1);  
    cout << "arr6 после RemoveAt(1): ";
    for (int i = 0; i < arr6.GetSize(); i++) cout << arr6[i] << " ";
    cout << endl;

    cout << "\n=== FreeExtra ===" << endl;
    Array<int> arr7(10, 10);
    for (int i = 0; i < 5; i++) arr7.Add(i);
    cout << "arr7: size = " << arr7.GetSize() << ", выделено = " << arr7.GetData() << endl;
    arr7.FreeExtra();
    cout << "После FreeExtra: size = " << arr7.GetSize() << endl;

    cout << "\n=== RemoveAll ===" << endl;
    arr7.RemoveAll();
    cout << "После RemoveAll: size = " << arr7.GetSize() << ", пуст? "
        << (arr7.IsEmpty() ? "да" : "нет") << endl;

    cout << "\n=== Оператор присваивания ===" << endl;
    Array<int> arr8(5);
    for (int i = 0; i < 5; i++) arr8[i] = i * 10;

    Array<int> arr9;
    arr9 = arr8;
    cout << "arr9 = arr8: ";
    for (int i = 0; i < arr9.GetSize(); i++) cout << arr9[i] << " ";
    cout << endl;

    cout << "\n=== GetData ===" << endl;
    int* ptr = arr8.GetData();
    cout << "Прямой доступ через GetData: ";
    for (int i = 0; i < arr8.GetSize(); i++) cout << ptr[i] << " ";
    cout << endl;

    cout << "\n=== Работа с double ===" << endl;
    Array<double> arr10(3);
    arr10[0] = 3.14;
    arr10[1] = 2.71;
    arr10[2] = 1.41;
    cout << "Массив double: ";
    for (int i = 0; i < arr10.GetSize(); i++) cout << arr10[i] << " ";
    cout << endl;

    return 0;
}