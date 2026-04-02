#pragma once
#include <iostream>
#include <string>
using namespace std;


class Animal {
public:
    virtual void speak() const {
        cout << "I am an animal" << endl;
    }

    virtual ~Animal() {}
};


class Dog : public Animal {
public:
    void speak() const override {
        cout << "Woof! Woof!" << endl;
    }
};


class Cat : public Animal {
public:
    void speak() const override {
        cout << "Meow!" << endl;
    }
};

class Cow : public Animal {
public:
    void speak() const override {
        cout << "Moo!" << endl;
    }
};

class Horse : public Animal {
public:
    void speak() const override {
        cout << "Neigh!" << endl;
    }
};
