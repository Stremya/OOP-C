#pragma once
#include <iostream>
#include <cstdlib>

using namespace std;

class Fraction
{
private:
	double numerator; // числитель
	double denominator; // знаменатель
public:
	// НОД
	double gcd(double a, double b);

	// Сокращение
	void reduction();

	Fraction(double num, double den);

	Fraction();

	~Fraction() {}

	// Вывод
	void printFraction() const;

	// Сложение простых дробей
	Fraction fractionSum(const Fraction& other) const;

	// Вычитание простых дробей
	Fraction fractionSub(const Fraction& other) const;

	// Умножение простых дробей
	Fraction fractionMult(const Fraction& other) const;

	// Сложение простой дроби и целого числа
	Fraction intFractionSum(double n) const;

	// Вычитание простой дроби и целого числа
	Fraction intFractionSub(double n) const;

	// Умножение простой дроби и целого числа
	Fraction intFractionMult(double n) const;
};

