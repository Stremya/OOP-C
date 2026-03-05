#pragma once
using namespace std;
class Student
{
private:
	char* name; // ФИО студента
	char* date; // Дата
	long long number; // Номер
	char* city; // Город студента
	char* country; // Страна студента
	char* school_name; // Название школы
	char* school_city; // Город школы
	char* school_country; // Страна школы
	char* group; // Группа

	static int objectCount; // Подсчет объект

	void copyString(char*& dest, const char* src);
public:
	Student();

	Student(const char* n);

	Student(const char* n, const char* d, long long num);

	Student(const char* n, const char* d, long long num, const char* c, const char* coun,
		const char* s_n, const char* s_c, const char* s_coun, const char* g);

	~Student();

	const char* getName() const { return name; }
	const char* getDate() const { return date; }
	long long getNumber() const { return number; }
	const char* getCity() const { return city; }
	const char* getCountry() const { return country; }
	const char* getSchool_name() const { return school_name; }
	const char* getSchool_city() const { return school_city; }
	const char* getSchool_country() const { return school_country; }
	const char* getGroup() const { return group; }

	void setName(const char* name);
	void setDate(const char* date);
	void setNumber(long long number);
	void setCity(const char* city);
	void setCountry(const char* country);
	void setSchool_name(const char* school_name);
	void setSchool_city(const char* school_city);
	void setSchool_country(const char* school_country);
	void setGroup(const char* group);
	// методы
	void enterStudent();
	void printStudent() const;

	static int getObjectCount() { return objectCount; }

};