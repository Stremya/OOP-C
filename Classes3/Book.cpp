#include "Book.h"

Book::Book(const string au, const string n, const string prod,
	int y, int pC) : author(au), name(n), production(prod), year(y), pagesCount(pC) {}

Book::Book() : Book("Неизвестно", "Неизвестно", "Неизвестно", 2000, 0) {}

Book::Book(const Book& book) : author(book.author), name(book.name),
	production(book.production), year(book.year), pagesCount(book.pagesCount) {}

vector<Book> Book::createBooks() {
	vector<Book> books;

	books.push_back(Book("Эдуард Кочергин", "Крещённые крестами", "Penguin Random House", 2009, 50));
	books.push_back(Book("Михаил Шишкин", "Письмовник", "HarperCollins", 2010, 110));
	books.push_back(Book("Евгений Водолазкин", "Лавр", "Эксмо", 2012, 200));

	return books;
}

void Book::printBooks() const {
	cout << "Автор: " << author << endl;
	cout << "Название: " << name << endl;
	cout << "Издательство: " << production << endl;
	cout << "Год: " << year << endl;
	cout << "Количество страниц: " << pagesCount << endl;
	cout << endl;
}

void Book::printBooksByAuthor(vector<Book>& books) {
	string searchAuthor;
	cout << "Введите Имя и Фамилию автора: ";
	getline(cin, searchAuthor);

	bool found = false;

	for (int i = 0; i < books.size(); i++) {
		if (books[i].author == searchAuthor) {
			books[i].printBooks();
			found = true;
		}
	}

	if (!found) {
		cout << "Автор " << searchAuthor << " не найден" << endl;
	}
}

void Book::printBooksByProduction(vector<Book>& books) {
	string searchProduction;
	cout << "Введите издательство: ";
	getline(cin, searchProduction);

	bool found = false;

	for (int i = 0; i < books.size(); i++) {
		if (searchProduction == books[i].production) {
			books[i].printBooks();
			found = true;
		}
	}

	if (!found) {
		cout << "Издатель " << searchProduction << " не найден" << endl;
	}
}

void Book::printBooksByYear(vector<Book>& books) {
	int searchYear;
	cout << "Введите год выпуска: ";
	cin >> searchYear;

	bool found = false;

	for (int i = 0; i < books.size(); i++) {
		if (searchYear < books[i].year) {
			books[i].printBooks();
			found = true;
		}
	}

	if (!found) {
		cout << "Книги после " << searchYear << " не найдены" << endl;
	}
}