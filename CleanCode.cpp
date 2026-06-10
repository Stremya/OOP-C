#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <limits>

// Осмысленные имена и инкапсуляция данных
struct Task {
    std::string description;
    int priority;
};

// Разделение ответственности: класс для управления задачами
class TaskManager {
private:
    std::vector<Task> tasks;

    // Вспомогательная функция для безопасного ввода целого числа в диапазоне
    int getValidatedIntInput(const std::string& prompt, int minVal, int maxVal) const {
        int value;
        while (true) {
            std::cout << prompt;
            if (std::cin >> value && value >= minVal && value <= maxVal) {
                std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n'); // Очистка буфера
                return value;
            }
            std::cout << "Ошибка: введите число от " << minVal << " до " << maxVal << ".\n";
            std::cin.clear(); // Сброс флага ошибки
            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
        }
    }

    // Вспомогательная функция для безопасного ввода строки
    std::string getValidatedStringInput(const std::string& prompt, size_t maxLength) const {
        std::string input;
        while (true) {
            std::cout << prompt;
            std::getline(std::cin, input);

            if (input.length() <= maxLength && !input.empty()) {
                return input;
            }
            std::cout << "Ошибка: описание не должно быть пустым и превышать "
                << maxLength << " символов (текущая длина: " << input.length() << ").\n";
        }
    }

public:
    void addTask() {
        Task newTask;
        newTask.description = getValidatedStringInput("Введите описание задачи (макс. 199 символов): ", 199);
        newTask.priority = getValidatedIntInput("Введите приоритет задачи (1-5): ", 1, 5);

        tasks.push_back(std::move(newTask));
        std::cout << "Задача успешно добавлена.\n";
    }

    void sortTasksByPriorityDescending() {
        // Использование алгоритма STL вместо ручной сортировки
        // std::stable_sort сохраняет исходный порядок задач с одинаковым приоритетом
        std::stable_sort(tasks.begin(), tasks.end(), [](const Task& a, const Task& b) {
            return a.priority > b.priority; // Сортировка по убыванию
            });
    }

    void displayTasks() const {
        // Корректная обработка пустого списка
        if (tasks.empty()) {
            std::cout << "\nСписок задач пуст.\n";
            return;
        }

        std::cout << "\n--- Список задач (отсортирован по приоритету) ---\n";
        for (size_t i = 0; i < tasks.size(); ++i) {
            std::cout << i + 1 << ". [Приоритет: " << tasks[i].priority << "] "
                << tasks[i].description << "\n";
        }
        std::cout << "---------------------------------------------------\n";
    }

    size_t getTaskCount() const {
        return tasks.size();
    }
};

int main() {
    setlocale(LC_ALL, "ru");
    TaskManager manager;

    int taskCount = getValidatedIntInputStatic("Введите количество задач для добавления: ", 0, 1000);

    for (int i = 0; i < taskCount; ++i) {
        std::cout << "\n--- Добавление задачи " << i + 1 << " из " << taskCount << " ---\n";
        manager.addTask();
    }

    if (manager.getTaskCount() > 1) {
        manager.sortTasksByPriorityDescending();
    }

    manager.displayTasks();

    return 0;
}

// Вынесенная функция для ввода количества задач до создания объекта manager
int getValidatedIntInputStatic(const std::string& prompt, int minVal, int maxVal) {
    int value;
    while (true) {
        std::cout << prompt;
        if (std::cin >> value && value >= minVal && value <= maxVal) {
            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            return value;
        }
        std::cout << "Ошибка: введите число от " << minVal << " до " << maxVal << ".\n";
        std::cin.clear();
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }
}