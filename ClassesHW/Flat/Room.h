#pragma once
#include <string>
using namespace std;

class Room
{
private:
	string name;
	double length; // длина комнаты
	double width; // ширина комнаты
	double heigth; // высота комнаты
	bool needGlue; // нужен клей на потолок?
public:
	//  онструктор
	Room(string name, double length, double width, double heigth,
		bool needGlue);

	// ‘ункци€ дл€ расчета площади стен
	double calculateRoomArea() const;
};

