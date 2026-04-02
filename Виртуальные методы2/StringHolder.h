#pragma once
#include <iostream>
#include <cstring>
using namespace std;

class StringHolder {
protected:
    char* str;
public:
    StringHolder(const char* s) {
        str = new char[strlen(s) + 1];
        strcpy_s(str, strlen(s) + 1, s);
        cout << "StringHolder constructor for \"" << s << "\"" << endl;
    }

    virtual ~StringHolder() {
        cout << "StringHolder destructor for \"" << str << "\"" << endl;
        delete[] str;
    }

    virtual void print() const {
        cout << str << endl;
    }
};

class ReverseString : public StringHolder {
private:
    char* reversed; 

    void createReversed() {
        int len = strlen(str);
        reversed = new char[len + 1];
        for (int i = 0; i < len; i++) {
            reversed[i] = str[len - 1 - i];
        }
        reversed[len] = '\0';
    }

public:
    ReverseString(const char* s) : StringHolder(s), reversed(nullptr) {
        cout << "ReverseString constructor" << endl;
        createReversed();
    }

    ~ReverseString() override {
        cout << "ReverseString destructor" << endl;
        delete[] reversed;
    }

    void print() const override {
        cout << reversed << endl;
    }
};