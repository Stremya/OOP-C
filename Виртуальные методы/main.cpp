#include <iostream>
#include <vector>
#include "Animal.h"
using namespace std;

int main() {
    setlocale(LC_ALL, "ru");

    vector<Animal*> animals;

    animals.push_back(new Dog());
    animals.push_back(new Cat());
    animals.push_back(new Cow());
    animals.push_back(new Horse());
    animals.push_back(new Dog());
    animals.push_back(new Cat());

    cout << "Вызов метода speak() для каждого животного:" << endl;
    for (size_t i = 0; i < animals.size(); i++) {
        cout << "Животное " << (i + 1) << ": ";
        animals[i]->speak();  
    }

    cout << "\n=== Освобождение памяти ===" << endl;
    for (size_t i = 0; i < animals.size(); i++) {
        delete animals[i];  
    }
    animals.clear();

    cout << "Память успешно освобождена!" << endl;

    return 0;
}