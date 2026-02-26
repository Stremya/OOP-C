#pragma once
#include <vector>
#include "Student.h"
#include "Subject.h"
using namespace std;
class Group
{
private:
	string name; // Название группы
	vector<Student> studentList; // Список студентов
	vector<Subject> subjectList; // Список предметов
public:
	Group();

	Group(const string n) : name(n) {}

	const string getName() const { return name; }
	void setName(const string n);

	// Ввод данных студента
	void enterStudent();
	// Ввод названия предмета
	void enterSubject();
	// Вывод таблицы
	void printTable() const;
	// Расчёт и вывод результатов
	void calculateAndPrintResults() const;
};

