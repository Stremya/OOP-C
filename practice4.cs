using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    // Задание 1
    /*
    // Базовый класс Human (Человек)
    public class Human
    {
        public string FirstName { get; set; }      // имя
        public string LastName { get; set; }       // фамилия
        public int Age { get; set; }               // возраст
        public string Gender { get; set; }         // пол
        public string Nationality { get; set; }    // национальность

        public Human(string firstName, string lastName, int age, string gender, string nationality)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            Nationality = nationality;
        }

        // Метод для вывода информации о человеке
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ФИО: {FirstName} {LastName}");
            Console.WriteLine($"Возраст: {Age}, Пол: {Gender}");
            Console.WriteLine($"Национальность: {Nationality}");
        }

        // Метод для получения полного имени
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }

    // Производный класс Builder (Строитель)
    public class Builder : Human
    {
        public string Specialization { get; set; }     // специализация (каменщик, маляр и т.д.)
        public int Experience { get; set; }            // стаж работы в годах
        public string Category { get; set; }           // разряд
        public string ConstructionCompany { get; set; } // строительная компания

        public Builder(string firstName, string lastName, int age, string gender, string nationality,
                      string specialization, int experience, string category, string constructionCompany)
            : base(firstName, lastName, age, gender, nationality)
        {
            Specialization = specialization;
            Experience = experience;
            Category = category;
            ConstructionCompany = constructionCompany;
        }

        // Метод для начала строительства
        public void StartBuilding(string objectName)
        {
            Console.WriteLine($"{GetFullName()} начинает строительство объекта: {objectName}");
        }

        // Метод для завершения работы
        public void FinishWork()
        {
            Console.WriteLine($"{GetFullName()} завершил строительные работы");
        }

        // Метод для повышения разряда
        public void UpgradeCategory(string newCategory)
        {
            Category = newCategory;
            Console.WriteLine($"{GetFullName()} повысил разряд до {Category}");
        }

        // Переопределение метода вывода информации
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Профессия: Строитель");
            Console.WriteLine($"Специализация: {Specialization}");
            Console.WriteLine($"Стаж: {Experience} лет");
            Console.WriteLine($"Разряд: {Category}");
            Console.WriteLine($"Компания: {ConstructionCompany}");
        }
    }

    // Производный класс Sailor (Моряк)
    public class Sailor : Human
    {
        public string Rank { get; set; }               // звание
        public string ShipName { get; set; }           // название судна
        public string ShipType { get; set; }           // тип судна
        public int YearsAtSea { get; set; }            // лет в море
        public string PortOfRegistry { get; set; }     // порт приписки

        public Sailor(string firstName, string lastName, int age, string gender, string nationality,
                     string rank, string shipName, string shipType, int yearsAtSea, string portOfRegistry)
            : base(firstName, lastName, age, gender, nationality)
        {
            Rank = rank;
            ShipName = shipName;
            ShipType = shipType;
            YearsAtSea = yearsAtSea;
            PortOfRegistry = portOfRegistry;
        }

        // Метод для начала плавания
        public void SetSail(string destination)
        {
            Console.WriteLine($"{Rank} {GetFullName()} отправляется в плавание на {ShipType} '{ShipName}' в {destination}");
        }

        // Метод для возвращения в порт
        public void ReturnToPort()
        {
            Console.WriteLine($"{GetFullName()} вернулся в порт {PortOfRegistry}");
        }

        // Метод для смены судна
        public void ChangeShip(string newShipName, string newShipType)
        {
            ShipName = newShipName;
            ShipType = newShipType;
            Console.WriteLine($"{GetFullName()} переведён на {ShipType} '{ShipName}'");
        }

        // Переопределение метода вывода информации
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Профессия: Моряк");
            Console.WriteLine($"Звание: {Rank}");
            Console.WriteLine($"Судно: {ShipType} '{ShipName}'");
            Console.WriteLine($"Лет в море: {YearsAtSea}");
            Console.WriteLine($"Порт приписки: {PortOfRegistry}");
        }
    }

    // Производный класс Pilot (Летчик)
    public class Pilot : Human
    {
        public string LicenseNumber { get; set; }      // номер лицензии
        public string AircraftType { get; set; }       // тип воздушного судна
        public int FlightHours { get; set; }           // количество летных часов
        public string Airline { get; set; }            // авиакомпания
        public string Rank { get; set; }               // звание (капитан, второй пилот)

        public Pilot(string firstName, string lastName, int age, string gender, string nationality,
                    string licenseNumber, string aircraftType, int flightHours, string airline, string rank)
            : base(firstName, lastName, age, gender, nationality)
        {
            LicenseNumber = licenseNumber;
            AircraftType = aircraftType;
            FlightHours = flightHours;
            Airline = airline;
            Rank = rank;
        }

        // Метод для взлета
        public void TakeOff(string flightNumber)
        {
            Console.WriteLine($"{Rank} {GetFullName()} выполняет взлёт, рейс {flightNumber} на {AircraftType}");
        }

        // Метод для посадки
        public void Land(string airport)
        {
            Console.WriteLine($"{GetFullName()} совершил посадку в аэропорту {airport}");
        }

        // Метод для добавления летных часов
        public void AddFlightHours(int hours)
        {
            FlightHours += hours;
            Console.WriteLine($"{GetFullName()} налетал ещё {hours} часов. Общий налёт: {FlightHours} часов");
        }

        // Переопределение метода вывода информации
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Профессия: Лётчик");
            Console.WriteLine($"Лицензия: {LicenseNumber}");
            Console.WriteLine($"Тип ВС: {AircraftType}");
            Console.WriteLine($"Налёт: {FlightHours} часов");
            Console.WriteLine($"Авиакомпания: {Airline}");
            Console.WriteLine($"Должность: {Rank}");
        }
    }
    class Program1
    {
        static void Main()
        {
            Console.WriteLine("=== Задание 1: Наследование классов ===\n");

            // Создание строителя
            Builder builder = new Builder(
                "Иван", "Петров", 35, "Мужской", "Русский",
                "Каменщик", 10, "5-й разряд", "СтройТрест"
            );
            Console.WriteLine("Информация о строителе:");
            builder.DisplayInfo();
            builder.StartBuilding("Жилой комплекс 'Солнечный'");
            Console.WriteLine();

            // Создание моряка
            Sailor sailor = new Sailor(
                "Алексей", "Моряков", 28, "Мужской", "Русский",
                "Старший помощник", "Варяг", "Крейсер", 7, "Санкт-Петербург"
            );
            Console.WriteLine("Информация о моряке:");
            sailor.DisplayInfo();
            sailor.SetSail("Тихий океан");
            Console.WriteLine();

            // Создание лётчика
            Pilot pilot = new Pilot(
                "Сергей", "Летов", 40, "Мужской", "Русский",
                "PIL-12345", "Boeing 737", 8500, "Аэрофлот", "Капитан"
            );
            Console.WriteLine("Информация о лётчике:");
            pilot.DisplayInfo();
            pilot.TakeOff("SU-1234");
            Console.WriteLine();

            // Демонстрация полиморфизма
            Console.WriteLine("=== Демонстрация полиморфизма ===");
            Human[] people = new Human[] { builder, sailor, pilot };
            foreach (Human person in people)
            {
                Console.WriteLine($"\n--- {person.GetFullName()} ---");
                person.DisplayInfo();
            }

            Console.ReadKey();
        }
    }
    */

    // Задание 2
    /*
    // Структура для хранения информации о визе
    public struct Visa
    {
        public string Country { get; set; }        // страна
        public DateTime IssueDate { get; set; }    // дата выдачи
        public DateTime ExpiryDate { get; set; }   // дата окончания
        public string Type { get; set; }           // тип визы (туристическая, рабочая и т.д.)

        public Visa(string country, DateTime issueDate, DateTime expiryDate, string type)
        {
            Country = country;
            IssueDate = issueDate;
            ExpiryDate = expiryDate;
            Type = type;
        }

        // Проверка действительности визы
        public bool IsValid()
        {
            return DateTime.Now >= IssueDate && DateTime.Now <= ExpiryDate;
        }

        public override string ToString()
        {
            return $"{Country} ({Type}) - действует с {IssueDate:dd.MM.yyyy} по {ExpiryDate:dd.MM.yyyy}";
        }
    }

    // Базовый класс Passport (Паспорт)
    public class Passport
    {
        public string PassportNumber { get; set; }     // номер паспорта
        public string FirstName { get; set; }          // имя
        public string LastName { get; set; }           // фамилия
        public string Patronymic { get; set; }         // отчество
        public DateTime BirthDate { get; set; }        // дата рождения
        public string BirthPlace { get; set; }         // место рождения
        public string Gender { get; set; }             // пол
        public string IssuedBy { get; set; }           // кем выдан
        public DateTime IssueDate { get; set; }        // дата выдачи
        public string RegistrationAddress { get; set; } // адрес регистрации
        public string Country { get; set; }            // страна

        public Passport(string passportNumber, string firstName, string lastName,
                       string patronymic, DateTime birthDate, string birthPlace,
                       string gender, string issuedBy, DateTime issueDate,
                       string registrationAddress, string country)
        {
            PassportNumber = passportNumber;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            BirthDate = birthDate;
            BirthPlace = birthPlace;
            Gender = gender;
            IssuedBy = issuedBy;
            IssueDate = issueDate;
            RegistrationAddress = registrationAddress;
            Country = country;
        }

        // Метод для получения полного имени
        public string GetFullName()
        {
            return $"{LastName} {FirstName} {Patronymic}";
        }

        // Метод для проверки срока действия (внутренний паспорт)
        public virtual bool IsValid()
        {
            // Внутренний паспорт действует в зависимости от возраста
            int age = DateTime.Now.Year - BirthDate.Year;
            if (age < 20)
                return DateTime.Now < IssueDate.AddYears(5);
            else if (age < 45)
                return DateTime.Now < IssueDate.AddYears(10);
            else
                return true; // после 45 лет паспорт бессрочный
        }

        // Метод для вывода информации о паспорте
        public virtual void DisplayInfo()
        {
            Console.WriteLine("=== ПАСПОРТ ===");
            Console.WriteLine($"Номер: {PassportNumber}");
            Console.WriteLine($"ФИО: {GetFullName()}");
            Console.WriteLine($"Дата рождения: {BirthDate:dd.MM.yyyy}");
            Console.WriteLine($"Место рождения: {BirthPlace}");
            Console.WriteLine($"Пол: {Gender}");
            Console.WriteLine($"Выдан: {IssuedBy}");
            Console.WriteLine($"Дата выдачи: {IssueDate:dd.MM.yyyy}");
            Console.WriteLine($"Адрес регистрации: {RegistrationAddress}");
            Console.WriteLine($"Страна: {Country}");
            Console.WriteLine($"Статус: {(IsValid() ? "Действителен" : "Недействителен")}");
        }
    }

    // Производный класс ForeignPassport (Загранпаспорт)
    public class ForeignPassport : Passport
    {
        public string ForeignPassportNumber { get; set; }  // номер загранпаспорта
        public DateTime ForeignPassportExpiry { get; set; } // срок действия загранпаспорта
        public string IssuingAuthority { get; set; }       // орган выдавший загранпаспорт
        public List<Visa> Visas { get; set; }              // список виз
        public string BiometricData { get; set; }          // биометрические данные

        public ForeignPassport(string passportNumber, string firstName, string lastName,
                              string patronymic, DateTime birthDate, string birthPlace,
                              string gender, string issuedBy, DateTime issueDate,
                              string registrationAddress, string country,
                              string foreignPassportNumber, DateTime foreignPassportExpiry,
                              string issuingAuthority, string biometricData = "")
            : base(passportNumber, firstName, lastName, patronymic, birthDate, birthPlace,
                  gender, issuedBy, issueDate, registrationAddress, country)
        {
            ForeignPassportNumber = foreignPassportNumber;
            ForeignPassportExpiry = foreignPassportExpiry;
            IssuingAuthority = issuingAuthority;
            BiometricData = biometricData;
            Visas = new List<Visa>();
        }

        // Метод для добавления визы
        public void AddVisa(Visa visa)
        {
            Visas.Add(visa);
            Console.WriteLine($"Виза в {visa.Country} добавлена");
        }

        // Метод для удаления визы
        public void RemoveVisa(string country)
        {
            Visa visaToRemove = Visas.Find(v => v.Country == country);
            if (visaToRemove.Country != null)
            {
                Visas.Remove(visaToRemove);
                Console.WriteLine($"Виза в {country} удалена");
            }
        }

        // Метод для проверки наличия визы в страну
        public bool HasVisaTo(string country)
        {
            return Visas.Exists(v => v.Country == country && v.IsValid());
        }

        // Метод для получения списка действительных виз
        public List<Visa> GetValidVisas()
        {
            return Visas.FindAll(v => v.IsValid());
        }

        // Переопределение метода проверки срока действия
        public override bool IsValid()
        {
            return DateTime.Now <= ForeignPassportExpiry && base.IsValid();
        }

        // Метод для вывода всех виз
        public void DisplayVisas()
        {
            Console.WriteLine("\n=== ВИЗЫ ===");
            if (Visas.Count == 0)
            {
                Console.WriteLine("Виз нет");
                return;
            }

            foreach (Visa visa in Visas)
            {
                Console.WriteLine($"  {visa} {(visa.IsValid() ? "(действительна)" : "(недействительна)")}");
            }
        }

        // Переопределение метода вывода информации
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"\n=== ЗАГРАНПАСПОРТ ===");
            Console.WriteLine($"Номер загранпаспорта: {ForeignPassportNumber}");
            Console.WriteLine($"Срок действия до: {ForeignPassportExpiry:dd.MM.yyyy}");
            Console.WriteLine($"Выдан: {IssuingAuthority}");

            if (!string.IsNullOrEmpty(BiometricData))
            {
                Console.WriteLine($"Биометрические данные: {BiometricData}");
            }

            Console.WriteLine($"Статус: {(IsValid() ? "Действителен" : "Недействителен")}");

            DisplayVisas();
        }
    }

    class Program2
    {
        static void Main()
        {
            Console.WriteLine("=== Задание 2: Паспорт и загранпаспорт ===\n");

            // Создание обычного паспорта
            Passport passport = new Passport(
                "4512 123456",                    // номер паспорта
                "Иван",                           // имя
                "Иванов",                         // фамилия
                "Иванович",                       // отчество
                new DateTime(1990, 5, 15),        // дата рождения
                "г. Москва",                      // место рождения
                "Мужской",                        // пол
                "ОВД района Кунцево г. Москвы",  // кем выдан
                new DateTime(2010, 6, 20),        // дата выдачи
                "г. Москва, ул. Примерная, д. 1, кв. 1", // адрес регистрации
                "Россия"                          // страна
            );

            passport.DisplayInfo();
            Console.WriteLine();

            // Создание загранпаспорта
            ForeignPassport foreignPassport = new ForeignPassport(
                "4512 123456",                    // номер внутреннего паспорта
                "Иван",                           // имя
                "Иванов",                         // фамилия
                "Иванович",                       // отчество
                new DateTime(1990, 5, 15),        // дата рождения
                "г. Москва",                      // место рождения
                "Мужской",                        // пол
                "ОВД района Кунцево г. Москвы",  // кем выдан внутренний
                new DateTime(2010, 6, 20),        // дата выдачи внутреннего
                "г. Москва, ул. Примерная, д. 1, кв. 1", // адрес регистрации
                "Россия",                         // страна
                "75 1234567",                     // номер загранпаспорта
                new DateTime(2028, 12, 15),       // срок действия загранпаспорта
                "ФМС 77001",                      // орган выдавший загранпаспорт
                "Биометрический"                  // биометрические данные
            );

            // Добавление виз
            foreignPassport.AddVisa(new Visa("Италия",
                new DateTime(2024, 1, 15), new DateTime(2024, 7, 15), "Туристическая"));
            foreignPassport.AddVisa(new Visa("Китай",
                new DateTime(2024, 3, 1), new DateTime(2025, 3, 1), "Рабочая"));
            foreignPassport.AddVisa(new Visa("США",
                new DateTime(2023, 6, 1), new DateTime(2024, 6, 1), "Туристическая"));

            foreignPassport.DisplayInfo();

            // Проверка наличия визы
            Console.WriteLine($"\nНаличие визы в Италию: {foreignPassport.HasVisaTo("Италия")}");
            Console.WriteLine($"Наличие визы в Германию: {foreignPassport.HasVisaTo("Германия")}");

            // Получение действительных виз
            Console.WriteLine("\nДействительные визы:");
            List<Visa> validVisas = foreignPassport.GetValidVisas();
            foreach (Visa visa in validVisas)
            {
                Console.WriteLine($"  {visa.Country} - {visa.Type}");
            }

            Console.ReadKey();
        }
    }
    */

    // Задание 3
    /*
    // Базовый класс Animal (Животное)
    public class Animal
    {
        public string Name { get; set; }           // имя животного
        public string Species { get; set; }        // вид
        public double Weight { get; set; }         // вес в кг
        public double Height { get; set; }         // рост/длина в метрах
        public string Habitat { get; set; }        // среда обитания
        public string Diet { get; set; }           // тип питания

        public Animal(string name, string species, double weight, double height,
                     string habitat, string diet)
        {
            Name = name;
            Species = species;
            Weight = weight;
            Height = height;
            Habitat = habitat;
            Diet = diet;
        }

        // Метод для издавания звука
        public virtual void MakeSound()
        {
            Console.WriteLine($"{Name} издаёт звук");
        }

        // Метод для передвижения
        public virtual void Move()
        {
            Console.WriteLine($"{Name} передвигается");
        }

        // Метод для приёма пищи
        public virtual void Eat()
        {
            Console.WriteLine($"{Name} ест");
        }

        // Метод для сна
        public void Sleep()
        {
            Console.WriteLine($"{Name} спит");
        }

        // Метод для вывода информации о животном
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Имя: {Name}");
            Console.WriteLine($"Вид: {Species}");
            Console.WriteLine($"Вес: {Weight} кг, Размер: {Height} м");
            Console.WriteLine($"Среда обитания: {Habitat}");
            Console.WriteLine($"Тип питания: {Diet}");
        }
    }

    // Производный класс Tiger (Тигр)
    public class Tiger : Animal
    {
        public string StripePattern { get; set; }     // узор полос
        public bool IsAlpha { get; set; }             // является ли альфа-самцом
        public double TerritorySize { get; set; }     // размер территории в км²
        public int CubsCount { get; set; }            // количество детёнышей

        public Tiger(string name, double weight, double height,
                    string stripePattern, bool isAlpha, double territorySize)
            : base(name, "Тигр", weight, height, "Джунгли/Тайга", "Хищник")
        {
            StripePattern = stripePattern;
            IsAlpha = isAlpha;
            TerritorySize = territorySize;
            CubsCount = 0;
        }

        // Метод для охоты
        public void Hunt(string prey)
        {
            Console.WriteLine($"{Name} охотится на {prey}");
        }

        // Метод для рычания
        public void Roar()
        {
            Console.WriteLine($"{Name} громко рычит: РРРР!");
        }

        // Метод для защиты территории
        public void DefendTerritory()
        {
            Console.WriteLine($"{Name} защищает свою территорию ({TerritorySize} км²)");
        }

        // Переопределение метода издавания звука
        public override void MakeSound()
        {
            Roar();
        }

        // Переопределение метода передвижения
        public override void Move()
        {
            Console.WriteLine($"{Name} крадётся бесшумно, скрываясь в зарослях");
        }

        // Переопределение метода вывода информации
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Узор полос: {StripePattern}");
            Console.WriteLine($"Статус: {(IsAlpha ? "Альфа-самец" : "Обычный")}");
            Console.WriteLine($"Территория: {TerritorySize} км²");
            Console.WriteLine($"Детёнышей: {CubsCount}");
        }
    }

    // Производный класс Crocodile (Крокодил)
    public class Crocodile : Animal
    {
        public double JawStrength { get; set; }        // сила укуса в кг/см²
        public int TeethCount { get; set; }            // количество зубов
        public bool IsSaltwater { get; set; }          // морской или пресноводный
        public double UnderwaterTime { get; set; }     // время под водой в минутах

        public Crocodile(string name, double weight, double height,
                        double jawStrength, int teethCount, bool isSaltwater)
            : base(name, "Крокодил", weight, height,
                  isSaltwater ? "Море/Океан" : "Река/Озеро", "Хищник")
        {
            JawStrength = jawStrength;
            TeethCount = teethCount;
            IsSaltwater = isSaltwater;
            UnderwaterTime = 30;
        }

        // Метод для подводного плавания
        public void Submerge()
        {
            Console.WriteLine($"{Name} погружается под воду на {UnderwaterTime} минут");
        }

        // Метод для атаки из засады
        public void AmbushAttack()
        {
            Console.WriteLine($"{Name} атакует из засады с силой укуса {JawStrength} кг/см²!");
        }

        // Метод для греться на солнце
        public void Sunbathe()
        {
            Console.WriteLine($"{Name} греется на солнце для регуляции температуры");
        }

        // Переопределение метода издавания звука
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} издаёт низкий рёв и щёлкает челюстями");
        }

        // Переопределение метода передвижения
        public override void Move()
        {
            Console.WriteLine($"{Name} медленно ползёт или плывёт, едва заметный на поверхности");
        }

        // Переопределение метода вывода информации
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Сила укуса: {JawStrength} кг/см²");
            Console.WriteLine($"Количество зубов: {TeethCount}");
            Console.WriteLine($"Тип: {(IsSaltwater ? "Морской" : "Пресноводный")}");
            Console.WriteLine($"Время под водой: {UnderwaterTime} минут");
        }
    }

    // Производный класс Kangaroo (Кенгуру)
    public class Kangaroo : Animal
    {
        public double JumpLength { get; set; }         // длина прыжка в метрах
        public double JumpHeight { get; set; }         // высота прыжка в метрах
        public double PouchSize { get; set; }          // размер сумки в см
        public bool HasBaby { get; set; }              // есть ли детёныш в сумке
        public double Speed { get; set; }              // скорость в км/ч

        public Kangaroo(string name, double weight, double height,
                       double jumpLength, double jumpHeight, double pouchSize)
            : base(name, "Кенгуру", weight, height, "Саванна/Пустыня", "Травоядное")
        {
            JumpLength = jumpLength;
            JumpHeight = jumpHeight;
            PouchSize = pouchSize;
            HasBaby = false;
            Speed = 0;
        }

        // Метод для прыжка
        public void Jump()
        {
            Console.WriteLine($"{Name} прыгает на {JumpLength} метров в длину и {JumpHeight} метров в высоту!");
        }

        // Метод для бега
        public void Run()
        {
            Speed = 60;
            Console.WriteLine($"{Name} бежит со скоростью {Speed} км/ч");
        }

        // Метод для помещения детёныша в сумку
        public void PutBabyInPouch()
        {
            HasBaby = true;
            Console.WriteLine($"{Name} помещает детёныша в сумку размером {PouchSize} см");
        }

        // Метод для кормления
        public override void Eat()
        {
            Console.WriteLine($"{Name} щиплет траву и листья в саванне");
        }

        // Переопределение метода издавания звука
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} издаёт характерное цоканье и шипение");
        }

        // Переопределение метода передвижения
        public override void Move()
        {
            Console.WriteLine($"{Name} передвигается мощными прыжками, используя хвост для баланса");
        }

        // Переопределение метода вывода информации
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Длина прыжка: {JumpLength} м");
            Console.WriteLine($"Высота прыжка: {JumpHeight} м");
            Console.WriteLine($"Размер сумки: {PouchSize} см");
            Console.WriteLine($"Детёныш в сумке: {(HasBaby ? "Да" : "Нет")}");
        }
    }

    class Program3
    {
        static void Main()
        {
            Console.WriteLine("=== Задание 3: Животные ===\n");

            // Создание тигра
            Tiger tiger = new Tiger("Шерхан", 220, 1.2, "Уникальные поперечные полосы", true, 50);
            Console.WriteLine("Информация о тигре:");
            tiger.DisplayInfo();
            tiger.Hunt("оленя");
            tiger.Roar();
            Console.WriteLine();

            // Создание крокодила
            Crocodile crocodile = new Crocodile("Гена", 500, 4.5, 1500, 68, false);
            Console.WriteLine("Информация о крокодиле:");
            crocodile.DisplayInfo();
            crocodile.AmbushAttack();
            crocodile.Submerge();
            Console.WriteLine();

            // Создание кенгуру
            Kangaroo kangaroo = new Kangaroo("Кенни", 85, 1.8, 12, 3, 25);
            Console.WriteLine("Информация о кенгуру:");
            kangaroo.DisplayInfo();
            kangaroo.Jump();
            kangaroo.Run();
            kangaroo.PutBabyInPouch();
            Console.WriteLine();

            // Демонстрация полиморфизма
            Console.WriteLine("=== Демонстрация полиморфизма ===\n");
            Animal[] animals = new Animal[] { tiger, crocodile, kangaroo };

            foreach (Animal animal in animals)
            {
                Console.WriteLine($"\n--- {animal.Name} ({animal.Species}) ---");
                animal.MakeSound();
                animal.Move();
                animal.Eat();
                animal.Sleep();
            }

            Console.ReadKey();
        }
    }
    */

    // Задание 4
    // Абстрактный базовый класс Фигура
    public abstract class Figure
    {
        public string Name { get; set; }           // название фигуры
        public string Color { get; set; }          // цвет фигуры

        public Figure(string name, string color)
        {
            Name = name;
            Color = color;
        }

        // Абстрактный метод для подсчета площади
        public abstract double CalculateArea();

        // Метод для вывода информации о фигуре
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Фигура: {Name}");
            Console.WriteLine($"Цвет: {Color}");
            Console.WriteLine($"Площадь: {CalculateArea():F2}");
        }
    }

    // Производный класс Rectangle (Прямоугольник)
    public class Rectangle : Figure
    {
        public double Width { get; set; }          // ширина
        public double Height { get; set; }         // высота

        public Rectangle(string color, double width, double height)
            : base("Прямоугольник", color)
        {
            Width = width;
            Height = height;
        }

        // Реализация метода подсчета площади прямоугольника
        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Ширина: {Width}, Высота: {Height}");
        }
    }

    // Производный класс Circle (Круг)
    public class Circle : Figure
    {
        public double Radius { get; set; }         // радиус

        public Circle(string color, double radius)
            : base("Круг", color)
        {
            Radius = radius;
        }

        // Реализация метода подсчета площади круга
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Радиус: {Radius}");
            Console.WriteLine($"Диаметр: {Radius * 2}");
        }
    }

    // Производный класс RightTriangle (Прямоугольный треугольник)
    public class RightTriangle : Figure
    {
        public double Leg1 { get; set; }           // первый катет
        public double Leg2 { get; set; }           // второй катет

        public RightTriangle(string color, double leg1, double leg2)
            : base("Прямоугольный треугольник", color)
        {
            Leg1 = leg1;
            Leg2 = leg2;
        }

        // Реализация метода подсчета площади прямоугольного треугольника
        public override double CalculateArea()
        {
            return (Leg1 * Leg2) / 2;
        }

        // Вычисление гипотенузы
        public double CalculateHypotenuse()
        {
            return Math.Sqrt(Leg1 * Leg1 + Leg2 * Leg2);
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Катет 1: {Leg1}, Катет 2: {Leg2}");
            Console.WriteLine($"Гипотенуза: {CalculateHypotenuse():F2}");
        }
    }

    // Производный класс Trapezoid (Трапеция)
    public class Trapezoid : Figure
    {
        public double Base1 { get; set; }          // первое основание
        public double Base2 { get; set; }          // второе основание
        public double Height { get; set; }         // высота

        public Trapezoid(string color, double base1, double base2, double height)
            : base("Трапеция", color)
        {
            Base1 = base1;
            Base2 = base2;
            Height = height;
        }

        // Реализация метода подсчета площади трапеции
        public override double CalculateArea()
        {
            return ((Base1 + Base2) / 2) * Height;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Основание 1: {Base1}, Основание 2: {Base2}");
            Console.WriteLine($"Высота: {Height}");
        }
    }

    class Program4
    {
        static void Main()
        {
            Console.WriteLine("=== Задание 4: Абстрактный класс Фигура ===\n");

            // Создание массива ссылок на абстрактный класс Figure
            Figure[] figures = new Figure[]
            {
                new Rectangle("Красный", 5, 10),
                new Circle("Синий", 7),
                new RightTriangle("Зелёный", 3, 4),
                new Trapezoid("Жёлтый", 6, 10, 4),
                new Rectangle("Фиолетовый", 3.5, 7.2),
                new Circle("Оранжевый", 3.14)
            };

            // Вывод информации о всех фигурах
            Console.WriteLine("Информация о фигурах:");
            Console.WriteLine(new string('-', 40));

            double totalArea = 0;
            foreach (Figure figure in figures)
            {
                figure.DisplayInfo();
                Console.WriteLine(new string('-', 40));
                totalArea += figure.CalculateArea();
            }

            // Вывод общей площади
            Console.WriteLine($"\nОбщая площадь всех фигур: {totalArea:F2}");
            Console.WriteLine($"Количество фигур: {figures.Length}");
            Console.WriteLine($"Средняя площадь: {totalArea / figures.Length:F2}");

            // Поиск фигуры с максимальной площадью
            Figure maxAreaFigure = figures[0];
            Figure minAreaFigure = figures[0];

            foreach (Figure figure in figures)
            {
                if (figure.CalculateArea() > maxAreaFigure.CalculateArea())
                    maxAreaFigure = figure;

                if (figure.CalculateArea() < minAreaFigure.CalculateArea())
                    minAreaFigure = figure;
            }

            Console.WriteLine($"\nФигура с максимальной площадью: {maxAreaFigure.Name} ({maxAreaFigure.CalculateArea():F2})");
            Console.WriteLine($"Фигура с минимальной площадью: {minAreaFigure.Name} ({minAreaFigure.CalculateArea():F2})");

            Console.ReadKey();
        }
    }
}
