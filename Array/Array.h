#pragma once
#include <iostream>
#include <algorithm>
using namespace std;
class Array
{
private:
    int* data;        // указатель на динамический массив
    int size;         // размер массива

    // Вспомогательный метод для копирования
    void copyArray(const Array& other);

public:
    Array();
    Array(int size);
    Array(const Array& other);

    ~Array();

    int& operator[](int index);
    const int& operator[](int index) const;

    void operator()(int value);

    operator int() const;

    operator char*() const;

    // Заполнение массива
    void fillArray();
    void fillValue(int value);

    void setElement(int index, int value);
    int getElement(int index) const;

    // Вывод
    void printArray() const;

    // Изменение размера
    void resize(int newSize);

    // Сортировка
    void sortAscending();
    void sortDescending();

    // Мин/Макс
    int getMin() const;
    int getMax() const;

    // Размер
    int getSize() const { return size; }

    // Присваивание
    void assign(const Array& other);
};

