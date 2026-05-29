using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    // Задание 1
    /*
    // Абстрактный класс «Геометрическая Фигура»
    public abstract class GeometricFigure
    {
        public string Name { get; set; }           // название фигуры
        public string Color { get; set; }          // цвет фигуры

        public GeometricFigure(string name, string color = "Белый")
        {
            Name = name;
            Color = color;
        }

        // Абстрактный метод «Площадь Фигуры»
        public abstract double CalculateArea();

        // Абстрактный метод «Периметр Фигуры»
        public abstract double CalculatePerimeter();

        // Метод для вывода информации о фигуре
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Фигура: {Name}");
            Console.WriteLine($"Цвет: {Color}");
            Console.WriteLine($"Площадь: {CalculateArea():F2}");
            Console.WriteLine($"Периметр: {CalculatePerimeter():F2}");
        }
    }

    // Класс TriangleFig (наследник GeometricFigure)
    public class TriangleFig : GeometricFigure
    {
        public double SideA { get; set; }          // сторона A
        public double SideB { get; set; }          // сторона B
        public double SideC { get; set; }          // сторона C

        // Конструктор, определяющий треугольник по трём сторонам
        public TriangleFig(double sideA, double sideB, double sideC, string color = "Белый")
            : base("Треугольник", color)
        {
            // Проверка возможности существования треугольника
            if (!IsValidTriangle(sideA, sideB, sideC))
                throw new ArgumentException("Треугольник с такими сторонами не может существовать!");

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        // Проверка существования треугольника
        private bool IsValidTriangle(double a, double b, double c)
        {
            return a > 0 && b > 0 && c > 0 &&
                   a + b > c && a + c > b && b + c > a;
        }

        // Реализация метода «Площадь Фигуры» (по формуле Герона)
        public override double CalculateArea()
        {
            double semiPerimeter = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(semiPerimeter *
                           (semiPerimeter - SideA) *
                           (semiPerimeter - SideB) *
                           (semiPerimeter - SideC));
        }

        // Реализация метода «Периметр Фигуры»
        public override double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Стороны: {SideA}, {SideB}, {SideC}");
        }
    }

    // Класс SquareFig (наследник GeometricFigure)
    public class SquareFig : GeometricFigure
    {
        public double Side { get; set; }           // сторона квадрата

        // Конструктор, определяющий квадрат по стороне
        public SquareFig(double side, string color = "Белый")
            : base("Квадрат", color)
        {
            if (side <= 0)
                throw new ArgumentException("Сторона квадрата должна быть положительной!");

            Side = side;
        }

        // Реализация метода «Площадь Фигуры»
        public override double CalculateArea()
        {
            return Side * Side;
        }

        // Реализация метода «Периметр Фигуры»
        public override double CalculatePerimeter()
        {
            return 4 * Side;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Сторона: {Side}");
        }
    }

    // Класс RhombusFig (наследник GeometricFigure)
    public class RhombusFig : GeometricFigure
    {
        public double Side { get; set; }           // сторона ромба
        public double Angle { get; set; }          // угол в градусах

        // Конструктор, определяющий ромб по стороне и углу
        public RhombusFig(double side, double angle, string color = "Белый")
            : base("Ромб", color)
        {
            if (side <= 0)
                throw new ArgumentException("Сторона ромба должна быть положительной!");
            if (angle <= 0 || angle >= 180)
                throw new ArgumentException("Угол ромба должен быть от 0 до 180 градусов!");

            Side = side;
            Angle = angle;
        }

        // Реализация метода «Площадь Фигуры»
        public override double CalculateArea()
        {
            // Площадь ромба = a² * sin(α), где a - сторона, α - угол
            return Side * Side * Math.Sin(Angle * Math.PI / 180);
        }

        // Реализация метода «Периметр Фигуры»
        public override double CalculatePerimeter()
        {
            return 4 * Side;
        }

        // Вычисление диагоналей ромба
        public double GetDiagonal1()
        {
            return 2 * Side * Math.Cos(Angle / 2 * Math.PI / 180);
        }

        public double GetDiagonal2()
        {
            return 2 * Side * Math.Sin(Angle / 2 * Math.PI / 180);
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Сторона: {Side}");
            Console.WriteLine($"Угол: {Angle}°");
            Console.WriteLine($"Диагонали: {GetDiagonal1():F2}, {GetDiagonal2():F2}");
        }
    }

    // Класс RectangleFig (наследник GeometricFigure)
    public class RectangleFig : GeometricFigure
    {
        public double Width { get; set; }          // ширина
        public double Height { get; set; }         // высота

        // Конструктор, определяющий прямоугольник по ширине и высоте
        public RectangleFig(double width, double height, string color = "Белый")
            : base("Прямоугольник", color)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Стороны прямоугольника должны быть положительными!");

            Width = width;
            Height = height;
        }

        // Реализация метода «Площадь Фигуры»
        public override double CalculateArea()
        {
            return Width * Height;
        }

        // Реализация метода «Периметр Фигуры»
        public override double CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Ширина: {Width}, Высота: {Height}");
        }
    }

    // Класс ParallelogramFig (наследник GeometricFigure)
    public class ParallelogramFig : GeometricFigure
    {
        public double BaseSide { get; set; }       // основание
        public double LateralSide { get; set; }     // боковая сторона
        public double Angle { get; set; }          // угол в градусах

        // Конструктор, определяющий параллелограмм по основанию, стороне и углу
        public ParallelogramFig(double baseSide, double lateralSide, double angle, string color = "Белый")
            : base("Параллелограмм", color)
        {
            if (baseSide <= 0 || lateralSide <= 0)
                throw new ArgumentException("Стороны параллелограмма должны быть положительными!");
            if (angle <= 0 || angle >= 180)
                throw new ArgumentException("Угол параллелограмма должен быть от 0 до 180 градусов!");

            BaseSide = baseSide;
            LateralSide = lateralSide;
            Angle = angle;
        }

        // Реализация метода «Площадь Фигуры»
        public override double CalculateArea()
        {
            // Площадь параллелограмма = a * b * sin(α)
            return BaseSide * LateralSide * Math.Sin(Angle * Math.PI / 180);
        }

        // Реализация метода «Периметр Фигуры»
        public override double CalculatePerimeter()
        {
            return 2 * (BaseSide + LateralSide);
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Основание: {BaseSide}, Боковая сторона: {LateralSide}");
            Console.WriteLine($"Угол: {Angle}°");
        }
    }

    // Класс TrapezoidFig (наследник GeometricFigure)
    public class TrapezoidFig : GeometricFigure
    {
        public double Base1 { get; set; }          // первое основание
        public double Base2 { get; set; }          // второе основание
        public double Side1 { get; set; }          // первая боковая сторона
        public double Side2 { get; set; }          // вторая боковая сторона

        // Конструктор, определяющий трапецию по четырём сторонам
        public TrapezoidFig(double base1, double base2, double side1, double side2, string color = "Белый")
            : base("Трапеция", color)
        {
            if (base1 <= 0 || base2 <= 0 || side1 <= 0 || side2 <= 0)
                throw new ArgumentException("Стороны трапеции должны быть положительными!");

            Base1 = base1;
            Base2 = base2;
            Side1 = side1;
            Side2 = side2;
        }

        // Вычисление высоты трапеции
        public double CalculateHeight()
        {
            double diff = Math.Abs(Base1 - Base2);
            if (diff == 0)
            {
                // Если основания равны, это параллелограмм
                return Math.Sqrt(Side1 * Side1 - diff * diff / 4);
            }
            double temp = (diff * diff + Side1 * Side1 - Side2 * Side2) / (2 * diff);
            return Math.Sqrt(Math.Max(0, Side1 * Side1 - temp * temp));
        }

        // Реализация метода «Площадь Фигуры»
        public override double CalculateArea()
        {
            double height = CalculateHeight();
            return ((Base1 + Base2) / 2) * height;
        }

        // Реализация метода «Периметр Фигуры»
        public override double CalculatePerimeter()
        {
            return Base1 + Base2 + Side1 + Side2;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Основания: {Base1}, {Base2}");
            Console.WriteLine($"Боковые стороны: {Side1}, {Side2}");
            Console.WriteLine($"Высота: {CalculateHeight():F2}");
        }
    }

    // Класс CircleFig (наследник GeometricFigure)
    public class CircleFig : GeometricFigure
    {
        public double Radius { get; set; }         // радиус

        // Конструктор, определяющий круг по радиусу
        public CircleFig(double radius, string color = "Белый")
            : base("Круг", color)
        {
            if (radius <= 0)
                throw new ArgumentException("Радиус круга должен быть положительным!");

            Radius = radius;
        }

        // Реализация метода «Площадь Фигуры»
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        // Реализация метода «Периметр Фигуры» (длина окружности)
        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Радиус: {Radius}");
            Console.WriteLine($"Диаметр: {Radius * 2}");
            Console.WriteLine($"Длина окружности: {CalculatePerimeter():F2}");
        }
    }

    // Класс EllipseFig (наследник GeometricFigure)
    public class EllipseFig : GeometricFigure
    {
        public double SemiMajorAxis { get; set; }  // большая полуось
        public double SemiMinorAxis { get; set; }  // малая полуось

        // Конструктор, определяющий эллипс по двум полуосям
        public EllipseFig(double semiMajorAxis, double semiMinorAxis, string color = "Белый")
            : base("Эллипс", color)
        {
            if (semiMajorAxis <= 0 || semiMinorAxis <= 0)
                throw new ArgumentException("Полуоси эллипса должны быть положительными!");

            SemiMajorAxis = semiMajorAxis;
            SemiMinorAxis = semiMinorAxis;
        }

        // Реализация метода «Площадь Фигуры»
        public override double CalculateArea()
        {
            return Math.PI * SemiMajorAxis * SemiMinorAxis;
        }

        // Реализация метода «Периметр Фигуры» (приближенная формула)
        public override double CalculatePerimeter()
        {
            double a = Math.Max(SemiMajorAxis, SemiMinorAxis);
            double b = Math.Min(SemiMajorAxis, SemiMinorAxis);
            double h = Math.Pow(a - b, 2) / Math.Pow(a + b, 2);
            return Math.PI * (a + b) * (1 + (3 * h) / (10 + Math.Sqrt(4 - 3 * h)));
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Большая полуось: {Math.Max(SemiMajorAxis, SemiMinorAxis)}");
            Console.WriteLine($"Малая полуось: {Math.Min(SemiMajorAxis, SemiMinorAxis)}");
        }
    }

    // Класс «Составная Фигура»
    public class CompositeFigure
    {
        public string Name { get; set; }                    // название составной фигуры
        public List<GeometricFigure> Figures { get; set; }  // список геометрических фигур

        public CompositeFigure(string name)
        {
            Name = name;
            Figures = new List<GeometricFigure>();
        }

        // Метод для добавления фигуры в составную фигуру
        public void AddFigure(GeometricFigure figure)
        {
            Figures.Add(figure);
            Console.WriteLine($"Фигура '{figure.Name}' добавлена в составную фигуру '{Name}'");
        }

        // Метод для удаления фигуры из составной фигуры
        public void RemoveFigure(GeometricFigure figure)
        {
            if (Figures.Remove(figure))
                Console.WriteLine($"Фигура '{figure.Name}' удалена из составной фигуры '{Name}'");
        }

        // Метод нахождения площади составной фигуры
        public double CalculateTotalArea()
        {
            double totalArea = 0;
            foreach (GeometricFigure figure in Figures)
            {
                totalArea += figure.CalculateArea();
            }
            return totalArea;
        }

        // Метод нахождения общего периметра
        public double CalculateTotalPerimeter()
        {
            double totalPerimeter = 0;
            foreach (GeometricFigure figure in Figures)
            {
                totalPerimeter += figure.CalculatePerimeter();
            }
            return totalPerimeter;
        }

        // Метод для вывода информации о составной фигуре
        public void DisplayInfo()
        {
            Console.WriteLine($"\n=== Составная фигура: {Name} ===");
            Console.WriteLine($"Количество фигур: {Figures.Count}");
            Console.WriteLine($"Общая площадь: {CalculateTotalArea():F2}");
            Console.WriteLine($"Общий периметр: {CalculateTotalPerimeter():F2}");
            Console.WriteLine("\nСостав фигуры:");

            foreach (GeometricFigure figure in Figures)
            {
                Console.WriteLine($"  • {figure.Name} - Площадь: {figure.CalculateArea():F2}, " +
                                $"Периметр: {figure.CalculatePerimeter():F2}");
            }
        }
    }

    class Program1
    {
        static void Main()
        {
            Console.WriteLine("=== Задание 1: Геометрические фигуры ===\n");

            // Создание отдельных фигур
            TriangleFig triangle = new TriangleFig(3, 4, 5, "Красный");
            SquareFig square = new SquareFig(5, "Синий");
            RhombusFig rhombus = new RhombusFig(4, 60, "Зелёный");
            RectangleFig rectangle = new RectangleFig(4, 6, "Жёлтый");
            ParallelogramFig parallelogram = new ParallelogramFig(5, 3, 45, "Фиолетовый");
            TrapezoidFig trapezoid = new TrapezoidFig(6, 10, 5, 5, "Оранжевый");
            CircleFig circle = new CircleFig(7, "Голубой");
            EllipseFig ellipse = new EllipseFig(5, 3, "Розовый");

            // Вывод информации о каждой фигуре
            Console.WriteLine("ИНФОРМАЦИЯ О ФИГУРАХ:");
            Console.WriteLine(new string('=', 40));

            triangle.DisplayInfo();
            Console.WriteLine(new string('-', 40));

            square.DisplayInfo();
            Console.WriteLine(new string('-', 40));

            rhombus.DisplayInfo();
            Console.WriteLine(new string('-', 40));

            rectangle.DisplayInfo();
            Console.WriteLine(new string('-', 40));

            parallelogram.DisplayInfo();
            Console.WriteLine(new string('-', 40));

            trapezoid.DisplayInfo();
            Console.WriteLine(new string('-', 40));

            circle.DisplayInfo();
            Console.WriteLine(new string('-', 40));

            ellipse.DisplayInfo();
            Console.WriteLine(new string('-', 40));

            // Создание составной фигуры
            Console.WriteLine("\n\nСОСТАВНАЯ ФИГУРА:");
            CompositeFigure house = new CompositeFigure("Домик");

            // Добавление фигур (дом из квадрата, треугольника, круга и прямоугольника)
            house.AddFigure(new SquareFig(10, "Коричневый"));        // основание дома
            house.AddFigure(new TriangleFig(10, 10, 10, "Красный"));  // крыша
            house.AddFigure(new RectangleFig(3, 5, "Синий"));        // дверь
            house.AddFigure(new CircleFig(1, "Жёлтый"));            // окно

            house.DisplayInfo();

            // Демонстрация полиморфизма
            Console.WriteLine("\n\nДЕМОНСТРАЦИЯ ПОЛИМОРФИЗМА:");
            GeometricFigure[] figures = new GeometricFigure[]
            {
                triangle, square, rhombus, rectangle, parallelogram,
                trapezoid, circle, ellipse
            };

            Console.WriteLine("\nВычисление площадей всех фигур:");
            Console.WriteLine(new string('-', 50));

            double totalArea = 0;
            foreach (GeometricFigure figure in figures)
            {
                double area = figure.CalculateArea();
                totalArea += area;
                Console.WriteLine($"{figure.Name,-15}: Площадь = {area,10:F2}, " +
                                $"Периметр = {figure.CalculatePerimeter(),10:F2}");
            }

            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"{"Общая площадь:",-15}: {totalArea,10:F2}");

            Console.ReadKey();
        }
    }
    */

    // Задание 2

    // Перечисление для типов товаров
    public enum ProductType
    {
        HouseholdChemicals,    // бытовая химия
        FoodProducts,          // продукты питания
        Electronics,           // электроника
        Clothing,              // одежда
        Other                  // другое
    }

    // Перечисление для единиц измерения
    public enum UnitOfMeasurement
    {
        Piece,                 // штуки
        Kilogram,              // килограммы
        Liter,                 // литры
        Package,               // упаковки
        Box                    // коробки
    }

    // Перечисление для статуса товара
    public enum ProductStatus
    {
        InStock,               // на складе
        InTransit,             // в пути
        Sold,                  // реализовано
        WrittenOff,            // списано
        Transferred,           // передано
        Reserved               // зарезервировано
    }

    // Перечисление для типа операции
    public enum OperationType
    {
        Arrival,               // пришло
        Sale,                  // реализовано
        WriteOff,              // списано
        Transfer               // передано
    }

    // Базовый класс Товар
    public abstract class Product
    {
        public string ProductCode { get; set; }        // код товара
        public string ProductName { get; set; }        // название товара
        public string Description { get; set; }        // описание товара
        public decimal Price { get; set; }             // цена за единицу
        public double Quantity { get; set; }           // количество на складе
        public UnitOfMeasurement Unit { get; set; }    // единица измерения
        public ProductType Type { get; set; }          // тип товара
        public ProductStatus Status { get; set; }      // статус товара
        public DateTime ExpiryDate { get; set; }       // срок годности
        public string Manufacturer { get; set; }       // производитель
        public string Supplier { get; set; }           // поставщик

        public Product(string productCode, string productName, string description,
                      decimal price, double quantity, UnitOfMeasurement unit,
                      ProductType type, DateTime expiryDate, string manufacturer, string supplier)
        {
            ProductCode = productCode;
            ProductName = productName;
            Description = description;
            Price = price;
            Quantity = quantity;
            Unit = unit;
            Type = type;
            Status = ProductStatus.InStock;
            ExpiryDate = expiryDate;
            Manufacturer = manufacturer;
            Supplier = supplier;
        }

        // Метод для проверки срока годности
        public bool IsExpired()
        {
            return DateTime.Now > ExpiryDate;
        }

        // Метод для получения общей стоимости товара на складе
        public decimal GetTotalValue()
        {
            return Price * (decimal)Quantity;
        }

        // Виртуальный метод для вывода информации о товаре
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Код: {ProductCode}");
            Console.WriteLine($"Название: {ProductName}");
            Console.WriteLine($"Описание: {Description}");
            Console.WriteLine($"Цена: {Price:C2} за {Unit}");
            Console.WriteLine($"Количество: {Quantity} {Unit}");
            Console.WriteLine($"Тип: {Type}");
            Console.WriteLine($"Статус: {Status}");
            Console.WriteLine($"Срок годности: {ExpiryDate:dd.MM.yyyy} {(IsExpired() ? "(ПРОСРОЧЕН!)" : "")}");
            Console.WriteLine($"Производитель: {Manufacturer}");
            Console.WriteLine($"Поставщик: {Supplier}");
            Console.WriteLine($"Общая стоимость: {GetTotalValue():C2}");
        }
    }

    // Класс Бытовая химия (наследник Product)
    public class HouseholdChemical : Product
    {
        public string HazardClass { get; set; }        // класс опасности
        public bool IsFlammable { get; set; }          // огнеопасность
        public string Composition { get; set; }        // состав
        public double Volume { get; set; }             // объём в мл/л
        public string StorageConditions { get; set; }  // условия хранения
        public bool IsToxic { get; set; }              // токсичность
        public string UsageInstructions { get; set; }  // инструкция по применению

        public HouseholdChemical(string productCode, string productName, string description,
                               decimal price, double quantity, UnitOfMeasurement unit,
                               DateTime expiryDate, string manufacturer, string supplier,
                               string hazardClass, bool isFlammable, string composition,
                               double volume, string storageConditions, bool isToxic,
                               string usageInstructions)
            : base(productCode, productName, description, price, quantity, unit,
                  ProductType.HouseholdChemicals, expiryDate, manufacturer, supplier)
        {
            HazardClass = hazardClass;
            IsFlammable = isFlammable;
            Composition = composition;
            Volume = volume;
            StorageConditions = storageConditions;
            IsToxic = isToxic;
            UsageInstructions = usageInstructions;
        }

        // Метод для проверки условий хранения
        public void CheckStorageConditions()
        {
            Console.WriteLine($"Условия хранения для {ProductName}: {StorageConditions}");
            if (IsFlammable)
                Console.WriteLine("ВНИМАНИЕ: Огнеопасный продукт! Хранить вдали от огня!");
            if (IsToxic)
                Console.WriteLine("ВНИМАНИЕ: Токсичный продукт! Хранить в недоступном для детей месте!");
        }

        // Метод для отображения инструкции по применению
        public void ShowUsageInstructions()
        {
            Console.WriteLine($"Инструкция по применению {ProductName}:");
            Console.WriteLine(UsageInstructions);
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Класс опасности: {HazardClass}");
            Console.WriteLine($"Огнеопасность: {(IsFlammable ? "Да" : "Нет")}");
            Console.WriteLine($"Токсичность: {(IsToxic ? "Да" : "Нет")}");
            Console.WriteLine($"Состав: {Composition}");
            Console.WriteLine($"Объём: {Volume} мл");
            Console.WriteLine($"Условия хранения: {StorageConditions}");
        }
    }

    // Класс Продукты питания (наследник Product)
    public class FoodProduct : Product
    {
        public string Category { get; set; }           // категория (молочные, мясные и т.д.)
        public double Calories { get; set; }           // калорийность на 100г
        public double Protein { get; set; }            // белки
        public double Fat { get; set; }                // жиры
        public double Carbohydrates { get; set; }      // углеводы
        public bool IsOrganic { get; set; }            // органический продукт
        public string StorageTemperature { get; set; } // температура хранения
        public bool RequiresRefrigeration { get; set; } // требует охлаждения
        public string CountryOfOrigin { get; set; }    // страна происхождения
        public string PackagingType { get; set; }      // тип упаковки

        public FoodProduct(string productCode, string productName, string description,
                          decimal price, double quantity, UnitOfMeasurement unit,
                          DateTime expiryDate, string manufacturer, string supplier,
                          string category, double calories, double protein, double fat,
                          double carbohydrates, bool isOrganic, string storageTemperature,
                          bool requiresRefrigeration, string countryOfOrigin, string packagingType)
            : base(productCode, productName, description, price, quantity, unit,
                  ProductType.FoodProducts, expiryDate, manufacturer, supplier)
        {
            Category = category;
            Calories = calories;
            Protein = protein;
            Fat = fat;
            Carbohydrates = carbohydrates;
            IsOrganic = isOrganic;
            StorageTemperature = storageTemperature;
            RequiresRefrigeration = requiresRefrigeration;
            CountryOfOrigin = countryOfOrigin;
            PackagingType = packagingType;
        }

        // Метод для проверки пищевой ценности
        public void DisplayNutritionInfo()
        {
            Console.WriteLine($"Пищевая ценность {ProductName} на 100г:");
            Console.WriteLine($"  Калории: {Calories} ккал");
            Console.WriteLine($"  Белки: {Protein}г");
            Console.WriteLine($"  Жиры: {Fat}г");
            Console.WriteLine($"  Углеводы: {Carbohydrates}г");
        }

        // Проверка необходимости охлаждения
        public void CheckRefrigeration()
        {
            if (RequiresRefrigeration)
                Console.WriteLine($"{ProductName} требует хранения при температуре {StorageTemperature}");
            else
                Console.WriteLine($"{ProductName} можно хранить при комнатной температуре");
        }

        // Проверка срока годности с предупреждением
        public bool IsNearExpiry(int daysBeforeExpiry)
        {
            return (ExpiryDate - DateTime.Now).TotalDays <= daysBeforeExpiry && !IsExpired();
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Категория: {Category}");
            Console.WriteLine($"Страна происхождения: {CountryOfOrigin}");
            Console.WriteLine($"Органический: {(IsOrganic ? "Да" : "Нет")}");
            Console.WriteLine($"Тип упаковки: {PackagingType}");
            Console.WriteLine($"Температура хранения: {StorageTemperature}");
            Console.WriteLine($"Требует охлаждения: {(RequiresRefrigeration ? "Да" : "Нет")}");

            if (IsNearExpiry(7))
                Console.WriteLine("ВНИМАНИЕ: Срок годности истекает менее чем через 7 дней!");
        }
    }

    // Класс Операция с товаром
    public class ProductOperation
    {
        public string OperationCode { get; set; }       // код операции
        public OperationType Type { get; set; }         // тип операции
        public Product Product { get; set; }            // товар
        public double Quantity { get; set; }            // количество
        public DateTime OperationDate { get; set; }     // дата операции
        public string FromLocation { get; set; }        // откуда
        public string ToLocation { get; set; }          // куда
        public string ResponsiblePerson { get; set; }   // ответственное лицо
        public string Comment { get; set; }             // комментарий
        public decimal OperationCost { get; set; }      // стоимость операции

        public ProductOperation(string operationCode, OperationType type, Product product,
                              double quantity, string fromLocation, string toLocation,
                              string responsiblePerson, string comment = "")
        {
            OperationCode = operationCode;
            Type = type;
            Product = product;
            Quantity = quantity;
            OperationDate = DateTime.Now;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            ResponsiblePerson = responsiblePerson;
            Comment = comment;

            // Расчёт стоимости операции
            if (type == OperationType.Arrival)
                OperationCost = product.Price * (decimal)quantity;
            else
                OperationCost = 0;
        }

        // Выполнение операции
        public bool Execute()
        {
            switch (Type)
            {
                case OperationType.Arrival:
                    // пришло
                    Product.Quantity += Quantity;
                    Product.Status = ProductStatus.InStock;
                    Console.WriteLine($"ПРИХОД: {Product.ProductName} +{Quantity} {Product.Unit}. " +
                                    $"Всего: {Product.Quantity} {Product.Unit}. " +
                                    $"Стоимость поставки: {OperationCost:C2}");
                    return true;

                case OperationType.Sale:
                    // реализовано
                    if (Product.Quantity >= Quantity)
                    {
                        if (Product.IsExpired())
                        {
                            Console.WriteLine($"ОШИБКА: Товар '{Product.ProductName}' просрочен! Продажа невозможна.");
                            return false;
                        }
                        Product.Quantity -= Quantity;
                        if (Product.Quantity == 0)
                            Product.Status = ProductStatus.Sold;
                        Console.WriteLine($"ПРОДАЖА: {Product.ProductName} -{Quantity} {Product.Unit}. " +
                                        $"Осталось: {Product.Quantity} {Product.Unit}. " +
                                        $"Сумма продажи: {Product.Price * (decimal)Quantity:C2}");
                    }
                    else
                    {
                        Console.WriteLine($"ОШИБКА: Недостаточно товара '{Product.ProductName}'! " +
                                        $"Доступно: {Product.Quantity}, требуется: {Quantity}");
                        return false;
                    }
                    return true;

                case OperationType.WriteOff:
                    // списано
                    if (Product.Quantity >= Quantity)
                    {
                        Product.Quantity -= Quantity;
                        Product.Status = ProductStatus.WrittenOff;
                        Console.WriteLine($"СПИСАНИЕ: {Product.ProductName} -{Quantity} {Product.Unit}. " +
                                        $"Причина: {Comment}. Осталось: {Product.Quantity} {Product.Unit}");
                    }
                    else
                    {
                        Console.WriteLine($"ОШИБКА: Недостаточно товара '{Product.ProductName}' для списания!");
                        return false;
                    }
                    return true;

                case OperationType.Transfer:
                    // передано
                    if (Product.Quantity >= Quantity)
                    {
                        Product.Quantity -= Quantity;
                        Product.Status = ProductStatus.Transferred;
                        Console.WriteLine($"ПЕРЕДАЧА: {Product.ProductName} -{Quantity} {Product.Unit} " +
                                        $"из '{FromLocation}' в '{ToLocation}'. " +
                                        $"Осталось: {Product.Quantity} {Product.Unit}");
                    }
                    else
                    {
                        Console.WriteLine($"ОШИБКА: Недостаточно товара '{Product.ProductName}' для передачи!");
                        return false;
                    }
                    return true;

                default:
                    return false;
            }
        }

        // Вывод информации об операции
        public void DisplayOperationInfo()
        {
            Console.WriteLine($"\n=== Операция: {OperationCode} ===");
            Console.WriteLine($"Тип операции: {Type}");
            Console.WriteLine($"Товар: {Product.ProductName} ({Product.ProductCode})");
            Console.WriteLine($"Количество: {Quantity} {Product.Unit}");
            Console.WriteLine($"Дата операции: {OperationDate:dd.MM.yyyy HH:mm:ss}");
            Console.WriteLine($"Откуда: {FromLocation}");
            Console.WriteLine($"Куда: {ToLocation}");
            Console.WriteLine($"Ответственное лицо: {ResponsiblePerson}");
            if (OperationCost > 0)
                Console.WriteLine($"Стоимость операции: {OperationCost:C2}");
            if (!string.IsNullOrEmpty(Comment))
                Console.WriteLine($"Комментарий: {Comment}");
        }
    }

    // Класс Управление потоком товаров
    public class ProductFlowManager
    {
        public string WarehouseName { get; set; }                   // название склада
        public string WarehouseAddress { get; set; }               // адрес склада
        public string ManagerName { get; set; }                    // имя управляющего
        public List<Product> Products { get; set; }                // список товаров
        public List<ProductOperation> Operations { get; set; }     // история операций
        private int operationCounter = 0;                          // счётчик операций

        public ProductFlowManager(string warehouseName, string warehouseAddress, string managerName)
        {
            WarehouseName = warehouseName;
            WarehouseAddress = warehouseAddress;
            ManagerName = managerName;
            Products = new List<Product>();
            Operations = new List<ProductOperation>();
        }

        // Генерация кода операции
        private string GenerateOperationCode()
        {
            operationCounter++;
            return $"OP-{DateTime.Now:yyyyMMdd}-{operationCounter:D4}";
        }

        // Добавить товар в систему
        public void AddProduct(Product product)
        {
            if (Products.Any(p => p.ProductCode == product.ProductCode))
            {
                Console.WriteLine($"ОШИБКА: Товар с кодом '{product.ProductCode}' уже существует!");
                return;
            }
            Products.Add(product);
            Console.WriteLine($"Товар '{product.ProductName}' добавлен в систему учёта склада '{WarehouseName}'");
        }

        // Удалить товар из системы
        public void RemoveProduct(string productCode)
        {
            Product product = Products.Find(p => p.ProductCode == productCode);
            if (product != null)
            {
                Products.Remove(product);
                Console.WriteLine($"Товар '{product.ProductName}' удалён из системы учёта");
            }
            else
            {
                Console.WriteLine($"ОШИБКА: Товар с кодом '{productCode}' не найден!");
            }
        }

        // Найти товар по коду
        public Product FindProduct(string productCode)
        {
            return Products.Find(p => p.ProductCode == productCode);
        }

        // Выполнить операцию прихода товара
        public void ArriveProduct(string productCode, double quantity, string fromLocation,
                                 string responsiblePerson)
        {
            Product product = FindProduct(productCode);
            if (product == null)
            {
                Console.WriteLine($"ОШИБКА: Товар с кодом '{productCode}' не найден!");
                return;
            }

            ProductOperation operation = new ProductOperation(
                GenerateOperationCode(), OperationType.Arrival, product,
                quantity, fromLocation, WarehouseName, responsiblePerson,
                $"Поступление товара от {fromLocation}"
            );

            if (operation.Execute())
                Operations.Add(operation);
        }

        // Выполнить операцию продажи товара
        public void SellProduct(string productCode, double quantity, string toLocation,
                               string responsiblePerson)
        {
            Product product = FindProduct(productCode);
            if (product == null)
            {
                Console.WriteLine($"ОШИБКА: Товар с кодом '{productCode}' не найден!");
                return;
            }

            ProductOperation operation = new ProductOperation(
                GenerateOperationCode(), OperationType.Sale, product,
                quantity, WarehouseName, toLocation, responsiblePerson,
                $"Продажа покупателю: {toLocation}"
            );

            if (operation.Execute())
                Operations.Add(operation);
        }

        // Выполнить операцию списания товара
        public void WriteOffProduct(string productCode, double quantity, string reason,
                                   string responsiblePerson)
        {
            Product product = FindProduct(productCode);
            if (product == null)
            {
                Console.WriteLine($"ОШИБКА: Товар с кодом '{productCode}' не найден!");
                return;
            }

            ProductOperation operation = new ProductOperation(
                GenerateOperationCode(), OperationType.WriteOff, product,
                quantity, WarehouseName, "Списание", responsiblePerson,
                reason
            );

            if (operation.Execute())
                Operations.Add(operation);
        }

        // Выполнить операцию передачи товара
        public void TransferProduct(string productCode, double quantity, string toLocation,
                                   string responsiblePerson)
        {
            Product product = FindProduct(productCode);
            if (product == null)
            {
                Console.WriteLine($"ОШИБКА: Товар с кодом '{productCode}' не найден!");
                return;
            }

            ProductOperation operation = new ProductOperation(
                GenerateOperationCode(), OperationType.Transfer, product,
                quantity, WarehouseName, toLocation, responsiblePerson,
                $"Передача на склад: {toLocation}"
            );

            if (operation.Execute())
                Operations.Add(operation);
        }

        // Получить все товары определённого типа
        public List<Product> GetProductsByType(ProductType type)
        {
            return Products.Where(p => p.Type == type).ToList();
        }

        // Получить просроченные товары
        public List<Product> GetExpiredProducts()
        {
            return Products.Where(p => p.IsExpired()).ToList();
        }

        // Получить товары с низким остатком
        public List<Product> GetLowStockProducts(double threshold)
        {
            return Products.Where(p => p.Quantity <= threshold).ToList();
        }

        // Получить отчёт по операциям за период
        public List<ProductOperation> GetOperationsByPeriod(DateTime from, DateTime to)
        {
            return Operations.Where(o => o.OperationDate >= from && o.OperationDate <= to).ToList();
        }

        // Получить статистику по типам операций
        public void DisplayOperationsSummary()
        {
            Console.WriteLine($"\n=== СВОДКА ПО ОПЕРАЦИЯМ СКЛАДА '{WarehouseName}' ===");

            foreach (OperationType type in Enum.GetValues(typeof(OperationType)))
            {
                var ops = Operations.Where(o => o.Type == type).ToList();
                if (ops.Count > 0)
                {
                    double totalQuantity = ops.Sum(o => o.Quantity);
                    Console.WriteLine($"{type}: {ops.Count} операций, всего {totalQuantity} единиц товара");
                }
            }
        }

        // Получить статистику по складу
        public void DisplayWarehouseStatistics()
        {
            Console.WriteLine($"\n=== СТАТИСТИКА СКЛАДА '{WarehouseName}' ===");
            Console.WriteLine($"Адрес: {WarehouseAddress}");
            Console.WriteLine($"Управляющий: {ManagerName}");
            Console.WriteLine($"Всего наименований товаров: {Products.Count}");
            Console.WriteLine($"Общая стоимость товаров: {Products.Sum(p => p.GetTotalValue()):C2}");
            Console.WriteLine($"Всего операций: {Operations.Count}");

            // Статистика по типам товаров
            Console.WriteLine("\nРаспределение по типам товаров:");
            Console.WriteLine(new string('-', 50));
            foreach (ProductType type in Enum.GetValues(typeof(ProductType)))
            {
                var productsByType = GetProductsByType(type);
                if (productsByType.Count > 0)
                {
                    double totalQuantity = productsByType.Sum(p => p.Quantity);
                    decimal totalValue = productsByType.Sum(p => p.GetTotalValue());
                    Console.WriteLine($"{type,-20}: {productsByType.Count,3} наим., " +
                                    $"{totalQuantity,8:F0} ед., {totalValue,12:C2}");
                }
            }
            Console.WriteLine(new string('-', 50));

            // Предупреждения
            var expired = GetExpiredProducts();
            if (expired.Count > 0)
            {
                Console.WriteLine($"\nВНИМАНИЕ! Просроченных товаров: {expired.Count}");
                foreach (var product in expired)
                {
                    Console.WriteLine($"  • {product.ProductName} - просрочен {product.ExpiryDate:dd.MM.yyyy}");
                }
            }

            var lowStock = GetLowStockProducts(10);
            if (lowStock.Count > 0)
            {
                Console.WriteLine($"\nВНИМАНИЕ! Товаров с низким остатком (<= 10): {lowStock.Count}");
                foreach (var product in lowStock)
                {
                    Console.WriteLine($"  • {product.ProductName} - осталось {product.Quantity} {product.Unit}");
                }
            }
        }

        // Вывести полный список товаров
        public void DisplayAllProducts()
        {
            Console.WriteLine($"\n=== ПОЛНЫЙ СПИСОК ТОВАРОВ СКЛАДА '{WarehouseName}' ===");
            Console.WriteLine(new string('=', 60));

            foreach (var product in Products)
            {
                Console.WriteLine($"\n{product.ProductCode} | {product.ProductName} | " +
                                $"{product.Quantity} {product.Unit} | {product.GetTotalValue():C2}");
                Console.WriteLine($"  Тип: {product.Type} | Статус: {product.Status} | " +
                                $"Годен до: {product.ExpiryDate:dd.MM.yyyy}");
            }
        }

        // Вывести историю операций
        public void DisplayOperationsHistory()
        {
            Console.WriteLine($"\n=== ИСТОРИЯ ОПЕРАЦИЙ СКЛАДА '{WarehouseName}' ===");
            Console.WriteLine(new string('=', 80));

            if (Operations.Count == 0)
            {
                Console.WriteLine("Операций не найдено");
                return;
            }

            Console.WriteLine($"{"Дата",-20} | {"Тип",-10} | {"Товар",-20} | " +
                            $"{"Кол-во",-10} | {"Ответственный",-20}");
            Console.WriteLine(new string('-', 80));

            foreach (var operation in Operations)
            {
                Console.WriteLine($"{operation.OperationDate:dd.MM.yyyy HH:mm} | " +
                                $"{operation.Type,-10} | {operation.Product.ProductName,-20} | " +
                                $"{operation.Quantity,8:F0} {operation.Product.Unit,-2} | " +
                                $"{operation.ResponsiblePerson,-20}");
            }
        }
    }

    class Program2
    {
        static void Main()
        {
            Console.WriteLine("=== Задание 2: Система управления потоками товаров ===\n");

            // Создание системы управления складом
            ProductFlowManager warehouse = new ProductFlowManager(
                "Центральный склад",
                "г. Москва, ул. Складская, д. 15",
                "Петров Иван Сергеевич"
            );

            // Создание товаров - Бытовая химия
            HouseholdChemical washingPowder = new HouseholdChemical(
                "HC001",                          // код товара
                "Стиральный порошок 'Чистота'",   // название
                "Универсальный стиральный порошок для всех типов ткани", // описание
                450.00m,                          // цена
                100,                              // количество
                UnitOfMeasurement.Package,        // единица измерения
                new DateTime(2025, 12, 31),       // срок годности
                "ООО 'БытХим'",                   // производитель
                "ООО 'Поставщик+'",                // поставщик
                "3 класс",                        // класс опасности
                false,                            // огнеопасность
                "ПАВ 15%, фосфаты, отбеливатель", // состав
                3000,                             // объём в мл
                "Хранить в сухом месте при t 5-25°C", // условия хранения
                false,                            // токсичность
                "Растворить 100г порошка в 5л воды" // инструкция
            );

            HouseholdChemical detergent = new HouseholdChemical(
                "HC002",
                "Моющее средство для посуды 'Блеск'",
                "Жидкое средство для мытья посуды",
                180.00m,
                150,
                UnitOfMeasurement.Piece,
                new DateTime(2025, 6, 30),
                "ООО 'Чистый Дом'",
                "ООО 'Поставщик+'",
                "4 класс",
                false,
                "Анионные ПАВ, неионогенные ПАВ, загуститель",
                500,
                "Хранить вдали от пищевых продуктов",
                true,
                "Нанести 5мл на губку, взбить пену"
            );

            // Создание товаров - Продукты питания
            FoodProduct milk = new FoodProduct(
                "FP001",                          // код товара
                "Молоко 'Коровкино'",             // название
                "Пастеризованное молоко 3.2% жирности", // описание
                89.90m,                           // цена
                200,                              // количество
                UnitOfMeasurement.Piece,          // единица измерения
                new DateTime(2024, 7, 15),        // срок годности
                "АО 'Молокозавод №1'",            // производитель
                "ООО 'ПродСнаб'",                 // поставщик
                "Молочные продукты",              // категория
                60,                               // калории
                2.9,                              // белки
                3.2,                              // жиры
                4.7,                              // углеводы
                false,                            // органический
                "+2°C до +6°C",                   // температура хранения
                true,                             // требует охлаждения
                "Россия",                         // страна происхождения
                "Тетра-пак 1л"                    // тип упаковки
            );

            FoodProduct bread = new FoodProduct(
                "FP002",
                "Хлеб 'Деревенский'",
                "Хлеб пшеничный из муки высшего сорта",
                45.50m,
                300,
                UnitOfMeasurement.Piece,
                new DateTime(2024, 7, 10),
                "АО 'Хлебозавод №5'",
                "ООО 'ХлебСнаб'",
                "Хлебобулочные изделия",
                265,
                7.6,
                2.5,
                49.0,
                false,
                "+15°C до +25°C",
                false,
                "Россия",
                "Бумажная упаковка"
            );

            FoodProduct cheese = new FoodProduct(
                "FP003",
                "Сыр 'Российский'",
                "Полутвёрдый сыр 50% жирности",
                520.00m,
                50,
                UnitOfMeasurement.Kilogram,
                new DateTime(2024, 8, 20),
                "ООО 'Сыроварня'",
                "ООО 'ПродСнаб'",
                "Молочные продукты",
                360,
                23.0,
                29.0,
                0,
                false,
                "+2°C до +8°C",
                true,
                "Россия",
                "Вакуумная упаковка"
            );

            // Добавление товаров на склад
            Console.WriteLine("=== ДОБАВЛЕНИЕ ТОВАРОВ НА СКЛАД ===\n");
            warehouse.AddProduct(washingPowder);
            warehouse.AddProduct(detergent);
            warehouse.AddProduct(milk);
            warehouse.AddProduct(bread);
            warehouse.AddProduct(cheese);

            // Вывод информации о товарах
            Console.WriteLine("\n\n=== ИНФОРМАЦИЯ О ТОВАРАХ ===\n");
            Console.WriteLine("--- Бытовая химия ---");
            washingPowder.DisplayInfo();
            Console.WriteLine();
            washingPowder.CheckStorageConditions();
            Console.WriteLine();
            washingPowder.ShowUsageInstructions();

            Console.WriteLine("\n--- Продукты питания ---");
            milk.DisplayInfo();
            Console.WriteLine();
            milk.DisplayNutritionInfo();
            milk.CheckRefrigeration();

            // Выполнение операций с товарами
            Console.WriteLine("\n\n=== ВЫПОЛНЕНИЕ ОПЕРАЦИЙ ===\n");

            // Приход товара
            warehouse.ArriveProduct("HC001", 50, "Завод-изготовитель", "Иванов А.А.");

            // Продажа товара
            warehouse.SellProduct("FP001", 30, "Магазин 'Продукты'", "Сидорова М.В.");
            warehouse.SellProduct("FP002", 50, "Магазин 'Хлеб'", "Сидорова М.В.");

            // Передача товара
            warehouse.TransferProduct("HC002", 20, "Филиал склада №2", "Козлов Д.А.");

            // Списание товара
            warehouse.WriteOffProduct("FP001", 5, "Истёк срок годности", "Петрова Е.С.");

            // Попытка продажи товара с недостаточным количеством
            warehouse.SellProduct("FP003", 100, "Ресторан 'Вкус'", "Сидорова М.В.");

            // Вывод статистики и истории
            Console.WriteLine("\n\n=== СТАТИСТИКА И ОТЧЁТЫ ===\n");
            warehouse.DisplayWarehouseStatistics();
            warehouse.DisplayOperationsSummary();
            warehouse.DisplayAllProducts();
            warehouse.DisplayOperationsHistory();

            Console.ReadKey();
        }
    }
}
