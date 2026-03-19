#pragma once
#include <iostream>
#include <string>
#include <vector>
using namespace std;
class Book
{
private:
	string author; // Автор
	string name; // Название
	string production; // Издательство
	int year; // Год
	int pagesCount; // Количество страниц
public:
	explicit Book(const string au, const string n, const string prod, int y, int pC);

	Book();

	Book(const Book& book);

	~Book() {}

	// Создание массивов
	static vector<Book> createBooks();
	// Вывод
	void printBooks() const;

	// Вывод книг по автору
	static void printBooksByAuthor(vector<Book>& books);

	// Вывод книг по издательству
	static void printBooksByProduction(vector<Book>& books);

	// Вывод книг по году
	static void printBooksByYear(vector<Book>& books);
};

