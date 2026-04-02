#pragma once
#include <iostream>
#include <stdexcept>
using namespace std;

template<typename T>
class Garage {
private:
    T* items;
    int capacity;
    int count;
    static int garageCount;

    void clean() {
        for (int i = 0; i < count; i++) {
            delete items[i];
        }
        delete[] items;
        items = nullptr;
        count = 0;
        capacity = 0;
    }

    void copyFrom(const Garage& other) {
        capacity = other.capacity;
        count = other.count;
        items = new T[capacity];
        for (int i = 0; i < count; i++) {
            items[i] = other.items[i]->clone();
        }
    }

public:
    Garage();
    explicit Garage(size_t size);
    Garage(const Garage& other);
    ~Garage();

    Garage& operator=(const Garage& other);

    Garage& add(const T& item);

    T& operator[](int index);
    const T& operator[](int index) const;

    Garage operator+(const Garage& other) const;

    int getCount() const;
    static int getTotalGarages();
};

template<typename T>
int Garage<T>::garageCount = 0;

template<typename T>
Garage<T>::Garage() : items(nullptr), capacity(0), count(0) { garageCount++; }

template<typename T>
Garage<T>::Garage(size_t size) : capacity(size), count(0) {
    items = new T[capacity];
    garageCount++;
}

template<typename T>
Garage<T>::Garage(const Garage& other) : items(nullptr), capacity(0), count(0) {
    garageCount++;
    if (other.count > 0) copyFrom(other);
}

template<typename T>
Garage<T>::~Garage() {
    clean();
    garageCount--;
}

template<typename T>
Garage<T>& Garage<T>::operator=(const Garage& other) {
    if (this != &other) {
        clean();
        if (other.count > 0) copyFrom(other);
    }
    return *this;
}

template<typename T>
Garage<T>& Garage<T>::add(const T& item) {
    if (count >= capacity) {
        int newCap = (capacity == 0) ? 2 : capacity * 2;
        T* newItems = new T[newCap];
        for (int i = 0; i < count; i++) newItems[i] = items[i];
        delete[] items;
        items = newItems;
        capacity = newCap;
    }
    items[count++] = item->clone();
    return *this;
}

template<typename T>
T& Garage<T>::operator[](int index) {
    if (index < 0 || index >= count) throw out_of_range("Индекс вне диапазона");
    return items[index];
}

template<typename T>
const T& Garage<T>::operator[](int index) const {
    if (index < 0 || index >= count) throw out_of_range("Индекс вне диапазона");
    return items[index];
}

template<typename T>
Garage<T> Garage<T>::operator+(const Garage& other) const {
    Garage result(capacity + other.capacity);
    for (int i = 0; i < count; i++) result.add(items[i]);
    for (int i = 0; i < other.count; i++) result.add(other.items[i]);
    return result;
}

template<typename T>
int Garage<T>::getCount() const { return count; }

template<typename T>
int Garage<T>::getTotalGarages() { return garageCount; }
