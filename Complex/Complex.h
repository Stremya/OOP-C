#pragma once
#include <iostream>
#include <cmath>
using namespace std;

class Complex
{
private:
    double realPart;      // действительная часть
    double imagPart;      // мнимая часть

public:
    
    Complex();                          
    Complex(double r, double i = 0);   
    Complex(const Complex& other);      

    double getReal() const { return realPart; }
    double getImag() const { return imagPart; }
    void setReal(double r) { realPart = r; }
    void setImag(double i) { imagPart = i; }

    double abs() const;                 
    double arg() const;                 
    Complex conjugate() const;          

    Complex operator+(const Complex& other) const;
    Complex operator-(const Complex& other) const;
    Complex operator*(const Complex& other) const;
    Complex operator/(const Complex& other) const;
    bool operator==(const Complex& other) const;
    Complex operator()(double r, double i);  

    friend ostream& operator<<(ostream& os, const Complex& c);
    friend istream& operator>>(istream& is, Complex& c);

    friend Complex operator+(const Complex& c, double d);
    friend Complex operator+(double d, const Complex& c);
};

