#include "Student.h"
#include "Group.h"
#include <iostream>
Student::Student() {
	name = "Неизвестно"; 
}

void Student::setName(const string n) {
	if (n == "") {
		name = "Неизвестно";
		return;
	}
	name = n;
}

void Student::setMarks(const int* m, int count) {
	marks.clear();
	for (int i = 0; i < count; ++i) {
		marks.push_back(m[i]);
	}
}