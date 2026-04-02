#include "Bike.h"
#include <iostream>
using namespace std;

Bike::Bike(const string& model, int year, const Point& pos, const string& type)
    : Vehicle(model, year, pos), type(type) {
}

double Bike::getMaxSpeed() const { return 60.0; }

void Bike::print() const {
    cout << "[Bike] " << model << " (" << year << "), Pos: " << position
        << ", Type: " << type << ", MaxSpeed: " << getMaxSpeed() << endl;
}

Vehicle* Bike::clone() const { return new Bike(*this); }
