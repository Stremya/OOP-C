#include <iostream>

#include "Fraction.h"

using namespace std;

int main() {
	setlocale(LC_ALL, "ru");

	// Тест сложение простых дробей
	Fraction fract1(3, 5);
	Fraction fract2(2, 7);

	Fraction result1 = fract1.fractionSum(fract2);

	fract1.printFraction();
	cout << " + ";
	fract2.printFraction();
	cout << " = ";
	result1.printFraction();
	cout << endl;

	// Тест вычитание простых дробей
	Fraction result2 = fract1.fractionSub(fract2);

	fract1.printFraction();
	cout << " - ";
	fract2.printFraction();
	cout << " = ";
	result2.printFraction();
	cout << endl;

	// Тест умножения простых дробей
	Fraction result3 = fract1.fractionMult(fract2);

	fract1.printFraction();
	cout << " * ";
	fract2.printFraction();
	cout << " = ";
	result3.printFraction();
	cout << endl;

	// Тест сложение простой дроби и целого числа
	Fraction result4 = fract1.intFractionSum(5);

	fract1.printFraction();
	cout << " + ";
	cout << 5;
	cout << " = ";
	result4.printFraction();
	cout << endl;

	// Тест вычитание простой дроби и целого числа
	Fraction result5 = fract1.intFractionSub(5);

	fract1.printFraction();
	cout << " - ";
	cout << 5;
	cout << " = ";
	result5.printFraction();
	cout << endl;

	// Тест умножения простых дробей
	Fraction result6 = fract1.intFractionMult(5);

	fract1.printFraction();
	cout << " * ";
	cout << 5;
	cout << " = ";
	result6.printFraction();
	cout << endl;
	return 0;
}