#pragma once
class Point
{
private:
	double x;
	double y;
	double z;
public:
	Point();
	
	Point(double x, double y, double z) 
		: x(x), y(y), z(z) { }

	~Point() {}

	double getX() const { return x; }
	double getY() const { return y; }
	double getZ() const { return z; }

	void setX(double x);
	void setY(double y);
	void setZ(double z);

	Point enterCoordinates();
	void printCoordinates() const;
	void saveToFile() const;
	bool loadFromFile();
};


