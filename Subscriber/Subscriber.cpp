#define _CRT_SECURE_NO_WARNINGS
#include "Subscriber.h"
#include <cstring>  
#include <iostream>
#include <fstream>
using namespace std;

const char* const FILE_NAME = "Subscribers.txt";

void Subscriber::copyString(char*& dest, const char* src) {
    if (src == nullptr) src = "";          // защита от нулевого указателя
    size_t len = strlen(src);                // длина строки без '\0'
    dest = new char[len + 1];            // выделяем память (включая '\0')
    strcpy_s(dest, len + 1, src);        // безопасное копирование
}

Subscriber::Subscriber() {
    name = nullptr;
    surname = nullptr;
    patronymic = nullptr;
    information = nullptr;

    copyString(name, "Неизвестно");
    copyString(surname, "Неизвестно");
    copyString(patronymic, "Неизвестно");
    home_number = 11111;
    work_number = 11111;
    mobile_number = 11111;
    copyString(information, "");
}

Subscriber::Subscriber(const char* n, const char* sn, const char* p,
    long long h_num, long long w_num, long long m_num) {

    name = nullptr;
    surname = nullptr;
    patronymic = nullptr;
    information = nullptr;

    copyString(name, n);
    copyString(surname, sn);
    copyString(patronymic, p);
    setHome_number(h_num);
    setWork_number(w_num);
    setMobile_number(m_num);
    copyString(information, "");
}

Subscriber::Subscriber(const char* n, const char* sn, const char* p,
    long long h_num, long long w_num, long long m_num, const char* inf) {

    name = nullptr;
    surname = nullptr;
    patronymic = nullptr;
    information = nullptr;

    copyString(name, n);
    copyString(surname, sn);
    copyString(patronymic, p);
    setHome_number(h_num);
    setWork_number(w_num);
    setMobile_number(m_num);
    copyString(information, inf);
}

Subscriber::~Subscriber() {
    delete[] name;
    delete[] surname;
    delete[] patronymic;
    delete[] information;
}

void Subscriber::setName(const char* n) {
    delete[] name;
    copyString(name, n);
}

void Subscriber::setSurname(const char* sn) {
    delete[] surname;
    copyString(surname, sn);
}

void Subscriber::setPatronymic(const char* p) {
    delete[] patronymic;
    copyString(patronymic, p);
}

void Subscriber::setHome_number(long long h_num) {
    if (h_num < 11111) {
        home_number = 11111;
    }
    else {
        home_number = h_num;
    }
}

void Subscriber::setWork_number(long long w_num) {
    if (w_num < 11111) {
        work_number = 11111;
    }
    else {
        work_number = w_num;
    }
}

void Subscriber::setMobile_number(long long m_num) {
    if (m_num < 11111) {
        mobile_number = 11111;
    }
    else {
        mobile_number = m_num;
    }
}

void Subscriber::setInformation(const char* inf) {
    delete[] information;
    copyString(information, inf);
}

void Subscriber::enterSubscriber() {
    char name[250];
    char surname[250];
    char patronymic[250];
    long long home_number;
    long long work_number;
    long long mobile_number;
    char information[250];

    cout << endl;
    cin.ignore();
    cout << "Введите имя: ";
    cin.getline(name, 250);
    cout << "Введите фамилию: ";
    cin.getline(surname, 250);
    cout << "Введите отчество: ";
    cin.getline(patronymic, 250);
    cout << "Введите домашний номер: ";
    cin >> home_number;
    cout << "Введите рабочий номер: ";
    cin >> work_number;
    cout << "Введите мобильный номер: ";
    cin >> mobile_number;

    cin.ignore();

    cout << "Введите доп информацию: ";
    cin.getline(information, 250);

    setName(name);
    setSurname(surname);
    setPatronymic(patronymic);
    setHome_number(home_number);
    setWork_number(work_number);
    setMobile_number(mobile_number);
    setInformation(information);
}

void Subscriber::printSubscriber() const {
    cout << endl;
    cout << "Имя: " << name << endl;
    cout << "Фамилия: " << surname << endl;
    cout << "Отчество: " << patronymic << endl;
    cout << "Домашний номер: " << home_number << endl;
    cout << "Рабочий номер: " << work_number << endl;
    cout << "Мобильный номер: " << mobile_number << endl;
    cout << "Доп информация: " << information << endl;
    cout << endl;
}

void Subscriber::searchSubscriber() const {
    char n[250];
    cin.ignore();
    cout << "Введите имя абонента: ";
    cin.getline(n, 250);
    if (n == name) {
        cout << "Найден абонент" << endl;
        printSubscriber();
    }
    else {
        cout << "Абонент " << n << " не найден" << endl;
    }
}

void Subscriber::saveFile() const {
    ofstream file(FILE_NAME);

    if (file.is_open()) {
        file << (name ? name : "") << "|"
            << (surname ? surname : "") << "|"
            << (patronymic ? patronymic : "") << "|"
            << home_number << "|"
            << work_number << "|"
            << mobile_number << "|"
            << (information ? information : "") << "\n";
        file.close();
        cout << "Файл был сохранен в " << FILE_NAME << endl;
    }
    else {
        cerr << "Ошибка сохранения в файл" << endl;
    }
}

void Subscriber::loadFile() {
    ifstream file(FILE_NAME);
    if (!file.is_open()) {
        cerr << "Ошибка загрузки файла" << endl;
        return;
    }

    const int BUFFER_SIZE = 255;
    char buffer[BUFFER_SIZE];

    if (file.getline(buffer, BUFFER_SIZE)) {
        char* token = strtok(buffer, "|");
        if (token) setName(token);

        token = strtok(nullptr, "|");
        if (token) setSurname(token);

        token = strtok(nullptr, "|");
        if (token) setPatronymic(token);

        token = strtok(nullptr, "|");
        if (token) setHome_number(atoi(token));

        token = strtok(nullptr, "|");
        if (token) setWork_number(atoi(token));

        token = strtok(nullptr, "|");
        if (token) setMobile_number(atoi(token));

        token = strtok(nullptr, "|");
        if (token) setInformation(token);
    }
    file.close();
}

void Subscriber::menu() {
    int choice;
    cout << "-------Телефонная книга-------" << endl;
    do {
        cout << "1. Добавить абонент" << endl;
        cout << "2. Поиск абонента" << endl;
        cout << "3. Показать всех абонентов" << endl;
        cout << "0. Выход" << endl;
        cout << "Ваш выбор: ";
        cin >> choice;
        switch (choice) {
        case 1: {
            enterSubscriber();
            break;
        }
        case 2: {
            searchSubscriber();
            break;
        }
        case 3: {
            printSubscriber();
            break;
        }
        }
    } while (choice != 0);
}
