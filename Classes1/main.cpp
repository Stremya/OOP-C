#include <iostream>
#include <string>
#include <conio.h>
#include <windows.h>
#include <fstream>

#include "Student.h" // Класс Student
#include "Point.h" // Класс Point
#include "Fraction.h" // Класс Fraction

using namespace std;

int main() {
	setlocale(LC_ALL, "ru");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	
	// Работа с классом Student
	Student student1, student2;

	student1.setName("Крэйон Шин Чан");
	student1.setDate("28.03.2004");
	student1.setNumber(122414);
	student1.setCity("Москва");
	student1.setCountry("Россия");
	student1.setSchool_name("Маленькое");
	student1.setSchool_city("Москва");
	student1.setSchool_country("Россия");
	student1.setGroup("Группа маленьких");
	student1.printStudent();
	cout << endl;
	student2.enterStudent();
	student2.printStudent();
	cout << endl;
	

	/*
	// Работа с классом Point
	Point coordinates1, coordinates2;
	coordinates1.setX(3.3);
	coordinates1.setY(6.8);
	coordinates1.setZ(3.5);

	coordinates1.printCoordinates();
	coordinates2 = coordinates2.enterCoordinates();
	coordinates2.saveToFile();

	if (coordinates2.loadFromFile()) {
		coordinates2.printCoordinates();
	}
	*/
	/*
	// Работа с классом Fraction
	Fraction fraction1, fraction2;

	fraction1.setNum(3.9);
	fraction1.setDen(8.2);

	fraction1.printFraction();

	fraction2 = fraction2.enterFraction();
	fraction2.printFraction();
	*/
	_getch();
	return 0;
}