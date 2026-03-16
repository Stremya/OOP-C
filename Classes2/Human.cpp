#include "Human.h"

int Human::countHuman = 0;

void Human::copyString(char*& dest, const char* src) {
	if (src == nullptr) src = "";          
	size_t len = strlen(src);                
	dest = new char[len + 1];            
	strcpy_s(dest, len + 1, src);        
}

Human::Human(const int id, const char* sn, const char* n, const char* p, int d)
	: id(id), date(d) {
	copyString(this->surname, sn);
	copyString(this->name, n);
	copyString(this->patronymic, p);
	countHuman++;
}

Human::Human()
	: Human(1, "Неизвестно", "Неизвестно", "Неизвестно", 1970) {}

Human::Human(const Human& human)
	: id(human.id), date(human.date) {
	copyString(this->surname, human.surname);
	copyString(this->name, human.name);
	copyString(this->patronymic, human.patronymic);
	countHuman++;
}

Human::~Human() {
	delete[] surname;
	delete[] name;
	delete[] patronymic;
}

Human& Human::setId(int id) {
	this->id = id;
	return *this;
}

Human& Human::setSurname(const char* sn) {
	delete[] surname;
	copyString(this->surname, sn);
	return *this;
}

Human& Human::setName(const char* n) {
	delete[] name;
	copyString(this->name, n);
	return *this;
}

Human& Human::setPatronymic(const char* p) {
	delete[] patronymic;
	copyString(this->patronymic, p);
	return *this;
}

Human& Human::setDate(int d) {
	this->date = d;
	return *this;
}

void Human::printHuman() const {
	cout << "		-------Человек-------" << endl;
	cout << "		ID: " << this->id << endl;
	cout << "		Фамилия: " << this->surname << endl;
	cout << "		Имя: " << this->name << endl;
	cout << "		Отчество: " << this->patronymic << endl;
	cout << "		Дата рождения: " << this->date << endl;
}