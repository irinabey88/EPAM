/*
Листинг 2
File:   Some.cs
Author: Irina Bey
*/

// Подключаем основное пространство имён общей библиотеки классов
using System;

// Основной класс нашего приложения
class Health
{
    // Точка входа в приложение
    public static void Main()
    {
        // Сообщим пользователю о начале работы нашего приложения
        Console.WriteLine("Enter to main application");
        // Проверим модуль
        TestModule();

        Console.ReadKey();
    }

// Здесь состоится обращение к коду модуля
    public static void TestModule()
    {
        // А здесь мы используем только что созданный нами модуль,// вызовем его единственную функцию
        Sport.DoIt();
        Run.DoIt();
    }

}