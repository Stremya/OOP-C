#include <iostream>
#include <windows.h>
#include "String.h"
using namespace std;


int main() {
	setlocale(LC_ALL, "ru");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	String s1;
	cout << "Создано объектов: " << String::getObjectCount() << endl;

	String s2(80);
	cout << "Создано объектов: " << String::getObjectCount() << endl;

	String s3("Текст");
	cout << "Создано объектов: " << String::getObjectCount() << endl;

	s1.enterString();
	s1.printString();

	s3.printString();

	return 0;
}