#pragma once
#include <iostream>
#include <string>
#include <vector>
using namespace std;
class Worker
{
private:
	string name;
	string post;
	int year;
	long long salary;
public:
	explicit Worker(const string n, const string p, int y, long long s);

	Worker();

	Worker(const Worker& worker);

	~Worker() {}

	// Создает работника
	static vector<Worker> createWorker();
	
	// Вывод
	void printWorker() const;

	// Вывод списка работников по году поступления
	static void printWorkerByYear(vector<Worker> workers);

	// Вывод списка работников по зарплате
	static void printWorkerBySalary(vector<Worker> workers);

	// Вывод списка работников по должности
	static void printWorkerByPost(vector<Worker> workers);
};

