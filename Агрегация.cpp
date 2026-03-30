#include <iostream>
#include <vector>
#include <string>
using namespace std;

class Student {
private:
    string name;
    int id;
public:
    Student(int i, const string& n) : id(i), name(n) {
        cout << "Студент '" << name << "' (ID:" << id << ") создан" << endl;
    }

    ~Student() {
        cout << "Студент '" << name << "' (ID:" << id << ") удален" << endl;
    }

    void print() const {
        cout << "  [ID:" << id << "] " << name << endl;
    }

    int getId() const { return id; }
};

class University {
private:
    string name;
    vector<Student*> students;  
public:
    University(const string& n) : name(n) {
        cout << "\nУниверситет '" << name << "' открыт" << endl;
    }

    ~University() {
        cout << "Университет '" << name << "' закрыт" << endl;
    }

    void enrollStudent(Student* student) {
        students.push_back(student); 
    }

    void printStudents() const {
        cout << "\nСтуденты в " << name << ":" << endl;
        for (const auto& student : students) {
            student->print();
        }
    }

    size_t getStudentCount() const {
        return students.size();
    }
};

int main() {
    setlocale(LC_ALL, "ru");

    
    Student s1(1, "Иванов");
    Student s2(2, "Петров");
    Student s3(3, "Сидоров");

    
    University uni("МГУ");

       
    uni.enrollStudent(&s1);
    uni.enrollStudent(&s2);
    uni.enrollStudent(&s3);

    uni.printStudents();

    
    

    
    s1.print();
    s2.print();
    s3.print();

   

    return 0;
}