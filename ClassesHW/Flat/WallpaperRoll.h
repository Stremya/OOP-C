#pragma once
#include <string>
using namespace std;

class WallpaperRoll {
private:
    string name;
    double width;   // ширина рулона (м)
    double height;  // высота рулона (м)
    double price;   // цена за рулон

public:
    // Конструктор
    WallpaperRoll(string n, double w, double h, double p);

    double getArea() const { return width * height; } // Площадь рулона
    double getPrice() const { return price; }
};
