#include "Vehicle.h"

int Vehicle::totalVehicles = 0;

Vehicle::Vehicle(const string& model, int year, const Point& pos)
    : model(model), year(year), position(pos) {
    totalVehicles++;
}

Vehicle::Vehicle(const string& model)
    : model(model), year(2020), position(0, 0) {
    totalVehicles++;
}

Vehicle::Vehicle(const Vehicle& other)
    : model(other.model), year(other.year), position(other.position) {
    totalVehicles++;
}

Vehicle::~Vehicle() { totalVehicles--; }

void Vehicle::move(const Point& newPos) { position = newPos; }

int Vehicle::getTotalVehicles() { return totalVehicles; }

const string& Vehicle::getModel() const { return model; }

int Vehicle::getYear() const { return year; }

const Point& Vehicle::getPosition() const { return position; }