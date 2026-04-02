#pragma once
#include <iostream>
#include <vector>
#include <string>
using namespace std;

class Drawable {
public:
    virtual void draw() const = 0;  
    virtual ~Drawable() {}   
};

class Serializable {
public:
    virtual string serialize() const = 0;  
    virtual ~Serializable() {}             
};

class Circle : public Drawable, public Serializable {
private:
    double x, y, radius;
public:
    Circle(double x_, double y_, double r)
        : x(x_), y(y_), radius(r) {
    }

    void draw() const override {
        cout << "Drawing circle at (" << x << "," << y
            << ") with radius " << radius << endl;
    }

    string serialize() const override {
        return "Circle " + to_string((int)x) + " "
            + to_string((int)y) + " "
            + to_string((int)radius);
    }

    double getX() const { return x; }
    double getY() const { return y; }
    double getRadius() const { return radius; }
};

class Rectangle : public Drawable, public Serializable {
private:
    double x, y, width, height;
public:
    Rectangle(double x_, double y_, double w, double h)
        : x(x_), y(y_), width(w), height(h) {
    }

    void draw() const override {
        cout << "Drawing rectangle at (" << x << "," << y
            << ") width " << width << " height " << height << endl;
    }

    string serialize() const override {
        return "Rectangle " + to_string((int)x) + " "
            + to_string((int)y) + " "
            + to_string((int)width) + " "
            + to_string((int)height);
    }

    double getX() const { return x; }
    double getY() const { return y; }
    double getWidth() const { return width; }
    double getHeight() const { return height; }
};
