#include <iostream>
#include <string>
using namespace std;

namespace Geometry {
    const double PI = 3.14159;

    double circleArea(double radius) {
        return PI * radius * radius;
    }

    double rectangleArea(double width, double height) {
        return width * height;
    }

    namespace Shapes {
        class Circle {
        private:
            double radius;
        public:
            Circle(double r) : radius(r) {}

            double area() const {
                return Geometry::circleArea(radius);
            }

            double getRadius() const { return radius; }
        };
    }
}

int main() {
    setlocale(LC_ALL, "ru");

    cout << "=== Полная квалификация ===" << endl;
    cout << "PI = " << Geometry::PI << endl;
    cout << "Площадь круга (r=5): "
        << Geometry::circleArea(5) << endl;
    cout << "Площадь прямоугольника (4x6): "
        << Geometry::rectangleArea(4, 6) << endl;

    Geometry::Shapes::Circle myCircle(10);
    cout << "Circle radius: " << myCircle.getRadius()
        << ", area: " << myCircle.area() << endl;

    cout << "\n=== Using declaration ===" << endl;
    using Geometry::PI;
    using Geometry::circleArea;

    cout << "PI = " << PI << endl;
    cout << "Площадь круга (r=3): " << circleArea(3) << endl;

    cout << "\n=== Using directive (локально) ===" << endl;
    {
        using namespace Geometry::Shapes;
        Circle c(7);
        cout << "Circle area: " << c.area() << endl;
    }

    return 0;
}