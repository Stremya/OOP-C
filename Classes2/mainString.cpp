#include <iostream>
#include "String.h"

using namespace std;

int main() {
	setlocale(LC_ALL, "ru");

	String str1("Привет, мир!");
	str1.printString();

	String len(30);

	String str2 = str1;
	str2.printString();

	len.setPoint("Привет, мирок маленький");
	len.printString();
	return 0;
}