#include "SinglyLinkedList.h"
template<typename T>
SinglyLinkedList<T>::Node::Node(const T& value)
    : data(value), next(nullptr) {
}

template<typename T>
SinglyLinkedList<T>::SinglyLinkedList()
    : head(nullptr), listSize(0) {
}

template<typename T>
SinglyLinkedList<T>::~SinglyLinkedList() {
    clear();
}

template<typename T>
void SinglyLinkedList<T>::push_front(const T& value) {
    Node* newNode = new Node(value);
    newNode->next = head;
    head = newNode;
    listSize++;
}

template<typename T>
void SinglyLinkedList<T>::push_back(const T& value) {
    Node* newNode = new Node(value);

    if (head == nullptr) {
        head = newNode;
    }
    else {
        Node* current = head;
        while (current->next != nullptr) {
            current = current->next;
        }
        current->next = newNode;
    }
    listSize++;
}


template<typename T>
void SinglyLinkedList<T>::pop_front() {
    if (head == nullptr) {
        throw out_of_range("Список пуст!");
    }

    Node* temp = head;
    head = head->next;
    delete temp;
    listSize--;
}

template<typename T>
void SinglyLinkedList<T>::pop_back() {
    if (head == nullptr) {
        throw out_of_range("Список пуст!");
    }

    if (head->next == nullptr) {
        delete head;
        head = nullptr;
    }
    else {
        Node* current = head;
        while (current->next->next != nullptr) {
            current = current->next;
        }
        delete current->next;
        current->next = nullptr;
    }
    listSize--;
}

template<typename T>
T& SinglyLinkedList<T>::front() {
    if (head == nullptr) {
        throw out_of_range("Список пуст!");
    }
    return head->data;
}

template<typename T>
const T& SinglyLinkedList<T>::front() const {
    if (head == nullptr) {
        throw out_of_range("Список пуст!");
    }
    return head->data;
}

template<typename T>
T& SinglyLinkedList<T>::back() {
    if (head == nullptr) {
        throw out_of_range("Список пуст!");
    }

    Node* current = head;
    while (current->next != nullptr) {
        current = current->next;
    }
    return current->data;
}

template<typename T>
const T& SinglyLinkedList<T>::back() const {
    if (head == nullptr) {
        throw out_of_range("Список пуст!");
    }

    Node* current = head;
    while (current->next != nullptr) {
        current = current->next;
    }
    return current->data;
}

template<typename T>
bool SinglyLinkedList<T>::empty() const {
    return listSize == 0;
}

template<typename T>
size_t SinglyLinkedList<T>::size() const {
    return listSize;
}

template<typename T>
void SinglyLinkedList<T>::clear() {
    while (head != nullptr) {
        Node* temp = head;
        head = head->next;
        delete temp;
    }
    listSize = 0;
}

template<typename T>
void SinglyLinkedList<T>::print() const {
    cout << "[";
    Node* current = head;
    while (current != nullptr) {
        cout << current->data;
        if (current->next != nullptr) {
            cout << ", ";
        }
        current = current->next;
    }
    cout << "]" << endl;
}