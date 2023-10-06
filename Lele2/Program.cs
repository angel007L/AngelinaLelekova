using System;

namespace Lele2
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName;
            bool hasFirstArtifact = false, hasSecondArtifact = false, hasThirdArtifact = false;
            bool hasBoxKey = false, hasDoorLockpick = false;
            int ventAttempts = 0;

            Console.WriteLine("Игрок просыпается в комнате, и пытается вспомнить свое имя.");
            Console.WriteLine("Для победы нужно найти 3 артефакта после чего активировать статую , потом открыть ящик и сбежать");
            Console.Write("Введите ваше имя: ");
            playerName = Console.ReadLine();


            while (true)
            {
                Console.WriteLine("\nЧто вы хотите сделать?");
                Console.WriteLine("1. Открыть дверь");
                Console.WriteLine("2. Заглянуть под кровать");
                Console.WriteLine("3. Открыть ящик в углу комнаты");
                Console.WriteLine("4. Открыть вентиляцию");
                Console.WriteLine("5. Взглянуть на тумбочку");
                Console.WriteLine("6. Взглянуть на статую рядом с дверью");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        if (hasDoorLockpick)
                        {
                            Console.WriteLine($"{playerName}, вы успешно сбежали!");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Дверь заперта!");
                        }
                        break;

                    case 2:
                        if (!hasFirstArtifact)
                        {
                            Console.WriteLine($"{playerName}, вы нашли первый артефакт!");
                            hasFirstArtifact = true;
                        }
                        break;

                    case 3:
                        if (hasBoxKey)
                        {
                            Console.WriteLine($"{playerName}, вы нашли отмычку!");
                            hasDoorLockpick = true;
                        }
                        else
                        {
                            Console.WriteLine("Ящик заперт!");
                        }
                        break;

                    case 4:
                        if (!hasSecondArtifact && ventAttempts < 3)
                        {
                            ventAttempts++;
                            if (ventAttempts == 3)
                            {
                                Console.WriteLine($"{playerName}, вы нашли второй артефакт!");
                                hasSecondArtifact = true;
                            }
                            else
                            {
                                Console.WriteLine("Вентиляция не открывается!");
                            }
                        }
                        break;

                    case 5:
                        if (!hasThirdArtifact)
                        {
                            Console.WriteLine($"{playerName}, вы нашли третий артефакт!");
                            hasThirdArtifact = true;
                        }
                        break;

                    case 6:
                        if (hasFirstArtifact && hasSecondArtifact && hasThirdArtifact)
                        {
                            Console.WriteLine($"{playerName}, вы нашли ключ от ящика!");
                            hasBoxKey = true;
                        }
                        else
                        {
                            Console.WriteLine("Статуя ничего не делает.");
                        }
                        break;

                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            }
        }
    }
}
