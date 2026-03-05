#include <iostream>
#include "GeometricShapes.h"
using namespace std;

int main(){
	setlocale(LC_ALL, "ru");
	GeometricShapes::resetCount();
	// Треугольник
	double areaT1 = GeometricShapes::triangleSquare1(5, 7);
	cout << "Площадь треугольника по 1 формуле (5, 7): " << areaT1 << endl;

	double areaT2 = GeometricShapes::triangleSquare2(5, 7, 30);
	cout << "Площадь треугольника по 2 формуле (5, 7, 30): " << areaT2 << endl;

	double areaT3 = GeometricShapes::triangleSquare2(5, 7, 3);
	cout << "Площадь треугольника по 3 формуле (5, 7, 3): " << areaT3 << endl;

	// Прямоугольник
	double areaR = GeometricShapes::rectangleSquare(5, 7);
	cout << "Площадь прямоугольник(5, 7): " << areaR << endl;

	// Квадрат
	double areaS = GeometricShapes::squareArea(5);
	cout << "Плоащдь квадрата(5): " << areaS << endl;

	// Ромб
	double areaRb = GeometricShapes::rhombSquare(5, 7);
	cout << "Площадь ромба(5, 7): " << areaRb << endl;

	cout << "Всего подсчетов: " << GeometricShapes::getCountSquare() << endl;
	return 0;
}