#include "Date.h"
Date::Date(int d, int m, long long y) : day(d), month(m), year(y) {}

Date::Date() : Date(1, 1, 1970) {}

long long Date::toDateDays() const {
    long long y = year;
    long long m = month;
    long long d = day;

    if (m <= 2) {
        y--;
        m += 12;
    }

    return 365 * y + y / 4 - y / 100 + y / 400 + (153 * (m - 3) + 2) / 5 + d - 1;
}

Date Date::fromDays(long long totalDays) {
    long long y = totalDays / 365.2425;
    long long days = totalDays - (365 * y + y / 4 - y / 100 + y / 400);

    int m = 1;
    while (days > 31) {
        int dim = 31;
        if (m == 2) dim = 28 + (isLeap(y) ? 1 : 0);
        else if (m == 4 || m == 6 || m == 9 || m == 11) dim = 30;

        if (days > dim) {
            days -= dim;
            m++;
        }
        else {
            break;
        }
    }

    return Date(days, m, y);
}

long long Date::operator-(const Date& other) const {
	return toDateDays() - other.toDateDays();
}

ostream& operator<<(ostream& os, const Date& other) {
	os << "ƒата: ";
	os << other.day << "." << other.month << "." << other.year;
	return os;
}

istream& operator>>(istream& is, Date& other) {
	cout << "¬ведите день: ";
	is >> other.day;

	cout << "¬ведите мес€ц: ";
	is >> other.month;

	cout << "¬ведите год: ";
	is >> other.year;

	return is;
}

