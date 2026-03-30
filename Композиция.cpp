#include <iostream>
#include <vector>
#include <string>
using namespace std;

class Room {
private:
    string name;
    double area;
public:
    Room(const string& n, double a) : name(n), area(a) {
        cout << "Комната '" << name << "' создана" << endl;
    }

    ~Room() {
        cout << "Комната '" << name << "' удалена" << endl;
    }

    void print() const {
        cout << "  " << name << " (" << area << " м²)" << endl;
    }
};

class House {
private:
    string address;
    vector<Room> rooms; 
public:
    House(const string& addr) : address(addr) {
        cout << "\nДом по адресу '" << address << "' построен" << endl;
    }

    ~House() {
        cout << "Дом '" << address << "' снесен" << endl;
    }

    void addRoom(const string& name, double area) {
        rooms.push_back(Room(name, area));  
    }

    void print() const {
        cout << "\nДом: " << address << endl;
        cout << "Комнаты:" << endl;
        for (const auto& room : rooms) {
            room.print();
        }
    }
};

int main() {
    setlocale(LC_ALL, "ru");

    
    House house("ул. Ленина, 10");
    house.addRoom("Гостиная", 25.5);
    house.addRoom("Спальня", 15.0);
    house.addRoom("Кухня", 12.0);

    house.print();

    
 
    return 0;
}