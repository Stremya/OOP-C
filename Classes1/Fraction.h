#pragma once
class Fraction
{
private:
	// Числитель
	double num;
	// Знаменатель
	double den;

	static int objectCount; // Подсчет объект
public:
	Fraction();

	Fraction(double n, double d);

	~Fraction();

	double getNum() const { return num; }
	double getDen() const { return den; }

	void setNum(double num);
	void setDen(double den);

	Fraction enterFraction();
	void printFraction();

	static int getObjectCount() { return objectCount; }
};

