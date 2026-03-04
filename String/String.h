#pragma once
class String
{
private:
	char* str;
	size_t length;
	static int objectCount;
public:
	String();

	String(size_t len);

	String(const char* s);

	~String();

	// Ввод строк
	void enterString();

	// Вывод строк
	void printString() const;

	// Метод для подсчета объектов
	static int getObjectCount();

	const char* getStr() const { return str; }
	size_t gerLength() const { return length; }
};



