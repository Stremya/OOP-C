#include "Group.h"
#include <iostream>
#include <iomanip>
#include <algorithm>
using namespace std;

Group::Group() {
    name = "";
}

void Group::setName(const string n) {
    if (n == "") {
        name = "Неизвестно";
    }
    name = n;
}

void Group::enterSubject() {
    int count;
    cout << "Сколько предметов? ";
    cin >> count;
    cin.ignore(numeric_limits<streamsize>::max(), '\n');

    for (int i = 0; i < count; ++i) {
        string name;
        cout << "Название предмета #" << (i + 1) << ": ";
        getline(cin, name);
        subjectList.push_back(Subject(name));
    }
}

void Group::enterStudent() {
    int count;
    cout << "Сколько студентов? ";
    cin >> count;
    cin.ignore(numeric_limits<streamsize>::max(), '\n');

    for (int i = 0; i < count; ++i) {
        cout << "\n--- Студент #" << (i + 1) << " ---" << endl;

        string name;
        cout << "Имя студента: ";
        getline(cin, name);

        int markCount = subjectList.size();
        cout << "Количество оценок (должно быть = " << markCount << "): ";
        int inputCount;
        cin >> inputCount;

        if (inputCount != markCount) {
            cout << "Предупреждение: будет использовано количество = " << markCount << endl;
        }

        int* marks = new int[markCount];
        for (int j = 0; j < markCount; ++j) {
            cout << "Оценка #" << (j + 1) << ": ";
            cin >> marks[j];
        }

        studentList.push_back(Student(name, markCount, marks));
        delete[] marks;
    }
}

void Group::printTable() const {
    if (studentList.empty() || subjectList.empty()) {
        cout << "Таблица пуста. Добавьте студентов и предметы." << endl;
        return;
    }

    cout << "\n===== Группа: " << name << " =====" << endl;

    // Шапка таблицы
    cout << left << setw(15) << "Студент";
    for (const auto& subject : subjectList) {
        cout << setw(12) << subject.getName();
    }
    cout << endl;

    // Разделитель
    cout << string(15 + subjectList.size() * 12, '-') << endl;

    // Данные студентов
    for (const auto& student : studentList) {
        cout << left << setw(15) << student.getName();
        const vector<int>& marks = student.getMarks();
        for (int i = 0; i < marks.size(); ++i) {
            cout << setw(12) << marks[i];
        }
        cout << endl;
    }
}

void Group::calculateAndPrintResults() const {
    // 1. Средние оценки студентов
    cout << "\n--- Средние оценки студентов ---" << endl;
    for (const auto& student : studentList) {
        double sum = 0;
        const vector<int>& marks = student.getMarks();
        for (int score : marks) {
            sum += score;
        }
        double avg = sum / marks.size();
        cout << student.getName() << ": " << fixed << setprecision(1) << avg << endl;
    }

    // 2. Средние оценки по предметам
    cout << "\n--- Средние оценки по предметам ---" << endl;
    for (size_t j = 0; j < subjectList.size(); ++j) {
        double sum = 0;
        for (const auto& student : studentList) {
            const vector<int>& marks = student.getMarks();
            sum += marks[j];
        }
        double avg = sum / studentList.size();
        cout << subjectList[j].getName() << ": " << fixed << setprecision(1) << avg << endl;
    }

    // 3. Средний балл группы
    cout << "\n--- Средний балл группы ---" << endl;
    double totalSum = 0;
    int totalMarks = 0;
    for (const auto& student : studentList) {
        const vector<int>& marks = student.getMarks();
        for (int score : marks) {
            totalSum += score;
        }
        totalMarks += marks.size();
    }
    double groupAvg = totalSum / totalMarks;
    cout << fixed << setprecision(1) << groupAvg << endl;

    // 4. Максимальные и минимальные оценки по предметам
    cout << "\n--- Максимальные и минимальные оценки по предметам ---" << endl;
    for (size_t j = 0; j < subjectList.size(); ++j) {
        int maxScore = 0;
        int minScore = 6;
        vector<string> maxStudents;
        vector<string> minStudents;

        for (const auto& student : studentList) {
            const vector<int>& marks = student.getMarks();
            int score = marks[j];

            if (score > maxScore) {
                maxScore = score;
                maxStudents.clear();
                maxStudents.push_back(student.getName());
            }
            else if (score == maxScore) {
                maxStudents.push_back(student.getName());
            }

            if (score < minScore) {
                minScore = score;
                minStudents.clear();
                minStudents.push_back(student.getName());
            }
            else if (score == minScore) {
                minStudents.push_back(student.getName());
            }
        }

        cout << subjectList[j].getName() << endl;
        cout << "  Максимум: " << maxScore << " (";
        for (size_t i = 0; i < maxStudents.size(); ++i) {
            cout << maxStudents[i];
            if (i < maxStudents.size() - 1) cout << ", ";
        }
        cout << ")" << endl;

        cout << "  Минимум: " << minScore << " (";
        for (size_t i = 0; i < minStudents.size(); ++i) {
            cout << minStudents[i];
            if (i < minStudents.size() - 1) cout << ", ";
        }
        cout << ")" << endl;
    }
}