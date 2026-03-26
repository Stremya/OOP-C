#include <iostream>
#include "Date.h"

using namespace std;

int main() {
	setlocale(LC_ALL, "ru");

	Date date1(12, 4, 2020);
	Date date2(25, 6, 2015);
	long long diff = date1 - date2;

	cout << date1;
	cout << endl;
	cout << date2;
	cout << endl;
	cout << "Разница между датами: " << diff << " дня" << endl;

	return 0;
}