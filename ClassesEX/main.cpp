#include <iostream>
#include "Garage.h"
#include "Car.h"
#include "Bike.h"
using namespace std;

int main() {
    setlocale(LC_ALL, "ru");

    try {
        cout << "=== 1. Создание точек и транспорт ===" << endl;
        Point p1(10, 20);
        Point p2(10, 20);
        Point p3(10, 20);

        cout << "p1: " << p1 << endl;
        cout << "p1 == p2: " << (p1 == p2 ? "true" : "false") << endl;

        Vehicle* v1 = new Car("Toyota", 2020, p1, 4);
        Vehicle* v2 = new Bike("Yamaha", 2021, p2, "Sport");
        Vehicle* v3 = new Car("Honda", 2022, p3, 2);

        cout << "\n=== 2. Статистика объектов ===" << endl;
        cout << "Точек создано: " << Point::getPointCount() << endl;
        cout << "Транспорта создано: " << Vehicle::getTotalVehicles() << endl;

        cout << "\n=== 3. Гараж и цепочка вызовов ===" << endl;
        Garage<Vehicle*> garage(5);
        garage.add(v1).add(v2).add(v3);

        cout << "В гараже: " << garage.getCount() << " объектов" << endl;
        cout << "Гаражей создано: " << Garage<Vehicle*>::getTotalGarages() << endl;

        cout << "\n=== 4. Полиморфный вывод ===" << endl;
        for (int i = 0; i < garage.getCount(); i++) {
            garage[i]->print();
            cout << "Max Speed: " << garage[i]->getMaxSpeed() << endl;
        }

        cout << "\n=== 5. Перемещение и операторы Car ===" << endl;
        Point newLoc(100, 200);
        garage[0]->move(newLoc);
        cout << "После перемещения: ";
        garage[0]->print();

        Car* carPtr = dynamic_cast<Car*>(garage[0]);
        if (carPtr) {
            ++(*carPtr);
            cout << "После ++doors: ";
            carPtr->print();
        }

        cout << "\n=== 6. Копирование гаража (Глубокое) ===" << endl;
        Garage<Vehicle*> garageCopy = garage;
        garage[0]->move(Point(0, 0));

        cout << "Оригинал (позиция изменена):" << endl;
        garage[0]->print();
        cout << "Копия (позиция НЕ изменилась):" << endl;
        garageCopy[0]->print();

        cout << "\n=== 7. Объединение гаражей (+) ===" << endl;
        Garage<Vehicle*> garage2;
        garage2.add(new Bike("Ducati", 2022, Point(5, 5), "Racing"));

        Garage<Vehicle*> bigGarage = garage + garage2;
        cout << "Объединённый гараж: " << bigGarage.getCount() << " объектов" << endl;

        cout << "\n=== 8. Обработка исключений ===" << endl;
        try {
            cout << bigGarage[100]->getModel() << endl;
        }
        catch (const out_of_range& e) {
            cout << "❌ Ошибка: " << e.what() << endl;
        }

        cout << "\n=== 9. Финальная статистика ===" << endl;
        cout << "Всего точек: " << Point::getPointCount() << endl;
        cout << "Всего транспорта: " << Vehicle::getTotalVehicles() << endl;
        cout << "Всего гаражей: " << Garage<Vehicle*>::getTotalGarages() << endl;

        delete v1;
        delete v2;
        delete v3;

    }
    catch (...) {
        cout << "Неизвестная ошибка!" << endl;
    }

    cout << "\nПрограмма завершена." << endl;
    return 0;
}