#include <iostream>
#include <windows.h>

#include "WallpaperRoll.h"
#include "Room.h"
#include "Flat.h"

using namespace std;
int main() {
	setlocale(LC_ALL, "ru");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	// Комнаты
	Room kitchen("Кухня", 12, 20, 20, false);
	Room bathroom("Ванная", 10, 14, 20, true);

	// Обои
	WallpaperRoll wallpaper("Обои", 0.40, 19.0, 245.0);

	// Создаем квартиру
	Flat flat;
	flat.addRoom(kitchen);
	flat.addRoom(bathroom);

	cout << "Нужно рулонов: " << flat.calculateRolls(wallpaper) << endl;
	cout << "Общая стоимость: " << flat.calculateTotalPrice(wallpaper) << endl;

	return 0;
}