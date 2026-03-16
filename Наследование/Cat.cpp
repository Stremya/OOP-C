#include "Cat.h"

int Cat::countCat = 0;

Cat::Cat(const string& n, int a, const string& c) : name(n), age(a), color(c) {
	countCat++;
	cout << "Текущее количество объектов: " << getCountCat() << endl;
}

Cat::~Cat() {
	cout << "Котик " << name << " был УНИЧТОЖЕН" << endl;
	countCat--;
	cout << "Текущее количество объектов: " << getCountCat() << endl;
}

void Cat::printInfo() const {
	cout << "Кошка:" << endl;
	cout << "Имя: " << name << endl;
	cout << "Возраст: " << age << endl;
	cout << "Окрас: " << color << endl;
	cout << endl;
}

void Cat::sound() const {
	cout << name << " гврит аааааааа" << endl;
	cout << endl;
}

HouseCat::HouseCat(const string& n, int a, const string& c, const string& owner)
	: Cat(n, a, c), ownerCat(owner) {
}

HouseCat::~HouseCat() {}

void HouseCat::printInfo() const {
	cout << "Домашняя Кошка:" << endl;
	cout << "Имя: " << name << endl;
	cout << "Возраст: " << age << endl;
	cout << "Окрас: " << color << endl;
	cout << "Хозяин: " << ownerCat << endl;
	cout << endl;

}

void HouseCat::sound() const {
	cout << name << " гврит еееееееее" << endl;
}

void HouseCat::play() const {
	cout << name << " играет" << endl;
	cout << endl;
}

WildCat::WildCat(const string& n, int a, const string& c, const string& hab)
	: Cat(n, a, c), habitat(hab) {}

WildCat::~WildCat() {}

void WildCat::printInfo() const {
	cout << "Дикая Кошка:" << endl;
	cout << "Имя: " << name << endl;
	cout << "Возраст: " << age << endl;
	cout << "Окрас: " << color << endl;
	cout << "Среда обитания: " << habitat << endl;
	cout << endl;
}

void WildCat::sound() const {
	cout << name << " гврит ыыыыыыыыыыы" << endl;
}

void WildCat::hunt() const {
	cout << name << " охотиться" << endl;
	cout << endl;

}

PersianCat::PersianCat(const string& n, int a, const string& c, int wLen)
	: Cat(n, a, c), woolLength(wLen) {}

PersianCat::~PersianCat() {}

void PersianCat::printInfo() const {
	cout << "Персидская Кошка:" << endl;
	cout << "Имя: " << name << endl;
	cout << "Возраст: " << age << endl;
	cout << "Окрас: " << color << endl;
	cout << "Длина шерсти: " << woolLength << endl;
	cout << endl;
}

void PersianCat::sound() const {
	cout << name << " гврит ууууууууууууу" << endl;
}

void PersianCat::groom() const {
	cout << name << " нуждается в уходе" << endl;
	cout << endl;
}