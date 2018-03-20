 /*
    Листинг 7
    File:   StrongNameAssembly.cs
    Author: Irina Bey
*/

// Подключаем основное пространство имён общей библиотеки классов
using System;

// В данном пространстве имён находиться атрибут AssemblyKeyFile,// используемый, для указания имени файла с криптографическими ключами
using System.Reflection;

// В данном пространстве имён находиться класс MessageBox, позволяющий// вывести на экран диалоговое окно
using System.Windows.Forms;

// Зададим имя файла с парой криптографических ключей, которые будут
// использованы для подписания данной сборки
[assembly: AssemblyKeyFile("keyPair.snk")]
// Данное пространство имён отделит типы нашей сборки от остальных
namespace TestAssembly
{
    // Тестовый класс
    public class XTest
    {
        // Функция, сообщающая пользователю о своём вызове при помощи
        // диалогового окна
        public static void Test()
        {
            MessageBox.Show("Hello World from test strong named assembly");
        }
    }
}