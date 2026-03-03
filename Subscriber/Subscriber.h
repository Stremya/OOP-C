#pragma once

class Subscriber
{
private:
	char* name; // Имя
	char* surname; // Фамилия
	char* patronymic; // Отчество 
	long long home_number; // Домашнимй номер
	long long work_number; // Рабочий номер
	long long mobile_number; // Мобильный номер
	char* information; // Доп информация   

	void copyString(char*& dest, const char* src);
public:
	// Конструктор по умолчанию 
	Subscriber();

	Subscriber(const char* name, const char* surname, const char* patronymic,
		long long home_number, long long work_number, long long mobile_number);

	Subscriber(const char* name, const char* surname, const char* patronymic,
		long long home_number, long long work_number, long long mobile_number, const char* information);

	// Деструктор
	~Subscriber();

	const char* getName() const { return name; }
	const char* getSurname() const { return surname; }
	const char* getPatronymic() const { return patronymic; }
	int getHome_number() const { return home_number; }
	int getWork_number() const { return work_number; }
	int getMobile_number() const { return mobile_number; }
	const char* getInformation() const { return information; }

	void setName(const char* name);
	void setSurname(const char* surname);
	void setPatronymic(const char* patronymic);
	void setHome_number(long long home_number);
	void setWork_number(long long work_number);
	void setMobile_number(long long mobile_number);
	void setInformation(const char* information);

	// Меню
	void menu();

	// Добавление абонента
	void enterSubscriber();

	// Поиск абонента
	void searchSubscriber() const;

	// Выводит абонент
	void printSubscriber() const;

	// Сохранение в файл
	void saveFile() const;

	// Загрузка в файл
	void loadFile();
};



