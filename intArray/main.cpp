#include <iostream>
#include <utility>
#include "intArray.h"
using namespace std;
int main()
{
    setlocale(LC_ALL, "ru");

    intArray arr1(5);
    intArray arr2(10);
    
    arr1.setElement(0, 100);
    arr1.setElement(1, 200);
    arr1.setElement(2, 300);
    arr1.setElement(3, 400);
    arr1.setElement(4, 500);

    cout << "arr1:" << endl;
    arr1.print();

    intArray arr3 = arr1;

    cout << "arr3:" << endl;
    arr3.print();

    arr2 = arr1;
    cout << "arr2:" << endl;
    arr2.print();

    intArray arr4 = move(arr3);
    cout << "arr4:" << endl;
    arr4.print();
    return 0;
}
