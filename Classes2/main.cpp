#include <iostream>
#include "House.h"

using namespace std;

int main() {
	setlocale(LC_ALL, "ru");
	House house1(46, "Дегтерева");
	house1.addFlat(6, "Нормальное");

	house1.addHumanToFlat(0, 4, "Жакин", "Артем", "Андреевич", 2008);
	house1.addHumanToFlat(0, 5, "Халиулин", "Алексей", "Алексеевич", 1988);

	house1.printHouse();

	return 0;
}