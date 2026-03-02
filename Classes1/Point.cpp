#include <fstream>
#include <string>
#include "Point.h"
#include <iostream>
using namespace std;
const char* const FILE_NAME = "coordinates.dat";
Point::Point() {
	x = 0;
	y = 0;
	z = 0;
}

void Point::setX(double x) {
	this->x = x;
}

void Point::setY(double y) {
	this->y = y;
}

void Point::setZ(double z) {
	this->z = z;
}

Point Point::enterCoordinates() {
	double x, y, z;
	cout << "Введите значение x: ";
	cin >> x;
	cout << "Введите значение y: ";
	cin >> y;
	cout << "Введите значение z: ";
	cin >> z;
	return Point(x, y, z);
}

void Point::printCoordinates() const {
	cout << "\nКоординаты:" << endl;
	cout << "x: " << x << endl;
	cout << "y: " << y << endl;
	cout << "z: " << z << endl;
}

void Point::saveToFile() const {
	ofstream file(FILE_NAME);
	if (file.is_open()) {
		file << x << " " << y << " " << z;
		file.close();
		cout << "Координаты сохранены в файл " << FILE_NAME << endl;
	}
	else {
		cerr << "Не открывается файл для записи" << endl;
	}
}

bool Point::loadFromFile() {
	ifstream file(FILE_NAME);
	if (file.is_open()) {
		file >> x >> y >> z;
		file.close();
		cout << "Координаты загружены из файла " << FILE_NAME << endl;
		return true;
	}
	else {
		cout << "Ошибка загрузки из файла " << FILE_NAME << endl;
		return false;
	}
}