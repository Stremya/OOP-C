#include "Car.h"
#include <iostream>
using namespace std;

Car::Car(const string& model, int year, const Point& pos, int doors)
    : Vehicle(model, year, pos), doors(doors) {
}

double Car::getMaxSpeed() const { return 180.0; }

void Car::print() const {
    cout << "[Car] " << model << " (" << year << "), Pos: " << position
        << ", Doors: " << doors << ", MaxSpeed: " << getMaxSpeed() << endl;
}

Vehicle* Car::clone() const { return new Car(*this); }

Car& Car::operator++() {
    doors++;
    return *this;
}

Car Car::operator++(int) {
    Car temp = *this;
    ++(*this);
    return temp;
}
