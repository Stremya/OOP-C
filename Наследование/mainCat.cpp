#include <iostream>
#include <string>
#include "Cat.h"
using namespace std;

int main() {
	setlocale(LC_ALL, "ru");
	Cat cat1("Борис", 5, "Белый");
	cat1.printInfo();
	cat1.sound();

	HouseCat houseCat1("Барсик", 7, "Серый", "Леша");
	houseCat1.printInfo();
	houseCat1.sound();
	houseCat1.play();

	WildCat wildCat1("Вася", 3, "Бежевый", "Лес");
	wildCat1.printInfo();
	wildCat1.sound();
	wildCat1.hunt();

	PersianCat persianCat1("Альберт", 6, "Желтый", 10);
	persianCat1.printInfo();
	persianCat1.sound();
	persianCat1.groom();

	return 0;
}