using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace practice
{
    // Делегаты для управления гонкой
    public delegate void RaceEventHandler(string message);
    public delegate void CarActionDelegate();

    // Класс аргументов события финиша
    public class FinishEventArgs : EventArgs
    {
        public string CarName { get; set; }        // название автомобиля
        public string CarType { get; set; }        // тип автомобиля
        public double FinishTime { get; set; }     // время финиша

        public FinishEventArgs(string carName, string carType, double finishTime)
        {
            CarName = carName;
            CarType = carType;
            FinishTime = finishTime;
        }
    }

    // Абстрактный класс «Автомобиль» (Car)
    public abstract class Car
    {
        public string Name { get; set; }               // название автомобиля
        public string Model { get; set; }              // модель автомобиля
        public double MaxSpeed { get; set; }           // максимальная скорость
        public double MinSpeed { get; set; }           // минимальная скорость
        public double CurrentSpeed { get; set; }       // текущая скорость
        public double Distance { get; set; }           // пройденное расстояние
        public double Position { get; set; }           // позиция от 0 до 100
        public int SpeedBoostChance { get; set; }      // шанс ускорения (в процентах)
        public double SpeedBoostMultiplier { get; set; } // множитель ускорения
        public string CarType { get; set; }            // тип автомобиля

        // События автомобиля
        public event EventHandler<FinishEventArgs> Finished;  // событие финиша
        public event EventHandler<string> StatusChanged;      // событие изменения статуса

        protected Random random;                       // генератор случайных чисел

        public Car(string name, string model, double maxSpeed, double minSpeed,
                  int speedBoostChance, double speedBoostMultiplier, string carType)
        {
            Name = name;
            Model = model;
            MaxSpeed = maxSpeed;
            MinSpeed = minSpeed;
            SpeedBoostChance = speedBoostChance;
            SpeedBoostMultiplier = speedBoostMultiplier;
            CarType = carType;
            CurrentSpeed = 0;
            Distance = 0;
            Position = 0;
            random = new Random(Guid.NewGuid().GetHashCode());
        }

        // Метод для вызова события финиша
        protected virtual void OnFinished()
        {
            if (Finished != null)
            {
                Finished(this, new FinishEventArgs(Name, CarType, Distance / CurrentSpeed));
            }
        }

        // Метод для вызова события изменения статуса
        protected virtual void OnStatusChanged(string message)
        {
            if (StatusChanged != null)
            {
                StatusChanged(this, message);
            }
        }

        // Абстрактный метод для движения автомобиля
        public abstract void Move();

        // Метод для выхода на старт
        public void TakeStartPosition()
        {
            Position = 0;
            Distance = 0;
            CurrentSpeed = 0;
            OnStatusChanged($"{Name} ({CarType}) вышел на стартовую позицию");
        }

        // Метод для обновления скорости
        protected void UpdateSpeed()
        {
            // Случайное изменение скорости в заданных пределах
            double speedChange = (random.NextDouble() * 2 - 1) * 10; // от -10 до +10
            CurrentSpeed = MinSpeed + random.NextDouble() * (MaxSpeed - MinSpeed) + speedChange;

            // Ограничение скорости
            if (CurrentSpeed < MinSpeed)
                CurrentSpeed = MinSpeed;
            if (CurrentSpeed > MaxSpeed)
                CurrentSpeed = MaxSpeed;

            // Шанс на ускорение (форсаж)
            if (random.Next(100) < SpeedBoostChance)
            {
                double boostedSpeed = CurrentSpeed * SpeedBoostMultiplier;
                if (boostedSpeed <= MaxSpeed * 1.2) // не больше 120% от максимальной
                {
                    CurrentSpeed = boostedSpeed;
                    OnStatusChanged($"{Name} использует ускорение! Скорость: {CurrentSpeed:F1} км/ч");
                }
            }
        }

        // Обновление позиции
        protected void UpdatePosition()
        {
            Distance += CurrentSpeed * 0.1; // 0.1 часа = 6 минут
            Position = Math.Min(100, Distance); // ограничение до 100
        }

        // Вывод информации об автомобиле
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{Name} ({CarType}): {Model}");
            Console.WriteLine($"  Скорость: {MinSpeed}-{MaxSpeed} км/ч");
            Console.WriteLine($"  Шанс ускорения: {SpeedBoostChance}%");
            Console.WriteLine($"  Множитель ускорения: {SpeedBoostMultiplier}x");
        }
    }

    // Класс Спортивный автомобиль
    public class SportsCar : Car
    {
        public bool TurboMode { get; set; }            // режим турбо
        public double Aerodynamics { get; set; }       // коэффициент аэродинамики

        public SportsCar(string name, string model)
            : base(name, model, 320, 180, 30, 1.5, "Спортивный")
        {
            TurboMode = false;
            Aerodynamics = 0.3;
        }

        public override void Move()
        {
            UpdateSpeed();

            // Спортивные авто имеют дополнительный шанс на турбо-режим
            if (random.Next(100) < 15 && !TurboMode)
            {
                TurboMode = true;
                CurrentSpeed *= 1.3;
                OnStatusChanged($"{Name} активирует ТУРБО-РЕЖИМ! Скорость: {CurrentSpeed:F1} км/ч");
            }

            if (TurboMode && random.Next(100) < 40)
            {
                TurboMode = false;
                OnStatusChanged($"{Name} турбо-режим отключён");
            }

            UpdatePosition();
        }
    }

    // Класс Легковой автомобиль
    public class PassengerCar : Car
    {
        public int PassengerCount { get; set; }        // количество пассажиров
        public bool AirConditioner { get; set; }       // кондиционер включен

        public PassengerCar(string name, string model)
            : base(name, model, 220, 120, 20, 1.3, "Легковой")
        {
            PassengerCount = random.Next(1, 5);
            AirConditioner = false;
        }

        public override void Move()
        {
            UpdateSpeed();

            // Легковые авто стабильны, меньше случайных изменений
            if (random.Next(100) < 10)
            {
                CurrentSpeed += random.NextDouble() * 15;
                if (CurrentSpeed > MaxSpeed)
                    CurrentSpeed = MaxSpeed;
                OnStatusChanged($"{Name} плавно ускоряется до {CurrentSpeed:F1} км/ч");
            }

            UpdatePosition();
        }
    }

    // Класс Грузовой автомобиль
    public class Truck : Car
    {
        public double CargoWeight { get; set; }        // вес груза в тоннах
        public bool HasTrailer { get; set; }           // наличие прицепа

        public Truck(string name, string model)
            : base(name, model, 140, 80, 10, 1.2, "Грузовой")
        {
            CargoWeight = random.Next(1, 20);
            HasTrailer = random.Next(2) == 0;
        }

        public override void Move()
        {
            // Грузовики медленнее, но стабильнее
            double cargoPenalty = 1 - (CargoWeight / 100); // штраф за вес груза
            if (cargoPenalty < 0.7) cargoPenalty = 0.7;

            CurrentSpeed = (MinSpeed + random.NextDouble() * (MaxSpeed - MinSpeed)) * cargoPenalty;

            if (HasTrailer)
                CurrentSpeed *= 0.9; // дополнительный штраф за прицеп

            if (CurrentSpeed < 60)
                CurrentSpeed = 60;

            UpdatePosition();
        }
    }

    // Класс Автобус
    public class Bus : Car
    {
        public int PassengerCapacity { get; set; }     // вместимость пассажиров
        public int CurrentPassengers { get; set; }     // текущее количество пассажиров
        public bool IsStopping { get; set; }           // совершает остановку

        public Bus(string name, string model)
            : base(name, model, 160, 90, 15, 1.4, "Автобус")
        {
            PassengerCapacity = 50;
            CurrentPassengers = random.Next(10, PassengerCapacity);
            IsStopping = false;
        }

        public override void Move()
        {
            UpdateSpeed();

            // Автобусы иногда останавливаются
            if (random.Next(100) < 8 && !IsStopping)
            {
                IsStopping = true;
                CurrentSpeed *= 0.3;
                OnStatusChanged($"{Name} замедляется для остановки");
            }

            if (IsStopping && random.Next(100) < 25)
            {
                IsStopping = false;
                OnStatusChanged($"{Name} продолжает движение");
            }

            UpdatePosition();
        }
    }

    // Класс игры «Гонки»
    public class RaceGame
    {
        public List<Car> Cars { get; set; }            // список автомобилей
        public double TrackLength { get; set; }        // длина трассы (100)
        public bool RaceFinished { get; set; }         // гонка завершена
        public Car Winner { get; set; }                // победитель
        public double RaceTime { get; set; }           // время гонки

        // События игры
        public event RaceEventHandler RaceEvent;        // событие гонки
        public event CarActionDelegate RaceStarted;     // событие старта гонки
        public event CarActionDelegate RaceFinished2;   // событие финиша гонки

        public RaceGame()
        {
            Cars = new List<Car>();
            TrackLength = 100;
            RaceFinished = false;
            Winner = null;
            RaceTime = 0;
        }

        // Метод для вызова события гонки
        protected virtual void OnRaceEvent(string message)
        {
            if (RaceEvent != null)
            {
                RaceEvent(message);
            }
        }

        // Добавление автомобиля в гонку
        public void AddCar(Car car)
        {
            // Подписка на событие финиша автомобиля
            car.Finished += Car_Finished;
            car.StatusChanged += Car_StatusChanged;
            Cars.Add(car);
        }

        // Обработчик события финиша автомобиля
        private void Car_Finished(object sender, FinishEventArgs e)
        {
            if (!RaceFinished)
            {
                RaceFinished = true;
                Winner = sender as Car;
                OnRaceEvent($"\n!!! ФИНИШ !!! {e.CarName} ({e.CarType}) первым пересёк финишную черту!");

                if (RaceFinished2 != null)
                {
                    RaceFinished2();
                }
            }
        }

        // Обработчик события изменения статуса автомобиля
        private void Car_StatusChanged(object sender, string message)
        {
            OnRaceEvent(message);
        }

        // Вывод всех автомобилей на старт
        public void PrepareRace()
        {
            OnRaceEvent("\n=== ПОДГОТОВКА К ГОНКЕ ===");

            foreach (Car car in Cars)
            {
                car.TakeStartPosition();
            }

            OnRaceEvent("Все автомобили на стартовых позициях!");

            if (RaceStarted != null)
            {
                RaceStarted();
            }
        }

        // Запуск гонки
        public void StartRace()
        {
            OnRaceEvent("\n=== ГОНКА НАЧАЛАСЬ! ===");
            OnRaceEvent($"Длина трассы: {TrackLength} условных единиц");
            OnRaceEvent($"Количество участников: {Cars.Count}\n");

            RaceTime = 0;
            int iteration = 0;
            int displayInterval = 3; // выводить информацию каждые 3 итерации

            while (!RaceFinished)
            {
                iteration++;
                RaceTime += 0.1;

                // Движение всех автомобилей
                foreach (Car car in Cars)
                {
                    if (!RaceFinished)
                    {
                        car.Move();

                        // Проверка на финиш
                        if (car.Position >= TrackLength)
                        {
                            car.Position = TrackLength;
                            // Событие финиша вызовется через механизм событий
                            if (!RaceFinished)
                            {
                                car.GetType().GetMethod("OnFinished",
                                    System.Reflection.BindingFlags.NonPublic |
                                    System.Reflection.BindingFlags.Instance)?.Invoke(car, null);
                            }
                        }
                    }
                }

                // Вывод текущего состояния гонки
                if (iteration % displayInterval == 0)
                {
                    DisplayRaceStatus();
                    Thread.Sleep(1000); // пауза 1 секунда для наглядности
                }
            }

            // Вывод окончательных результатов
            DisplayFinalResults();
        }

        // Отображение текущего состояния гонки
        private void DisplayRaceStatus()
        {
            Console.Clear();
            Console.WriteLine("=== АВТОМОБИЛЬНЫЕ ГОНКИ ===");
            Console.WriteLine($"Время гонки: {RaceTime:F1} ч.\n");
            Console.WriteLine("Трасса: Старт |------------------------------------| Финиш");
            Console.WriteLine();

            // Сортировка автомобилей по позиции (лидеры сверху)
            var sortedCars = Cars.OrderByDescending(c => c.Position).ToList();

            Console.WriteLine($"{"Позиция",-8} {"Автомобиль",-30} {"Скорость",-12} {"Прогресс",-40} {"Дистанция",-10}");
            Console.WriteLine(new string('-', 100));

            int place = 1;
            foreach (Car car in sortedCars)
            {
                // Создание визуального прогресс-бара
                int progressBars = (int)(car.Position / 2); // 50 символов на всю трассу
                string progressBar = new string('█', progressBars) + new string('░', 50 - progressBars);

                Console.WriteLine($"{place,-8} {car.Name,-30} {car.CurrentSpeed,6:F1} км/ч  {progressBar,-40} {car.Position,5:F1}%");
                place++;
            }
        }

        // Отображение финальных результатов
        private void DisplayFinalResults()
        {
            Console.Clear();
            Console.WriteLine("=== ГОНКА ЗАВЕРШЕНА! ===\n");

            // Сортировка по позиции
            var results = Cars.OrderByDescending(c => c.Position).ToList();

            Console.WriteLine("РЕЗУЛЬТАТЫ ГОНКИ:");
            Console.WriteLine(new string('=', 80));
            Console.WriteLine($"{"Место",-6} {"Автомобиль",-25} {"Тип",-12} {"Позиция",-10} {"Скорость",-10}");
            Console.WriteLine(new string('-', 80));

            int place = 1;
            foreach (Car car in results)
            {
                string medal = "";
                if (place == 1) medal = "🥇";
                else if (place == 2) medal = "🥈";
                else if (place == 3) medal = "🥉";

                Console.WriteLine($"{medal} {place,-3} {car.Name,-25} {car.CarType,-12} {car.Position,8:F1}%  {car.CurrentSpeed,8:F1} км/ч");
                place++;
            }

            Console.WriteLine(new string('=', 80));
            Console.WriteLine($"\nПОБЕДИТЕЛЬ: {Winner.Name} ({Winner.CarType})!");
            Console.WriteLine($"Время гонки: {RaceTime:F1} часов");
        }
    }

    class Program3
    {
        static void Main()
        {
            Console.WriteLine("=== АВТОМОБИЛЬНЫЕ ГОНКИ ===\n");

            // Создание игры
            RaceGame race = new RaceGame();

            // Подписка на события игры
            race.RaceEvent += message => Console.WriteLine(message);
            race.RaceStarted += () => Console.WriteLine("ВСЕ АВТОМОБИЛИ ГОТОВЫ К СТАРТУ!");
            race.RaceFinished2 += () => Console.WriteLine("ГОНКА ОКОНЧЕНА! ПОБЕДИТЕЛЬ ОПРЕДЕЛЁН!");

            // Создание автомобилей
            SportsCar ferrari = new SportsCar("Ferrari F40", "F40");
            SportsCar lamborghini = new SportsCar("Lamborghini Aventador", "Aventador");
            PassengerCar toyota = new PassengerCar("Toyota Camry", "Camry 2024");
            PassengerCar bmw = new PassengerCar("BMW M5", "M5 Competition");
            Truck kamaz = new Truck("КАМАЗ-54901", "54901 Neo");
            Truck man = new Truck("MAN TGX", "TGX 18.510");
            Bus paz = new Bus("ПАЗ-3205", "3205");
            Bus mercedes = new Bus("Mercedes-Benz Tourismo", "Tourismo");

            // Добавление автомобилей в гонку
            race.AddCar(ferrari);
            race.AddCar(lamborghini);
            race.AddCar(toyota);
            race.AddCar(bmw);
            race.AddCar(kamaz);
            race.AddCar(man);
            race.AddCar(paz);
            race.AddCar(mercedes);

            // Вывод информации об участниках
            Console.WriteLine("\nУЧАСТНИКИ ГОНКИ:");
            Console.WriteLine(new string('=', 50));
            foreach (Car car in race.Cars)
            {
                car.DisplayInfo();
                Console.WriteLine(new string('-', 50));
            }

            // Подготовка к гонке
            Console.WriteLine("\nНажмите любую клавишу для начала гонки...");
            Console.ReadKey();

            // Запуск гонки
            race.PrepareRace();
            Thread.Sleep(2000); // Пауза перед стартом

            race.StartRace();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}