#include "Worker.h"

Worker::Worker(const string n, const string p, int y, long long s)
	: name(n), post(p), year(y), salary(s) {}

Worker::Worker() : Worker("Неизвестно", "Неизвестно", 0, 0) {}

Worker::Worker(const Worker& worker) : name(worker.name), post(worker.post),
	year(worker.year), salary(worker.salary) {}

vector<Worker> Worker::createWorker() {
	vector<Worker> worker;

	worker.push_back(Worker("Артем", "Джуниор", 2024, 60000));
	worker.push_back(Worker("Миша", "Мидл", 2020, 120000));
	worker.push_back(Worker("Кирилл", "Сеньор", 2015, 260000));

	return worker;
}

void Worker::printWorker() const {
	cout << "Имя: " << name << endl;
	cout << "Должность: " << post << endl;
	cout << "Год поступления: " << year << endl;
	cout << "Зарплата: " << salary << endl;
	cout << endl;
} 

void Worker::printWorkerByYear(vector<Worker> workers) {
	int searchYear;
	cout << "Введите год: ";
	cin >> searchYear;

	bool found = false;

	for (int i = 0; i < workers.size(); i++) {
		if (workers[i].year > searchYear) {
			workers[i].printWorker();
			found = true;
		}
	}

	if (!found) {
		cout << "Работники превосходящие " << searchYear << " год не найдены" << endl;
	}
}

void Worker::printWorkerBySalary(vector<Worker> workers) {
	long long searchSalary;
	cout << "Введите зарплату: ";
	cin >> searchSalary;

	bool found = false;

	for (int i = 0; i < workers.size(); i++) {
		if (workers[i].salary < searchSalary) {
			workers[i].printWorker();
			found = true;
		}
	}

	if (!found) {
		cout << "Работники превосходящие зарплату в размере " << searchSalary << " не найдены" << endl;
	}
}

void Worker::printWorkerByPost(vector<Worker> workers) {
	string searchPost;
	cout << "Введите должность: ";
	getline(cin, searchPost);

	bool found = false;

	for (int i = 0; i < workers.size(); i++) {
		if (workers[i].post == searchPost) {
			workers[i].printWorker();
			found = true;
		}
	}

	if (!found) {
		cout << "Работники должости " << searchPost << " не найдены" << endl;
	}
}