using Exam_martyuk.Classes;
using System;
using System.Collections.Generic;

namespace Exam_martyuk
{
    class Program
    {
        static void Main(string[] args)
        {
            int count;
            string way_tour_program;
            double time_program, price_program;
            List<Tour> listTours = new List<Tour>();
            TouristicAgency manager = new TouristicAgency();
            while (true)
            {
                Console.Write("Введите количество туров: ");
                try
                {
                    if(int.TryParse(Console.ReadLine(), out count))
                    {
                        if(count > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Количество должно быть больше 0!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод количества. Попробуйте снова!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.ToString()}");
                }
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Введите данные о {i + 1} - ом туре:");
                while (true)
                {
                    Console.Write("Введите направление поездки: ");
                    try
                    {
                        string line = Console.ReadLine();
                        if (string.IsNullOrEmpty(line))
                        {
                            Console.WriteLine("Пустая строка!");
                        }
                        else
                        {
                            way_tour_program = line;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.ToString()}");
                    }
                }
                while (true)
                {
                    Console.Write("Введите продолжительность поездки (например: 1,5 - считается в часах): ");
                    try
                    {
                        if (double.TryParse(Console.ReadLine(), out time_program))
                        {
                            if (time_program > 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Продолжительность не может быть меньше или равной 0. Повторите ввод!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.ToString()}");
                    }
                }
                while (true)
                {
                    Console.Write("Введите цену поездки: ");
                    try
                    {
                        if (double.TryParse(Console.ReadLine(), out price_program))
                        {
                            if (price_program > 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Цена не может быть меньше или равной 0. Повторите ввод!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.ToString()}");
                    }
                }
                Tour tour = new Tour { way_tour = way_tour_program, time = time_program, price = price_program };
                manager.tourList.Add(tour);
                Console.WriteLine();
            }
            
            manager.SortTour();
            manager.SaveToFile();
            manager.ReadToFile();

        }
    }
}
