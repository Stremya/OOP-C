#include "Flat.h"
#include <cmath>
void Flat::addRoom(const Room& room) {
	rooms.push_back(room);
}

int Flat::calculateRolls(const WallpaperRoll& wallpaper) const {
	double totalArea = 0;
	for (const auto& room : rooms) {
		totalArea += room.calculateRoomArea();
	}
	return ceil(totalArea / wallpaper.getArea());
}

double Flat::calculateTotalPrice(const WallpaperRoll& wallpaper) const {
	return calculateRolls(wallpaper) * wallpaper.getPrice();
}