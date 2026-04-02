#include <iostream>
#include "StringHolder.h"
#include "Interfaces.h"
#include "Vehicle.h"
using namespace std;


//int main() {
//    setlocale(LC_ALL, "ru");
//
//    cout << "=== Удаление через указатель на базу ===" << endl;
//    StringHolder* ptr1 = new StringHolder("Hello");
//    ptr1->print();
//    delete ptr1;  
//
//    cout << "\n=== Удаление ReverseString через базу ===" << endl;
//    StringHolder* ptr2 = new ReverseString("World");
//    ptr2->print();  
//    delete ptr2;    
//
//    cout << "\n=== Полиморфизм ===" << endl;
//    StringHolder* holders[] = {
//        new StringHolder("Привет"),
//        new ReverseString("Мир"),
//        new StringHolder("C++")
//    };
//
//    for (auto holder : holders) {
//        holder->print();
//    }
//
//    cout << "\nУдаление:" << endl;
//    for (auto holder : holders) {
//        delete holder;  
//    }
//
//    return 0;
//}

//int main() {
//    setlocale(LC_ALL, "ru");
//
//    cout << "=== Вектор Drawable ===" << endl;
//    vector<Drawable*> drawables;
//
//    drawables.push_back(new Circle(10, 20, 5));
//    drawables.push_back(new Rectangle(0, 0, 30, 15));
//    drawables.push_back(new Circle(5, 5, 3));
//
//    for (const auto& drawable : drawables) {
//        drawable->draw();  
//    }
//
//    cout << "\n=== Вектор Serializable ===" << endl;
//    vector<Serializable*> serializables;
//
//    serializables.push_back(new Circle(10, 20, 5));
//    serializables.push_back(new Rectangle(0, 0, 30, 15));
//
//    for (const auto& serializable : serializables) {
//        cout << "Serialized: " << serializable->serialize() << endl;
//    }
//
//    cout << "\n=== dynamic_cast между интерфейсами ===" << endl;
//    Drawable* dPtr = new Circle(100, 200, 10);
//    dPtr->draw();
//
//    
//    Serializable* sPtr = dynamic_cast<Serializable*>(dPtr);
//    if (sPtr) {
//        cout << "dynamic_cast успешен: " << sPtr->serialize() << endl;
//    }
//    else {
//        cout << "dynamic_cast не удался" << endl;
//    }
//
//    Drawable* dPtr2 = dynamic_cast<Drawable*>(sPtr);
//    if (dPtr2) {
//        cout << "✓ Обратный cast успешен" << endl;
//    }
//
//    delete dPtr;
//
//    cout << "\n=== Очистка памяти ===" << endl;
//    for (auto d : drawables) delete d;
//    for (auto s : serializables) delete s;
//
//    return 0;
//}

int main() {
    setlocale(LC_ALL, "ru");

    cout << "=== Полиморфизм через Vehicle* ===" << endl;
    vector<Vehicle*> vehicles;

    vehicles.push_back(new Vehicle());
    vehicles.push_back(new Car());
    vehicles.push_back(new ElectricCar());
    vehicles.push_back(new SportsCar());
    vehicles.push_back(new Bicycle());

    for (size_t i = 0; i < vehicles.size(); i++) {
        cout << "\n--- Транспорт " << (i + 1) << " ---" << endl;
        vehicles[i]->startEngine();
        cout << "Max speed: " << vehicles[i]->getMaxSpeed() << " km/h" << endl;
        vehicles[i]->info();
    }

    cout << "\n=== Прямые вызовы ===" << endl;
    ElectricCar ec;
    ec.startEngine();
    cout << "Max speed: " << ec.getMaxSpeed() << " km/h" << endl;
    ec.info();

    cout << "\n=== Очистка ===" << endl;
    for (auto v : vehicles) {
        delete v;
    }

    return 0;
}