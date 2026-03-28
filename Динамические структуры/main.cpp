#include <iostream>
#include <string>
#include "SinglyLinkedList.h"
using namespace std;

int main() {
    setlocale(LC_ALL, "ru");

    cout << "=== ТЕСТЫ С int ===" << endl;

    SinglyLinkedList<int> intList;

    cout << "\n1. Проверка пустого списка:" << endl;
    cout << "Пуст? " << (intList.empty() ? "да" : "нет") << endl;
    cout << "Размер: " << intList.size() << endl;

    cout << "\n2. push_front (вставка в начало):" << endl;
    intList.push_front(30);
    intList.push_front(20);
    intList.push_front(10);
    intList.print();
    cout << "Размер: " << intList.size() << endl;

    cout << "\n3. push_back (вставка в конец):" << endl;
    intList.push_back(40);
    intList.push_back(50);
    intList.print();
    cout << "Размер: " << intList.size() << endl;

    cout << "\n4. front() и back():" << endl;
    cout << "Первый элемент: " << intList.front() << endl;
    cout << "Последний элемент: " << intList.back() << endl;

    cout << "\n5. pop_front (удаление первого):" << endl;
    intList.pop_front();
    intList.print();

    cout << "\n6. pop_back (удаление последнего):" << endl;
    intList.pop_back();
    intList.print();

    cout << "\n7. clear (очистка):" << endl;
    intList.clear();
    cout << "После очистки: ";
    intList.print();
    cout << "Пуст? " << (intList.empty() ? "да" : "нет") << endl;

    cout << "\n8. Обработка ошибок:" << endl;
    try {
        intList.pop_front();  
    }
    catch (const out_of_range& e) {
        cout << "Ошибка: " << e.what() << endl;
    }

    cout << "\n\n=== ТЕСТЫ С string ===" << endl;

    SinglyLinkedList<string> stringList;

    cout << "\n1. Добавление строк:" << endl;
    stringList.push_back("Привет");
    stringList.push_back("мир");
    stringList.push_back("C++");
    stringList.print();

    cout << "\n2. Вставка в начало:" << endl;
    stringList.push_front("Начало");
    stringList.print();

    cout << "\n3. Доступ к элементам:" << endl;
    cout << "Первый: " << stringList.front() << endl;
    cout << "Последний: " << stringList.back() << endl;

    cout << "\n4. Изменение элемента:" << endl;
    stringList.front() = "Изменено";
    cout << "После изменения: ";
    stringList.print();

    cout << "\n5. Удаление:" << endl;
    stringList.pop_front();
    stringList.pop_back();
    stringList.print();

    cout << "\n6. Размер: " << stringList.size() << endl;

    return 0;
}