#pragma once
#include <iostream>
using namespace std;

class Human
{
private:
	int id; // идентификационный номер
	char* surname; // фамилия
	char* name; // имя
	char* patronymic; // отчество
	int date; // дата рождения

	static int countHuman; // количество созданных объектов класса Human

	void copyString(char*& dest, const char* src);
public:
	Human(const int id, const char* sn, const char* n, const char* p, int d);

	Human();

	// конструктор копирования
	Human(const Human& human);
    
	~Human();

	static int getCountHuman() { return countHuman; }

	int getId() const { return id; }
	const char* getSurname() const { return surname; }
	const char* getName() const { return name; }
	const char* getPatronymic() const { return patronymic; }
	int getDate() const { return date; }

	Human& setId(int id);
	Human& setSurname(const char* surname);
	Human& setName(const char* name);
	Human& setPatronymic(const char* patronymic);
	Human& setDate(int date);

	// Вывод
	void printHuman() const;
}; 

