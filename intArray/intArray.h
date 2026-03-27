#pragma once
#include <iostream>
using namespace std;
class intArray
{
private:
	int* data;
	size_t size;
public:
	intArray();

	intArray(size_t n);

	intArray(const intArray& other);

	intArray(intArray&& other) noexcept;

	~intArray();

	intArray& operator=(const intArray& other);

	intArray& operator=(intArray&& other) noexcept;

	void print() const;

	int getElement(size_t index) const;
	void setElement(size_t index, int value);
};

