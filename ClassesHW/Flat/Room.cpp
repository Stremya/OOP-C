#include "Room.h"

Room::Room(string n, double l, double w, double h, bool glue)
	: name(n), length(l), width(w), heigth(h), needGlue(glue) {}


double Room::calculateRoomArea() const {
	double walls = 2 * (length * heigth + width * heigth);
	if (needGlue) {
		walls += length * width;
	}
	return walls;
}