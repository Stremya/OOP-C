#include "GeometricShapes.h"

double P = 3.14;
int GeometricShapes::countSquare = 0;

double GeometricShapes::triangleSquare1(double len, double h) {
	if (len < 0 && h < 0) {
		cerr << "Ошибка: параметры должны быть положительными" << endl;
		return 1;
	}
	double S = (len * h) / 2;
	countSquare++;
	return S;
}

double GeometricShapes::triangleSquare2(double a, double b, double corner) {
	if (a < 0 && b < 0) {
		cerr << "Ошибка: параметры должны быть положительными" << endl;
		return 1;
	}
	if (corner < 0 && corner > 180) {
		cerr << "Ошибка: угол должен быть от 0 до 180 градусов" << endl;
		return 1;
	}
	countSquare++;

	double degrees = corner * P / 180;
	double S = (a * b * sin(degrees)) / 2;
	return S;
}

double GeometricShapes::triangleSquare3(double a, double b, double c) {
	if (a < 0 && b < 0 && c < 0) {
		cerr << "Ошибка: параметры должны быть положительными" << endl;
		return 1;
	}
	countSquare++;
	double p = (a + b + c) / 2;
	double S = sqrt(p * (p - a) * (p - b) * (p - c));
	return S;
}

double GeometricShapes::rectangleSquare(double a, double b) {
	if (a < 0 && b < 0) {
		cerr << "Ошибка: параметры должны быть положительными" << endl;
		return 1;
	}
	countSquare++;
	double S = a * b;
	return S;
}

double GeometricShapes::squareArea(double a) {
	if (a < 0) {
		cerr << "Ошибка: параметры должны быть положительными" << endl;
		return 1;
	}
	countSquare++;
	double S = a * a;
	return S;
}

double GeometricShapes::rhombSquare(double a, double h) {
	if (a < 0 && h < 0) {
		cerr << "Ошибка: параметры должны быть положительными" << endl;
		return 1;
	}
	countSquare++;
	double S = a * h;
	return S;
}

void GeometricShapes::resetCount() {
	countSquare = 0;
}