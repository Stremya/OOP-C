#pragma once
#include <vector>
#include "Human.h"
class Flat
{
private:
	vector<Human> human; // человек
	int number; // номер 
	char* condition; // состояние

	void copyString(char*& dest, const char* src);
public:
	Flat(int num, const char* cond);

	Flat();

	Flat(const Flat& flat);

	~Flat();

	void addHuman(const int id, const char* sn, const char* n, const char* p, int d);

	void printFlat() const;
};

