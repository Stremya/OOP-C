#include "Fraction.h"
#include <iostream>
#include <string>

using namespace std;
Fraction::Fraction() {
	num = 1;
	den = 1;
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

