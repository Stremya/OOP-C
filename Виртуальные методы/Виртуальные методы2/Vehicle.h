#pragma once
#include <iostream>
#include <string>
using namespace std;

class Vehicle {
public:
    virtual void startEngine() const {
        cout << "Engine started" << endl;
    }

    virtual double getMaxSpeed() const {
        return 0;
    }

    virtual void info() const {
        cout << "This is a vehicle" << endl;
    }

    virtual ~Vehicle() {}
};

class Car : public Vehicle {
public:
    void startEngine() const override {
        cout << "Car engine started" << endl;
    }

    double getMaxSpeed() const override {
        return 180;
    }

    void info() const override {
        cout << "I am a car" << endl;
    }
};

class ElectricCar : public Car {
public:
    void startEngine() const override {
        cout << "Electric motor silently started" << endl;
    }

    double getMaxSpeed() const final override {
        return 180;
    }
};

class SportsCar : public Car {
public:
    double getMaxSpeed() const override {
        return 250;  
    }
};

class Bicycle final : public Vehicle {
public:
    void startEngine() const override {
        cout << "Pedaling started" << endl;
    }

    double getMaxSpeed() const override {
        return 30;
    }

    void info() const override {
        cout << "I am a bicycle" << endl;
    }
};

