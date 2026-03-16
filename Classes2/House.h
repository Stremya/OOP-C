#pragma once
#include "Flat.h"
class House
{
private:
	vector<Flat> flat; // квартира
	int number; // номер
	char* street; // улица

	void copyString(char*& dest, const char* src);
public:
	House(int num, const char* stre);

	House();

	House(const House& house);

	~House();

	void addFlat(int num, const char* cond);

	void addHumanToFlat(int flatIndex, const int id, const char* sn,
		const char* n, const char* p, int d);
 
	void printHouse() const;
};

