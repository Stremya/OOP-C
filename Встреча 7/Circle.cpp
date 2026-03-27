#include "Circle.h"
Circle::Circle(double r) : radius(r >= 0 ? r : 0) {
    if (r < 0) {
        cout << "[Warning] Радиус не может быть отрицательным! Установлено 0." << endl;
    }
}


void Circle::setRadius(double r) {
    if (r >= 0) {
        radius = r;
    }
    else {
        cout << "[Warning] Радиус не может быть отрицательным!" << endl;
    }
}


double Circle::getArea() const {
    return PI * radius * radius;
}


double Circle::getCircumference() const {
    return 2 * PI * radius;
}

bool Circle::operator==(const Circle& other) const {
    return radius == other.radius;
}

bool Circle::operator>(const Circle& other) const {
    return getCircumference() > other.getCircumference();
}

Circle& Circle::operator+=(double value) {
    if (radius + value >= 0) {
        radius += value;
    }
    else {
        cout << "Радиус не может стать отрицательным!" << endl;
    }
    return *this; 
}

Circle& Circle::operator-=(double value) {
    if (radius - value >= 0) {
        radius -= value;
    }
    else {
        cout << "Радиус не может стать отрицательным!" << endl;
    }
    return *this;
}

ostream& operator<<(ostream& os, const Circle& circle) {
    os << "Circle(radius=" << circle.radius
        << ", area=" << circle.getArea()
        << ", circumference=" << circle.getCircumference() << ")";
    return os;
}