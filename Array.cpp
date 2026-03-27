#include "Array.h"
void Array::copyArray(const Array& other) {
    size = other.size;
    data = new int[size];
    for (int i = 0; i < size; i++) {
        data[i] = other.data[i];
    }
}

Array::Array() : size(10) {
    data = new int[size];
    for (int i = 0; i < size; i++) data[i] = 0;
    cout << "Создан массив размером " << size << endl;
}


Array::Array(int size) : size(size > 0 ? size : 10) {
    if (size <= 0) cout << "Ошибка: размер должен быть > 0!" << endl;
    data = new int[this->size];
    for (int i = 0; i < this->size; i++) data[i] = 0;
    cout << "Создан массив размером " << this->size << endl;
}

Array::Array(const Array& other) {
    cout << "Конструктор копирования" << endl;
    copyArray(other);
}

Array::~Array() {
    cout << "Уничтожен массив размером " << size << endl;
    delete[] data;
    data = nullptr;
}

int& Array::operator[](int index) {
    if (index >= 0 && index < size) {
        return data[index];
    }
    else {
        cout << "Ошибка: индекс " << index << " вне диапазона!" << endl;
        static int dummy = 0;
        return dummy;
    }
}

const int& Array::operator[](int index) const {
    if (index >= 0 && index < size) {
        return data[index];
    }
    else {
        cout << "Ошибка: индекс " << index << " вне диапазона!" << endl;
        static int dummy = 0;
        return dummy;
    }
}

void Array::operator()(int value) {
    for (int i = 0; i < size; i++) {
        data[i] += value;
    }
    cout << "Все элементы увеличены на " << value << endl;
}

Array::operator int() const {
    int sum = 0;
    for (int i = 0; i < size; i++) {
        sum += data[i];
    }
    return sum;
}


Array::operator char* () const {
    int length = 0;
    for (int i = 0; i < size; i++) {
        int num = data[i];
        if (num == 0) length++;
        while (num != 0) {
            length++;
            num /= 10;
        }
        length += 2; 
    }
    length += 2; 

    char* str = new char[length];
    str[0] = '\0';

    strcat_s(str, length, "[ ");
    for (int i = 0; i < size; i++) {
        char numStr[20];
        sprintf_s(numStr, "%d", data[i]);
        strcat_s(str, length, numStr);
        if (i < size - 1) {
            strcat_s(str, length, ", ");
        }
    }
    strcat_s(str, length, " ]");

    return str;
}

void Array::fillArray() {
    cout << "Введите " << size << " элементов:" << endl;
    for (int i = 0; i < size; i++) {
        cout << "  [" << i << "] = ";
        cin >> data[i];
    }
}

void Array::fillValue(int value) {
    for (int i = 0; i < size; i++) data[i] = value;
    cout << "Массив заполнен значением " << value << endl;
}

void Array::setElement(int index, int value) {
    if (index >= 0 && index < size) {
        data[index] = value;
    }
    else {
        cout << "Ошибка: индекс " << index << " вне диапазона!" << endl;
    }
}

int Array::getElement(int index) const {
    if (index >= 0 && index < size) {
        return data[index];
    }
    else {
        cout << "Ошибка: индекс " << index << " вне диапазона!" << endl;
        return 0;
    }
}

void Array::printArray() const {
    cout << "[ ";
    for (int i = 0; i < size; i++) {
        cout << data[i];
        if (i < size - 1) cout << ", ";
    }
    cout << " ]" << endl;
}

void Array::resize(int newSize) {
    if (newSize <= 0) {
        cout << "Ошибка: размер должен быть > 0!" << endl;
        return;
    }
    int* newData = new int[newSize];
    int copySize = (newSize < size) ? newSize : size;
    for (int i = 0; i < copySize; i++) newData[i] = data[i];
    for (int i = copySize; i < newSize; i++) newData[i] = 0;
    delete[] data;
    data = newData;
    size = newSize;
    cout << "Размер изменён на " << size << endl;
}

void Array::sortAscending() {
    sort(data, data + size);
    cout << "Отсортировано по возрастанию" << endl;
}


void Array::sortDescending() {
    sort(data, data + size, greater<int>());
    cout << "Отсортировано по убыванию" << endl;
}


int Array::getMin() const {
    if (size == 0) return 0;
    int min = data[0];
    for (int i = 1; i < size; i++)
        if (data[i] < min) min = data[i];
    return min;
}


int Array::getMax() const {
    if (size == 0) return 0;
    int max = data[0];
    for (int i = 1; i < size; i++)
        if (data[i] > max) max = data[i];
    return max;
}

void Array::assign(const Array& other) {
    if (this != &other) {
        delete[] data;
        copyArray(other);
    }
    cout << "Выполнено присваивание" << endl;
}