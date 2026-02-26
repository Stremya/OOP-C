#pragma once
#include <string>
using namespace std;

class Subject
{
private:
	string name; // Название предмета
public:
	Subject();

	Subject(const string name);

	~Subject() {}

	const string getName() const { return name; }

	void setName(const string name);

};

