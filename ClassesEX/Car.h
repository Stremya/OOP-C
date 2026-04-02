#pragma once
#include "Vehicle.h"

class Car : public Vehicle {
private:
    int doors;

public:
    Car(const string& model, int year, const Point& pos, int doors);

    double getMaxSpeed() const override;
    void print() const override;
    Vehicle* clone() const override;

    Car& operator++();       // Префиксный
    Car operator++(int);     // Постфиксный
};

