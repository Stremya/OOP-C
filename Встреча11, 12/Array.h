#pragma once
#include <iostream>
#include <stdexcept>
using namespace std;

template<typename T>
class Array {
private:
    T* data;           // указатель на массив
    int size;          // выделенный размер
    int count;         // количество используемых элементов
    int grow;          // шаг роста

public:
    Array();
    Array(int initialSize, int growBy = 1);
    Array(const Array<T>& other);
    ~Array();

    int GetSize() const { return count; }
    void SetSize(int newSize, int growBy = 1);
    int GetUpperBound() const { return count - 1; }
    bool IsEmpty() const { return count == 0; }

    void FreeExtra();
    void RemoveAll();

    T GetAt(int index) const;
    void SetAt(int index, const T& value);
    T& operator[](int index);
    const T& operator[](int index) const;

    int Add(const T& element);
    void Append(const Array<T>& other);

    Array<T>& operator=(const Array<T>& other);

    T* GetData() { return data; }
    const T* GetData() const { return data; }

    void InsertAt(int index, const T& element);
    void RemoveAt(int index);
};
