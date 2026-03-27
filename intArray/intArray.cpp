#include "intArray.h"
intArray::intArray() : data(nullptr), size(0) {
	cout << "Использован конструктор по умолчанию" << endl;
}

intArray::intArray(size_t n) : size(n) {
	if (n > 0) {
		data = new int[n];
		for (int i = 0; i < n; i++) {
			data[i] = 0;
		}
		cout << "Создан массив размером " << n << endl;
	}
	else {
		data = nullptr;
		size = 0;
	}
}

intArray::intArray(const intArray& other)
	: size(other.size) {
	if (other.data != nullptr) {
		data = new int[size];

		for (int i = 0; i < size; i++) {
			data[i] = other.data[i];
		}
	}
	else {
		data = nullptr;
	}
	cout << "Использован конструктор копирования" << endl;
}

intArray::intArray(intArray&& other) noexcept
	: data(other.data), size(other.size) {
	other.data = nullptr;
	other.size = 0;

	cout << "Использован конструктор перемещения" << endl;
}

intArray::~intArray() {
	delete[] data;
	cout << "Использован деструктор" << endl;
}

intArray& intArray::operator=(const intArray& other) {
	if (this == &other) {
		return *this;
	}

	delete[] data;

	size = other.size;

	if (other.data != nullptr) {
		data = new int[size];

		for (int i = 0; i < size; i++) {
			data[i] = other.data[i];
		}
	}
	else {
		data = nullptr;
	}
	return *this;
}

intArray& intArray::operator=(intArray&& other) noexcept {
	if (this == &other) {
		return *this;
	}

	delete[] data;

	data = other.data;
	size = other.size;

	other.data = nullptr;
	other.size = 0;

	return *this;
}

void intArray::print() const {
	cout << "Массив: " << endl;
	for (int i = 0; i < size; i++) {
		cout << data[i] << " ";
	}
	cout << endl;
}

int intArray::getElement(size_t index) const {
	if (index >= size) {
		cout << "Индекс " << index << " вне диапозона" << endl;
		return 0;
	}
	return data[index];
}

void intArray::setElement(size_t index, int value) {
	if (index >= size) {
		cout << "Индекс " << index << " вне диапозона" << endl;
		return;
	}
	data[index] = value;
}