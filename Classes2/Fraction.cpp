#include "Fraction.h"

double Fraction::gcd(double a, double b) {
	a = abs(a);
	b = abs(b);

	while (b != 0) {
		double temp = b;
		b = static_cast<long long>(a) % static_cast<long long>(b);
		a = temp;
	}
	return a;
}

void Fraction::reduction() {
	double reduction = gcd(numerator, denominator);
	numerator = numerator / reduction;
	denominator = denominator / reduction;

	if (denominator < 0) {
		numerator = -numerator;
		denominator = -denominator;
	}
}

Fraction::Fraction(double num, double den)
	: numerator(num), denominator(den) 
{
	if (den == 0) {
		cout << "Ошибка: знаменатель не может быть равен 0" << endl;
		den = 1;
	}
}

Fraction::Fraction() : Fraction(1, 1) {}

void Fraction::printFraction() const {
	cout << "( " << this->numerator << "/" << this->denominator << " )";
}

Fraction Fraction::fractionSum(const Fraction& other) const {

	double newNum = numerator * other.denominator + denominator * other.numerator;
	double newDen = denominator * other.denominator;

	Fraction result(newNum, newDen);
	result.reduction();
	return result;
}

Fraction Fraction::fractionSub(const Fraction& other) const {

	double newNum = numerator * other.denominator - denominator * other.numerator;
	double newDen = denominator * other.denominator;

	Fraction result(newNum, newDen);
	result.reduction();
	return result;
}

Fraction Fraction::fractionMult(const Fraction& other) const {

	double newNum = numerator * other.numerator;
	double newDen = denominator * other.denominator;

	Fraction result(newNum, newDen);
	result.reduction();
	return result;
}

Fraction Fraction::intFractionSum(double n) const {

	double newNum = numerator + n * denominator;
	double newDen = denominator;

	Fraction result(newNum, newDen);
	result.reduction();
	return result;
}

Fraction Fraction::intFractionSub(double n) const {

	double newNum = numerator - n * denominator;
	double newDen = denominator;

	Fraction result(newNum, newDen);
	result.reduction();
	return result;
}

Fraction Fraction::intFractionMult(double n) const {

	double newNum = numerator * n;
	double newDen = denominator;

	Fraction result(newNum, newDen);
	result.reduction();
	return result;
}