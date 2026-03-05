#include "Fraction.h"
#include <iostream>
#include <string>

using namespace std;

int Fraction::objectCount = 0;

Fraction::Fraction() : Fraction(1, 1) {}

Fraction::Fraction(double n, double d) : num(n), den(d) {
	objectCount++; 
}

Fraction::~Fraction() {
	objectCount--;
}

void Fraction::setNum(double n) {
	num = n;
}

void Fraction::setDen(double d) {
	den = d;
}

Fraction Fraction::enterFraction() {
	double num, den;
	cout << "¬ведите числитель:";
	cin >> num;
	cout << "¬ведите знаменатель:";
	cin >> den;
	return Fraction(num, den);
}

void Fraction::printFraction() {
	cout << "ƒробь:" << endl;
	cout << num << "\n-\n" << den << endl;
}

