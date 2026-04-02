#pragma once
#include "Point.h"
#include <string>
using namespace std;

class Vehicle {
protected:
    string model;
    int year;
    Point position;
    static int totalVehicles;

public:
    Vehicle(const string& model, int year, const Point& pos);
    explicit Vehicle(const string& model);
    Vehicle(const Vehicle& other);
    virtual ~Vehicle();

    virtual double getMaxSpeed() const = 0;
    virtual void print() const = 0;
    virtual Vehicle* clone() const = 0;

    void move(const Point& newPos);

    static int getTotalVehicles();

    const string& getModel() const;
    int getYear() const;
    const Point& getPosition() const;
};
