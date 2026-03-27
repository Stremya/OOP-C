#include "Complex.h"
Complex::Complex() : realPart(0), imagPart(0) {
    cout << "[Complex] Конструктор по умолчанию" << endl;
}

Complex::Complex(double r, double i) : realPart(r), imagPart(i) {
    cout << "[Complex] Конструктор с параметрами (" << r << ", " << i << ")" << endl;
}

Complex::Complex(const Complex& other) : realPart(other.realPart), imagPart(other.imagPart) {
    cout << "[Complex] Конструктор копирования" << endl;
}

double Complex::abs() const {
    return sqrt(realPart * realPart + imagPart * imagPart);
}


double Complex::arg() const {
    return atan2(imagPart, realPart);
}


Complex Complex::conjugate() const {
    return Complex(realPart, -imagPart);
}

Complex Complex::operator+(const Complex& other) const {
    return Complex(realPart + other.realPart, imagPart + other.imagPart);
}

Complex Complex::operator-(const Complex& other) const {
    return Complex(realPart - other.realPart, imagPart - other.imagPart);
}

Complex Complex::operator*(const Complex& other) const {
    return Complex(
        realPart * other.realPart - imagPart * other.imagPart,
        realPart * other.imagPart + imagPart * other.realPart
    );
}

Complex Complex::operator/(const Complex& other) const {
    double denominator = other.realPart * other.realPart + other.imagPart * other.imagPart;
    if (denominator == 0) {
        cout << "Ошибка: деление на ноль!" << endl;
        return Complex(0, 0);
    }
    return Complex(
        (realPart * other.realPart + imagPart * other.imagPart) / denominator,
        (imagPart * other.realPart - realPart * other.imagPart) / denominator
    );
}

bool Complex::operator==(const Complex& other) const {
    const double EPS = 1e-10;
    return fabs(realPart - other.realPart) < EPS && fabs(imagPart - other.imagPart) < EPS;
}

Complex Complex::operator()(double r, double i) {
    realPart = r;
    imagPart = i;
    return *this;
}


ostream& operator<<(ostream& os, const Complex& c) {
    if (c.imagPart >= 0) {
        os << c.realPart << " + " << c.imagPart << "i";
    }
    else {
        os << c.realPart << " - " << abs(c.imagPart) << "i";
    }
    return os;
}

istream& operator>>(istream& is, Complex& c) {
    cout << "Введите действительную часть: ";
    is >> c.realPart;
    cout << "Введите мнимую часть: ";
    is >> c.imagPart;
    return is;
}

Complex operator+(const Complex& c, double d) {
    return Complex(c.realPart + d, c.imagPart);
}

Complex operator+(double d, const Complex& c) {
    return Complex(c.realPart + d, c.imagPart);
}