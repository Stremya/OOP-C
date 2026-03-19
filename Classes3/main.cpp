#include <iostream>
#include <windows.h>
#include "Book.h"
#include "Worker.h"
using namespace std;

/* 
int main1() {
	setlocale(LC_ALL, "ru");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	Book books;
	vector<Book> array = books.createBooks();

	for (const auto& book : array) {
		book.printBooks();
	}

	books.printBooksByAuthor(array);
	books.printBooksByProduction(array);
	books.printBooksByYear(array);

	return 0;
}

*/

static int main2() {
	setlocale(LC_ALL, "ru");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	Worker workers;
	vector<Worker> array = workers.createWorker();

	for (const auto& worker : array) {
		worker.printWorker();
	}

	workers.printWorkerByYear(array);
	workers.printWorkerBySalary(array);
	workers.printWorkerByPost(array);

	return 0;
}

