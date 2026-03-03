#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <vector>
#include <conio.h>
#include "Subscriber.h"
#include <windows.h>
using namespace std;

int main() {
	setlocale(LC_ALL, "ru");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	Subscriber sub1;
	sub1.menu();
	return 0;
}