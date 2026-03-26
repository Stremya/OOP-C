#pragma once
#include <iostream>
#include <vector>
using namespace std;
class SetOfInt {
private:
	int* elements;
	int size;

	bool affiliation(int val) const;
public:
	SetOfInt(int arr[], int n);

	SetOfInt();

	SetOfInt(const SetOfInt& soi);

	~SetOfInt() {
		delete[] elements;
	}

	// Добавление элемента
	SetOfInt operator+(int val) const;

	// Добавление элемента
	SetOfInt& operator+=(int val);

	// Объединение множеств
	SetOfInt operator+(const SetOfInt& other) const;

	// Объединение множеств
	SetOfInt& operator+=(const SetOfInt& other);

	// Удаление элемента
	SetOfInt operator-(int val) const;

	// Удаление элемента
	SetOfInt& operator-=(int val);

	// Разность множеств
	SetOfInt operator-(const SetOfInt& other) const;

	// Разность множеств
	SetOfInt& operator-=(const SetOfInt& other);

	SetOfInt operator*(const SetOfInt& other) const;

	SetOfInt& operator*=(const SetOfInt& other) const;

	SetOfInt& operator=(const SetOfInt& other);

	bool operator==(const SetOfInt& other) const;

	friend ostream& operator<<(ostream& os, const SetOfInt& other);

	friend istream& operator>>(istream& is, SetOfInt& other);

	bool belongs(int val) const;
};