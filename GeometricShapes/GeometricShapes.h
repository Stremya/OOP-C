#pragma once
#include <iostream>
#include <cmath>
using namespace std;
class GeometricShapes
{
private:
	static int countSquare; // число подсчетов площади
public:

	// Треугольник
	// 1 Формула
	static double triangleSquare1(double len, double h);

	// Треугольник
	// 2 Формула
	static double triangleSquare2(double a, double b, double corner);

	// Треугольник
	// 3 Формула
	static double triangleSquare3(double a, double b, double c);

	// Прямоугольник
	static double rectangleSquare(double a, double b);

	// Квадрат
	static double squareArea(double a);

	// Ромб
	static double rhombSquare(double a, double h);

	// Метод для подсчета количества вычислений площади
	static int getCountSquare() { return countSquare; }

	static void resetCount();
};

