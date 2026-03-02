#pragma once
class Fraction
{
private:
	// Числитель
	double num;
	// Знаменатель
	double den;
public:
	Fraction();

	Fraction(double n, double d)
		: num(n), den(d) {}

	~Fraction() {}

	double getNum() const { return num; }
	double getDen() const { return den; }

	void setNum(double num);
	void setDen(double den);

	Fraction enterFraction();
	void printFraction();
};

