#pragma once
#include <iostream>
using namespace std;
class Circle
{
private:
    double radius;

    static constexpr double PI = 3.14;

public:
    Circle(double r = 0.0);

    double getRadius() const { return radius; }
    void setRadius(double r);

    double getArea() const;           
    double getCircumference() const;  

    bool operator==(const Circle& other) const;

    bool operator>(const Circle& other) const;

    Circle& operator+=(double value);

    Circle& operator-=(double value);

    friend ostream& operator<<(ostream& os, const Circle& circle);
};

