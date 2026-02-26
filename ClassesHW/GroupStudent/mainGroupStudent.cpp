#include <iostream>
#include <windows.h>
#include "Group.h"
using namespace std;

int main() {
	setlocale(LC_ALL, "ru");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	Group group("Группа-101");

	// Ввод предметов
	cout << "=== Ввод предметов ===" << endl;
	group.enterSubject();

	// Ввод студентов
	cout << "\n=== Ввод студентов ===" << endl;
	group.enterStudent();

	// Вывод таблицы
	cout << "\n\n=== Таблица оценок ===" << endl;
	group.printTable();

	// Расчёт и вывод результатов
	cout << "\n\n=== Результаты расчётов ===" << endl;
	group.calculateAndPrintResults();

	return 0;
}