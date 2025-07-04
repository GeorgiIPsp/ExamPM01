using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Exam_martyuk.Classes
{
    public class TouristicAgency
    {
        public List<Tour> tourList = new List<Tour>();

        public void SortTour()
        {
            for(int i= 0; i < tourList.Count; i++)
            {
                for(int j = 0; j < tourList.Count - 1 - i; j++)
                {
                    bool needSwap = false;
                    if(tourList[j].time < tourList[j + 1].time)
                    {
                        needSwap = true;
                    }
                    else if(tourList[j].time == tourList[j + 1].time)
                    {
                        if(tourList[j].price < tourList[j + 1].price)
                        {
                            needSwap = true;
                        }
                    }
                    if(needSwap)
                    {
                        Tour temp = tourList[j];
                        tourList[j] = tourList[j + 1];
                        tourList[j + 1] = temp;
                    }
                }
            }
        }
        //Запись в файл
        public void SaveToFile()
        {
            string filePath = "TourList";
            using (StreamWriter writer = new StreamWriter(filePath))
            { 
                foreach (var tour in tourList)
                {
                    writer.WriteLine($"Путь тура: {tour.way_tour}, Продолжительность: {tour.time:F1}, Цена: {tour.price:F2}");
                }
                writer.Close();
            }
            Console.WriteLine("Данные были добавлены в файл 'TourList'");
        }
        //Чтение из файла
        public void ReadToFile()
        {
            Console.WriteLine("Данные из файла 'TourList'");
            string filePath = "TourList";
            string line;
            using(StreamReader reader = new StreamReader(filePath))
            {
                line = reader.ReadLine();
                while(line != null)
                {
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
        }
    }
}
