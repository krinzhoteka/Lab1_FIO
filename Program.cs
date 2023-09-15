using System;
using System.IO;
using System.Collections.Generic;

class TriangleCalculator
{
    static void Main()
    {
        // Создаем файл для логирования
        string logFilePath = "log.txt";
        StreamWriter logFile = new StreamWriter(logFilePath, true);

        // Получаем входные данные от пользователя
        Console.WriteLine("Введите длину стороны A:");
        string inputA = Console.ReadLine();
        Console.WriteLine("Введите длину стороны B:");
        string inputB = Console.ReadLine();
        Console.WriteLine("Введите длину стороны C:");
        string inputC = Console.ReadLine();

        // Логируем входные данные
        Log(logFile, $"Входные данные: A = {inputA}, B = {inputB}, C = {inputC}");

        // Попробуем преобразовать входные данные в числа
        if (double.TryParse(inputA, out double sideA) &&
            double.TryParse(inputB, out double sideB) &&
            double.TryParse(inputC, out double sideC))
        {
            // Вычисляем тип треугольника
            string triangleType = GetTriangleType(sideA, sideB, sideC);

            // Если треугольник валидный, вычисляем координаты вершин
            List<(int, int)> vertices = new List<(int, int)>();
            if (triangleType != "не треугольник")
            {
                vertices = CalculateVertices(sideA, sideB, sideC);
            }

            // Выводим результат
            Console.WriteLine($"Тип треугольника: {triangleType}");
            Log(logFile, $"Тип треугольника: {triangleType}");

            foreach ((int x, int y) vertex in vertices)
            {
                Console.WriteLine($"Координаты вершины: ({vertex.x}, {vertex.y})");
                Log(logFile, $"Координаты вершины: ({vertex.x}, {vertex.y})");
            }
        }
        else
        {
            // Логируем ошибку ввода
            Console.WriteLine("Ошибка: Некорректный ввод данных.");
            Log(logFile, "Ошибка: Некорректный ввод данных.");
        }

        // Закрываем файл лога
        logFile.Close();

        Console.WriteLine("Нажмите любую клавишу для выхода.");
        Console.ReadKey();
    }

    static string GetTriangleType(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
        {
            return "не треугольник";
        }
        else if (a == b && b == c)
        {
            return "равносторонний";
        }
        else if (a == b || b == c || a == c)
        {
            return "равнобедренный";
        }
        else
        {
            return "разносторонний";
        }
    }

    static List<(int, int)> CalculateVertices(double a, double b, double c)
    {
        // Здесь вычислите координаты вершин треугольника
        // Например, можно отмасштабировать координаты для поля 100x100 px

        // В данном примере, просто возвращаем фиксированные значения
        List<(int, int)> vertices = new List<(int, int)>
        {
            (10, 10),   // Вершина A
            (90, 10),   // Вершина B
            (50, 90)    // Вершина C
        };

        return vertices;
    }

    static void Log(StreamWriter logFile, string message)
    {
        // Записываем сообщение в лог и в консоль
        string logMessage = $"{DateTime.Now}: {message}";
        Console.WriteLine(logMessage);
        logFile.WriteLine(logMessage);
    }
}
