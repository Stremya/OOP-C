#pragma once
#include <iostream>
#include <string>
using namespace std;
class Cat
{
protected:
	string name; // имя кота
	int age; // возраст
	string color; // окрас

	static int countCat;
public:
	static int getCountCat() { return countCat; }

	Cat(const string& n, int a, const string& c);

	~Cat();

	// вывод информации
	void printInfo() const;

	// звук издаваемый котом
	void sound() const;
};

class HouseCat : public Cat {
private:
	string ownerCat;
public:
	HouseCat(const string& n, int a, const string& c, const string& owner);

	~HouseCat();

	// вывод информации
	void printInfo() const;

	// звук издаваемый кошкой
	void sound() const;

	// Собственный метод HouseCat 
	// кот играет
	void play() const;
};

class WildCat : public Cat {
private:
	string habitat;
public:
	WildCat(const string& n, int a, const string& c, const string& hab);

	~WildCat();

	// вывод информации
	void printInfo() const;

	// звук издаваемый кошкой
	void sound() const;

	// Собственный метод WildCat 
	// кот охотиться
	void hunt() const;
};

class PersianCat : public Cat {
private:
	int woolLength;
public:
	PersianCat(const string& n, int a, const string& c, int wLen);

	~PersianCat();

	// вывод информации
	void printInfo() const;

	// звук издаваемый кошкой
	void sound() const;

	// Собственный метод PersianCat
	// уход за котом
	void groom() const;
};

