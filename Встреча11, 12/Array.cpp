#include "Array.h"
template<typename T>
Array<T>::Array() : data(nullptr), size(0), count(0), grow(1) {}

template<typename T>
Array<T>::Array(int initialSize, int growBy) : data(nullptr), size(0), count(0), grow(growBy) {
    if (initialSize > 0) {
        data = new T[initialSize];
        size = initialSize;
        count = 0;
    }
}

template<typename T>
Array<T>::Array(const Array<T>& other) : data(nullptr), size(0), count(0), grow(other.grow) {
    if (other.count > 0) {
        data = new T[other.size];
        size = other.size;
        count = other.count;
        for (int i = 0; i < count; i++) {
            data[i] = other.data[i];
        }
    }
}

template<typename T>
Array<T>::~Array() {
    delete[] data;
    data = nullptr;
    size = 0;
    count = 0;
}

template<typename T>
void Array<T>::SetSize(int newSize, int growBy) {
    this->grow = growBy;

    if (newSize <= 0) {
        RemoveAll();
        return;
    }

    if (newSize > size) {
        int newSizeAlloc = newSize;
        if (growBy > 0) {
            newSizeAlloc = ((newSize + growBy - 1) / growBy) * growBy;
        }

        T* newData = new T[newSizeAlloc];

        for (int i = 0; i < count; i++) {
            newData[i] = data[i];
        }

        delete[] data;
        data = newData;
        size = newSizeAlloc;
    }

    count = newSize;
}

template<typename T>
void Array<T>::FreeExtra() {
    if (count < size) {
        if (count == 0) {
            delete[] data;
            data = nullptr;
            size = 0;
        }
        else {
            T* newData = new T[count];
            for (int i = 0; i < count; i++) {
                newData[i] = data[i];
            }
            delete[] data;
            data = newData;
            size = count;
        }
    }
}

template<typename T>
void Array<T>::RemoveAll() {
    delete[] data;
    data = nullptr;
    size = 0;
    count = 0;
}

template<typename T>
T Array<T>::GetAt(int index) const {
    if (index < 0 || index >= count) {
        throw out_of_range("Индекс вне диапазона");
    }
    return data[index];
}

template<typename T>
void Array<T>::SetAt(int index, const T& value) {
    if (index < 0 || index >= count) {
        throw out_of_range("Индекс вне диапазона");
    }
    data[index] = value;
}

template<typename T>
T& Array<T>::operator[](int index) {
    if (index < 0 || index >= count) {
        throw out_of_range("Индекс вне диапазона");
    }
    return data[index];
}

template<typename T>
const T& Array<T>::operator[](int index) const {
    if (index < 0 || index >= count) {
        throw out_of_range("Индекс вне диапазона");
    }
    return data[index];
}

template<typename T>
int Array<T>::Add(const T& element) {
    if (count >= size) {
        int newSize = (size == 0) ? grow : size + grow;
        SetSize(newSize, grow);
    }
    data[count] = element;
    return count++;
}

template<typename T>
void Array<T>::Append(const Array<T>& other) {
    for (int i = 0; i < other.count; i++) {
        Add(other.data[i]);
    }
}

template<typename T>
Array<T>& Array<T>::operator=(const Array<T>& other) {
    if (this != &other) {
        RemoveAll();
        grow = other.grow;
        if (other.count > 0) {
            data = new T[other.size];
            size = other.size;
            count = other.count;
            for (int i = 0; i < count; i++) {
                data[i] = other.data[i];
            }
        }
    }
    return *this;
}

template<typename T>
void Array<T>::InsertAt(int index, const T& element) {
    if (index < 0 || index > count) {
        throw out_of_range("Индекс вне диапазона");
    }

    if (count >= size) {
        SetSize(count + grow, grow);
    }

    for (int i = count; i > index; i--) {
        data[i] = data[i - 1];
    }

    data[index] = element;
    count++;
}

template<typename T>
void Array<T>::RemoveAt(int index) {
    if (index < 0 || index >= count) {
        throw out_of_range("Индекс вне диапазона");
    }

    for (int i = index; i < count - 1; i++) {
        data[i] = data[i + 1];
    }

    count--;
}