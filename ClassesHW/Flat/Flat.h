#pragma once
#include <iostream>
#include <string>
#include <vector>

#include "WallpaperRoll.h"
#include "Room.h"
using namespace std;

class Flat {
private:
	vector<Room> rooms;
public:
	// Добавляет комнату
	void addRoom(const Room& room);
	// Расчитывает рулоны для всех комнат
	int calculateRolls(const WallpaperRoll& wallpaper) const;
	// Расчитывает цену
	double calculateTotalPrice(const WallpaperRoll& wallpaper) const;
};