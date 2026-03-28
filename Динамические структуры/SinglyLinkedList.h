#pragma once
#include <iostream>
#include <stdexcept>
using namespace std;

template<typename T>
class SinglyLinkedList
{
private:
    // Вложенная структура узла
    struct Node {
        T data;
        Node* next;

        Node(const T& value) : data(value), next(nullptr) {}
    };

    Node* head;        // указатель на голову списка
    size_t listSize;   // размер списка

public:
    // Конструктор по умолчанию
    SinglyLinkedList();

    // Деструктор
    ~SinglyLinkedList();

    // Запрет копирования и присваивания
    SinglyLinkedList(const SinglyLinkedList&) = delete;
    SinglyLinkedList& operator=(const SinglyLinkedList&) = delete;

    // Вставка в начало
    void push_front(const T& value);

    // Вставка в конец
    void push_back(const T& value);

    // Удаление первого элемента
    void pop_front();

    // Удаление последнего элемента
    void pop_back();

    // Доступ к первому элементу
    T& front();

    const T& front() const;

    // Доступ к последнему элементу
    T& back();

    const T& back() const;

    // Проверка на пустоту
    bool empty() const;

    // Получение размера
    size_t size() const;

    // Очистка списка
    void clear();

    // вывод
    void print() const;
};

