#include "String.h"
#include <iostream>
using namespace std;
int String::objectCount = 0;

String::String() : length(80) {
	str = new char[length + 1];
	str[0] = '\0';
	objectCount++;
}

String::String(size_t len) : String() {
	delete[] str;
	length = len;
	str = new char[length + 1];
	str[0] = '\0';
}

String::String(const char* s) : String(strlen(s)) {
	strcpy_s(str, length + 1, s);
}

String::~String() {
	delete[] str;
	objectCount--;
}

void String::enterString() {
	cout << "Введите строку (макс. " << length << " символов): ";
	cin.getline(str, length + 1);
	length = strlen(str);
}

void String::printString() const {
	cout << "Строка: " << str << " (длина: " << length << ")" << endl;
}

int String::getObjectCount() {
	return objectCount;
}