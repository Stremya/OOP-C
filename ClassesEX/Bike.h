#pragma once
#include "Vehicle.h"
#include <string>
using namespace std;

class Bike : public Vehicle {
private:
    string type;

public:
    Bike(const string& model, int year, const Point& pos, const string& type);

    double getMaxSpeed() const override;
    void print() const override;
    Vehicle* clone() const override;
};

