using System;

namespace Authorization
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            SmsSender smsSender = new SmsSender();

            Console.WriteLine("Введите логин");
            user.SetLogin(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("Введите и повторите пароль");
                if (!ReadPassword(user))
                {
                    Console.WriteLine("Пароли не совпадают");

                }
                else break;
            }

            Console.WriteLine("Введите почту");
            while (true)
            {
                if (!user.ReadEmail(Console.ReadLine()))
                {
                    Console.WriteLine("Неверный формат почты");

                }
                else break;
            }

            Console.WriteLine("Введите номер телефона");
            user.SetNumber(Console.ReadLine());

            smsSender.SetKey();
            Console.WriteLine("Введите проверочный код");
            smsSender.SendSMS(user, "abc");
            while (true)
            {                
                if (smsSender.SendSMS(user, Console.ReadLine()))
                {
                    Console.WriteLine("Регистрация прошла успешно");
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный код");
                }
            }

            Console.ReadLine();                          
        }
        static public bool ReadPassword(User user)
        {
            string firstPassword = "";
            string secondPassword = "";

            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter)
            {
                Console.Write("*");
                key = Console.ReadKey(true);
                firstPassword += key.KeyChar;
            }

            Console.WriteLine();

            key = Console.ReadKey(true);

            while (key.Key != ConsoleKey.Enter)
            {
                Console.Write("*");
                key = Console.ReadKey(true);
                secondPassword += key.KeyChar;
            }

            Console.WriteLine();

            if (firstPassword != secondPassword)
            {
                return false;
            }
            else
            {
                user.SetPassword(firstPassword);
                return true;
            }
        }
    }
}