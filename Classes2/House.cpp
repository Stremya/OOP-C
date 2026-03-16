#include "House.h"

void House ::copyString(char*& dest, const char* src) {
	if (src == nullptr) src = "";
	size_t len = strlen(src);
	dest = new char[len + 1];
	strcpy_s(dest, len + 1, src);
}

House::House(int num, const char* stre) : number(num) {
	copyString(street, stre);
}

House::House() : House(1, "Неизвестно") {}

House::House(const House& house) : number(house.number) {
	copyString(street, house.street);
}

House::~House() {
	delete[] street;
}

void House::addFlat(int num, const char* cond) {
	flat.push_back(Flat(num, cond));
}

void House::addHumanToFlat(int flatIndex, const int id, const char* sn,
	const char* n, const char* p, int d) {
	if (flatIndex >= 0 && flatIndex < flat.size()) {
		flat[flatIndex].addHuman(id, sn, n, p, d);
	}
	else {
		cout << "Ошибка: квартира " << flatIndex << " не существует!" << endl;
	}
}

void House::printHouse() const {
	cout << "=================================" << endl;

	for (int i = 0; i < flat.size(); i++) {
		cout << "Номер дома " << number << endl;
		cout << "Улица: " << street << endl;
		flat[i].printFlat();
	}
}