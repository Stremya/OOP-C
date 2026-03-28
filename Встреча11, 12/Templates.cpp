#include <iostream>
#include <cmath>
#include <vector>
using namespace std;

// задание 1
template<typename T>
T average(const vector<T>& vec) {
    T sum = T();
    for (size_t i = 0; i < vec.size(); i++) {
        sum += vec[i];
    }
    return sum / vec.size();
}

//Задание 2 
// Линейное уравнение: a*x + b = 0
template<typename T>
T solveLinear(T a, T b) {
    if (a == T()) {
        cout << "Ошибка: a не может быть 0!" << endl;
        return T();
    }
    return -b / a;
}

// Квадратное уравнение: a*x² + b*x + c = 0
template<typename T>
int solveQuadratic(T a, T b, T c, T& x1, T& x2) {
    if (a == T()) {
        x1 = -b / c;
        return 1;
    }

    T discriminant = b * b - 4 * a * c;

    if (discriminant < T()) {
        return 0; 
    }
    else if (discriminant == T()) {
        x1 = -b / (2 * a);
        return 1;  
    }
    else {
        T sqrtD = sqrt(discriminant);
        x1 = (-b + sqrtD) / (2 * a);
        x2 = (-b - sqrtD) / (2 * a);
        return 2;  
    }
}

// Задание 3
template<typename T>
T Max(T a, T b) {
    return (a > b) ? a : b;
}

// Задание 4
template<typename T>
T Min(T a, T b) {
    return (a < b) ? a : b;
}

int main() {
    setlocale(LC_ALL, "ru");

    cout << "Задание 1" << endl;

    vector<int> vec = { 10, 20, 30 };
    cout << "\nvector<int>: {10, 20, 30}" << endl;
    cout << "Среднее: " << average(vec) << endl;

    cout << "\nЗадание 2" << endl;

    cout << "Линейное: 2x + 4 = 0" << endl;
    cout << "x = " << solveLinear(2.0, 4.0) << endl;

    cout << "\nКвадратное: x² - 5x + 6 = 0" << endl;
    double x1, x2;
    int roots = solveQuadratic(1.0, -5.0, 6.0, x1, x2);
    if (roots == 0) {
        cout << "Нет действительных корней" << endl;
    }
    else if (roots == 1) {
        cout << "Один корень: x = " << x1 << endl;
    }
    else {
        cout << "Два корня: x₁ = " << x1 << ", x₂ = " << x2 << endl;
    }

    cout << "\nКвадратное: x² - 4x + 4 = 0" << endl;
    roots = solveQuadratic(1.0, -4.0, 4.0, x1, x2);
    if (roots == 1) {
        cout << "Один корень: x = " << x1 << endl;
    }

    cout << "\nКвадратное: x² + 1 = 0" << endl;
    roots = solveQuadratic(1.0, 0.0, 1.0, x1, x2);
    if (roots == 0) {
        cout << "Нет действительных корней" << endl;
    }

    cout << "\nЗадание 3" << endl;
    cout << "max(5, 10) = " << Max(5, 10) << endl;
    cout << "max(3.14, 2.71) = " << Max(3.14, 2.71) << endl;
    cout << "max('a', 'z') = " << Max('a', 'z') << endl;

    cout << "\nЗадание 4" << endl;
    cout << "min(5, 10) = " << Min(5, 10) << endl;
    cout << "min(3.14, 2.71) = " << Min(3.14, 2.71) << endl;
    cout << "min('a', 'z') = " << Min('a', 'z') << endl;

    return 0;
}