#include <iostream>
#include <conio.h>
#include <string>

#include "Student.h"

using namespace std;

void Student::copyString(char*& dest, const char* src) {
	if (src == nullptr) src = "";          // защита от нулевого указателя
	int len = strlen(src);                // длина строки без '\0'
	dest = new char[len + 1];            // выделяем память (включая '\0')
	strcpy_s(dest, len + 1, src);        // безопасное копирование
}

Student::Student() {
	name = nullptr;
	date = nullptr;
	city = nullptr;
	country = nullptr;
	school_name = nullptr;
	school_city = nullptr;
	school_country = nullptr;
	group = nullptr;

	copyString(name, "Неизвестно");
	copyString(date, "Неизвестно");
	copyString(city, "Неизвестно");
	copyString(country, "Неизвестно");
	copyString(school_name, "Неизвестно");
	copyString(school_city, "Неизвестно");
	copyString(school_country, "Неизвестно");
	copyString(group, "Неизвестно");

	number = 11111;
}

Student::Student(const char* n, const char* d, long long num, const char* c, const char* coun,
	const char* s_n, const char* s_c, const char* s_coun, const char* g) {
	name = nullptr;
	date = nullptr;
	city = nullptr;
	country = nullptr;
	school_name = nullptr;
	school_city = nullptr;
	school_country = nullptr;
	group = nullptr;

	copyString(name, n);
	copyString(date, d);
	copyString(city, c);
	copyString(country, coun);
	copyString(school_name, s_n);
	copyString(school_city, s_c);
	copyString(school_country, s_coun);
	copyString(group, g);

	setNumber(num);
}

Student::~Student() {
	delete[] name;
	delete[] date;
	delete[] city;
	delete[] country;
	delete[] school_name;
	delete[] school_city;
	delete[] school_country;
	delete[] group;
}

void Student::setName(const char* n) {
	delete[] name;
	copyString(name, n);
}
void Student::setDate(const char* d) {
	delete[] date;
	copyString(date, d);

}
void Student::setNumber(long long num) {
	if (num < 11111) {
		number = 11111;
	}
	else {
		number = num;
	}
}
void Student::setCity(const char* c) {
	delete[] city;
	copyString(city, c);

}
void Student::setCountry(const char* coun) {
	delete[] country;
	copyString(country, coun);
}
void Student::setSchool_name(const char* s_n) {
	delete[] school_name;
	copyString(school_name, s_n);
}
void Student::setSchool_city(const char* s_c) {
	delete[] school_city;
	copyString(school_city, s_c);
}
void Student::setSchool_country(const char* s_coun) {
	delete[] school_country;
	copyString(school_country, s_coun);
}
void Student::setGroup(const char* g) {
	delete[] group;
	copyString(group, g);
}

void Student::enterStudent() {
	char* name = new char[250];
	char* date = new char[250];
	char* city = new char[250];
	char* country = new char[250];
	char* school_name = new char[250];
	char* school_city = new char[250];
	char* school_country = new char[250];
	char* group = new char[250];
	long long number;
	cout << "Введите ФИО: ";
	cin.getline(name, 250);
	cout << "Введите дату: ";
	cin.getline(date, 250);
	cout << "Введите номер телефона: ";
	cin >> number;
	cin.ignore();
	cout << "Введите город студента: ";
	cin.getline(city, 250);
	cout << "Введите страну студента: ";
	cin.getline(country, 250);
	cout << "Введите название учебного заведения: ";
	cin.getline(school_name, 250);
	cout << "Введите город учебного заведения: ";
	cin.getline(school_city, 250);
	cout << "Введите страну учебного заведения: ";
	cin.getline(school_country, 250);
	cout << "Введите группу: ";
	cin.getline(group, 250);

	setName(name);
	setDate(date);
	setNumber(number);
	setCity(city);
	setCountry(country);
	setSchool_name(school_name);
	setSchool_city(school_city);
	setSchool_country(school_country);
	setGroup(group);

	delete[] name;
	delete[] date;
	delete[] city;
	delete[] country;
	delete[] school_name;
	delete[] school_city;
	delete[] school_country;
	delete[] group;
}

void Student::printStudent() const {
	cout << "\nДанные о студенте: " << endl;
	cout << "ФИО: " << name << endl;
	cout << "Дата: " << date << endl;
	cout << "Номер: " << number << endl;
	cout << "Город студента: " << city << endl;
	cout << "Страна студента: " << country << endl;
	cout << "Название учебного заведения: " << school_name << endl;
	cout << "Город учебного заведения: " << school_city << endl;
	cout << "Страна учебного заведения: " << school_country << endl;
	cout << "Группа: " << group << endl;
}
