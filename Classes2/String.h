#pragma once
#include <iostream>
using namespace std;

class String
{
private:
	size_t length;
	char* point;

	void copyString(char*& dest, const char* src);
public:
	String(const char* p);

	String(size_t len);

	String(const String& object);

	~String();

	void printString() const;

	String& setPoint(const char* p);
};

