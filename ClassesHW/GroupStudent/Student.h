#pragma once
#include <string>
#include <vector>
#include "Subject.h"
using namespace std;
class Student
{
private:
	string name; // Имя студента
	
	vector<int> marks; // Список оценок
public:
	Student();

	Student(const string n, int mC, int* m)
		: name(n) {
		for (int i = 0; i < mC; ++i) {
			marks.push_back(m[i]);	
		}
	}

	~Student() {}

	const string getName() const { return name; }
	const vector<int>& getMarks() const { return marks; }

	void setName(const string name);
	void setMarks(const int* marks, int count);
	 
};

