#include "String.h"

void String::copyString(char*& dest, const char* src) {
	if (src == nullptr) src = "";
	size_t len = strlen(src);
	dest = new char[len + 1];
	strcpy_s(dest, len + 1, src);
}

String::String(const char* p) {
	copyString(this->point, p);
	length = strlen(p);
}

String::String(size_t len) : length(len) {
	point = new char[len + 1];
	point[0] = '\0';
}

String::String(const String& object) : length(object.length) {
	copyString(this->point, object.point);
}

String::~String() {
	delete[] point;
}

void String::printString() const {
	cout << point << endl;
}

String& String::setPoint(const char* p) {
	size_t newLen = strlen(p);

	if (newLen > length) {
		delete[] point;
		point = new char[newLen + 1];
		length = newLen;
	}
	
	strcpy_s(point, length+1, p);
	return *this;
}

