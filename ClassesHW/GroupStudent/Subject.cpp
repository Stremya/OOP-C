#include "Subject.h"
#include <iostream>

Subject::Subject() {
	name = "";
}

Subject::Subject(const string n) {
	setName(n);
}

void Subject::setName(const string n) {
	if (n == "") {
		name = "Неизвестно";
		return;
	}
	name = n;
}

