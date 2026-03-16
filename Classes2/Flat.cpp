#include "Flat.h"

void Flat::copyString(char*& dest, const char* src) {
	if (src == nullptr) src = "";
	size_t len = strlen(src);
	dest = new char[len + 1];
	strcpy_s(dest, len + 1, src);
}

Flat::Flat(int num, const char* cond) : number(num) {
	copyString(condition, cond);
}

Flat::Flat() : Flat(1, "Неизвестно") {}

Flat::Flat(const Flat& flat) : number(flat.number) {
	copyString(condition, flat.condition);
}

Flat::~Flat() {
	delete[] condition;
}

void Flat::addHuman(const int id, const char* sn, const char* n, const char* p, int d) {
	human.push_back(Human(id, sn, n, p, d));
}

void Flat::printFlat() const {
	cout << "===================================" << endl;
	for (int i = 0; i < human.size(); i++) {
		cout << "	Квартира номер " << number << endl;
		cout << "	Состояние: " << condition << endl;
		cout << "	[" << i+1 << "]";
		human[i].printHuman();
		cout << endl;
	}

}