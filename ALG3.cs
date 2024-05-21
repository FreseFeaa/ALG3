using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Tuple<int, int>> works = new List<Tuple<int, int>>()     // ЛИСТ НАШИХ РАБОТ (НАЧАЛО,КОНЕЦ)
        {
            Tuple.Create(1, 3),
            Tuple.Create(2, 5),
            Tuple.Create(3, 6),
            Tuple.Create(4, 7),
            Tuple.Create(6, 9)
        };

        List<bool> choices = new List<bool>();

        Console.WriteLine("Для каждой работы выберите, участвовать в ней или нет (true/false):");
        foreach (var work in works)
        {
            Console.Write($"Работа с {work.Item1} по {work.Item2}: ");
            bool choice = Convert.ToBoolean(Console.ReadLine());
            choices.Add(choice);
        }

        List<Tuple<int, int>> schedule = ScheduleWorks(works, choices);

        Console.WriteLine("Ваше оптимальное расписание работ:");
        foreach (var work in schedule)
        {
            Console.WriteLine($"Работа с {work.Item1} по {work.Item2}");
        }
    }

    static List<Tuple<int, int>> ScheduleWorks(List<Tuple<int, int>> works, List<bool> choices)
    {
        var selectedWorks = new List<Tuple<int, int>>();
        for (int i = 0; i < works.Count; i++)
        {
            if (choices[i])
            {
                selectedWorks.Add(works[i]);
                for (int j = i + 1; j < works.Count; j++)
                {
                    if (works[j].Item1 < works[i].Item2 && works[j].Item2 > works[i].Item1)
                    {
                        choices[j] = false; // Отмечаем пересекающуюся работу как не выбранную
                    }
                }
            }
        }

        return selectedWorks;
    }
}




















