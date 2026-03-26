#pragma once
#include <iostream>
using namespace std;
class Date
{
private:
	int day;
	int month;
	long long year;

    // проверка високосного года
    static bool isLeap(int year) {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }

    // дней в месяце
    int daysInMonth(int m, int y) const {
        int days[] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        if (m == 2 && isLeap(y)) return 29;
        return days[m - 1];
    }

    // Преобразовать дату в общее количество дней
    long long toDateDays() const;

    // Преобразовать количество дней в дату
    static Date fromDays(long long totalDays);
public:
	Date(int day, int month, long long year);

	Date();

	~Date() {}

	long long operator-(const Date& other) const;

	friend ostream& operator<<(ostream& os, const Date& other);
	friend istream& operator>>(istream& is, Date& other);
};

