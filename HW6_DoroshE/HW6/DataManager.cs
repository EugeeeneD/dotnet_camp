using HW6.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public class DataManager
    {
        public static void TransferDataToDict(Dictionary<AddressLastName, List<DateIndicator>> dict, string[] data)
        {
            for (int i = 1; i < data.Length; i++)
            {
                var splited = data[i].Split("|");

                var person = new AddressLastName() { Room = Convert.ToInt32(splited[0]), Address = splited[1], LastName = splited[2] };

                if (!IsAlreadyInDict(dict, person))
                {
                    dict.Add(person, new List<DateIndicator>()
                    {
                        new DateIndicator(){ Date = DateOnly.Parse(splited[3]), Indicator = Convert.ToDouble(splited[4]) },
                        new DateIndicator(){ Date = DateOnly.Parse(splited[5]), Indicator = Convert.ToDouble(splited[6]) },
                        new DateIndicator(){ Date = DateOnly.Parse(splited[7]), Indicator = Convert.ToDouble(splited[8]) }
                    });
                }
            }
        }

        public static bool IsAlreadyInDict(Dictionary<AddressLastName, List<DateIndicator>> res, AddressLastName obj)
        {
            foreach (AddressLastName item in res.Keys)
            {
                if (item.Equals(obj)) { return true; }
            }
            return false;
        }

        public static AddressLastName FindPersonInDict(Dictionary<AddressLastName, List<DateIndicator>> res, AddressLastName obj)
        {
            foreach (AddressLastName item in res.Keys)
            {
                if (item.Equals(obj)) { return item; }
            }
            return null;
        }

        public static bool GetLastMonthPreviousQuarter(Dictionary<AddressLastName, List<DateIndicator>> dict, int currentYear, int currentQuarter, string path)
        {
            int year, quarter;

            if (currentQuarter == 1) 
            {
                year = currentYear - 1;
                quarter = 4;
            }
            else 
            {
                quarter = currentQuarter - 1;
                year = currentYear;
            }

            var temp = path.Split("\\").ToList();

            temp.RemoveAt(temp.Count - 1);

            string newPath = "";
            temp.ForEach(x => newPath += x + "\\");
            newPath += $"{year}-{quarter}.txt";


            var str = FileHandler.FileReader(newPath);

            for (int i = 1; i < str.Length; i++)
            {
                var splited = str[i].Split("|");

                var person = new AddressLastName() { Room = Convert.ToInt32(splited[0]), Address = splited[1], LastName = splited[2] };
                DateIndicator info = new DateIndicator() { Date = DateOnly.Parse(splited[7]), Indicator = Convert.ToDouble(splited[8]) };

                if (IsAlreadyInDict(dict, person))
                {
                    if (!DoesListContainsDateIndicator(dict[FindPersonInDict(dict, person)], info)) { dict[FindPersonInDict(dict, person)].Add(info); Console.WriteLine(info.Indicator); }
                }
            }

/*            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key.LastName}");
                item.Value.ForEach(x => Console.Write(x.Date));
            }*/

            return true;
        }

        public static bool DoesListContainsDateIndicator(List<DateIndicator> list, DateIndicator info)
        {
            foreach (var item in list)
            {
                if(item.Equals(info)) { return false; }
            }

            return false; 
        }
    }
}
