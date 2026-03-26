#include "SetOfInt.h"

bool SetOfInt::affiliation(int val) const {
    for (int i = 0; i < size; i++)
        if (elements[i] == val)
            return true;
    return false;
}

SetOfInt::SetOfInt(int arr[], int n) {
    elements = new int[n];
    size = 0;
    for (int i = 0; i < n; i++)
        *this = *this + arr[i];
}

SetOfInt::SetOfInt() {
    elements = new int[10];
    size = 0;
}

SetOfInt::SetOfInt(const SetOfInt& other) {
    size = other.size;
    elements = new int[size];
    for (int i = 0; i < size; i++)
        elements[i] = other.elements[i];
}

SetOfInt SetOfInt::operator+(int val) const {
    SetOfInt result = *this;
    if (!contains(value)) {
        result.elements = new int[size + 1];
        for (int i = 0; i < size; i++)
            result.elements[i] = elements[i];
        result.elements[size] = value;
        result.size = size + 1;
    }
    return result;
}

SetOfInt SetOfInt::operator+(const SetOfInt& other) const {
    SetOfInt result = *this;
    for (int i = 0; i < other.size; i++)
        result = result + other.elements[i];
    return result;
}

SetOfInt& SetOfInt::operator+=(int value) {
    *this = *this + value;
    return *this;
}

SetOfInt& SetOfInt::operator+=(const SetOfInt& other) {
    *this = *this + other;
    return *this;
}

SetOfInt SetOfInt::operator-(int value) const {
    SetOfInt result;
    for (int i = 0; i < size; i++)
        if (elements[i] != value)
            result = result + elements[i];
    return result;
}

SetOfInt SetOfInt::operator-(const SetOfInt& other) const {
    SetOfInt result = *this;
    for (int i = 0; i < other.size; i++)
        result = result - other.elements[i];
    return result;
}

SetOfInt& SetOfInt::operator-=(int value) {
    *this = *this - value;
    return *this;
}

SetOfInt& SetOfInt::operator-=(const SetOfInt& other) {
    *this = *this - other;
    return *this;
}

SetOfInt SetOfInt::operator*(const SetOfInt& other) const {
    SetOfInt result;
    for (int i = 0; i < size; i++)
        if (other.contains(elements[i]))
            result = result + elements[i];
    return result;
}

SetOfInt& SetOfInt::operator=(const SetOfInt& other) {
    if (this != &other) {
        delete[] elements;
        size = other.size;
        elements = new int[size];
        for (int i = 0; i < size; i++)
            elements[i] = other.elements[i];
    }
    return *this;
}

bool SetOfInt::operator==(const SetOfInt & other) const {
    if (size != other.size) return false;
    for (int i = 0; i < size; i++)
        if (!other.contains(elements[i]))
            return false;
    return true;
}

ostream& operator<<(ostream& os, const SetOfInt& other) {
    os << "{";
    for (int i = 0; i < other.size; i++) {
        os << other.elements[i];
        if (i < other.size - 1) os << ", ";
    }
    os << "}";
    return os;
}

istream& operator>>(istream& is, SetOfInt& other) {
    int n, value;
    cout << "Êîëè÷åñòâî ýëåìåíòîâ: ";
    is >> n;
    cout << "Ýëåìåíòû: ";
    for (int i = 0; i < n; i++) {
        is >> value;
        other += value;
    }
    return is;
}

bool SetOfInt::belongs(int val) const {
    return affiliation(val);
}
