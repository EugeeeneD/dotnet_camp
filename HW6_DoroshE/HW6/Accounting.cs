using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HW6.models;

namespace HW6
{
    public class Accounting
    {
        const string folderWithReports = "F:\\sigma_dotnet_camp\\HW6_DoroshE\\HW6\\data\\reports";
        string dataFile;
        private double _priceOfKilowatt;
        private int _year;
        private int _quarter;
        private string[] _data;
        public Dictionary<AddressLastName, List<DateIndicator>> dataInDict;

        public Accounting(double priceOfKilowatt, string path)
        {
            _data = FileHandler.FileReader(path);

            dataFile = path;
            _priceOfKilowatt = priceOfKilowatt;
            _year = Convert.ToInt32(path.Split("\\")[^1].Split(".")[0][0..4]);
            _quarter = Convert.ToInt32(path.Split("\\")[^1].Split(".")[0][5].ToString());
            dataInDict = new Dictionary<AddressLastName, List<DateIndicator>>();
        }

        public void FillDict()
        {
            DataManager.TransferDataToDict(dataInDict, _data);
        }

        public bool PrintReportIntoFile()
        {
            using (StreamWriter writer = new StreamWriter(folderWithReports + $"\\report_{_year}-{_quarter}.txt"))
            {
                writer.WriteLine($"year:{_year}, quarter: {_quarter}, amount of clients: {dataInDict.Count}\n");
                foreach (var item in dataInDict)
                {
                    writer.Write(string.Format($"{item.Key.Room,-2}").PadLeft(3).PadRight(2) + $" - {item.Key.LastName,-10}: ");
                    item.Value.ForEach(x => writer.Write($"{x.Date.ToLongDateString(),-7} - {item.Value[0].Indicator,7}; "));
                    writer.WriteLine();
                }
            }
            return true;
        }

        public bool PrintReportForSingleApartmentIntoFile(int apartment)
        {
            using (StreamWriter writer = new StreamWriter(folderWithReports + $"\\report_for_{apartment}_{_year}-{_quarter}.txt"))
            {
                writer.WriteLine($"year:{_year}, quarter: {_quarter},apartment: {apartment}\n");

                var apartmentReport = dataInDict.FirstOrDefault(x => x.Key.Room == apartment);

                writer.Write(string.Format($"{apartmentReport.Key.Room,-2}").PadLeft(3).PadRight(2) + $" - {apartmentReport.Key.LastName,-10}: ");
                apartmentReport.Value.ForEach(x => writer.Write($"{x.Date.ToLongDateString(),-7} - {apartmentReport.Value[0].Indicator,7}; "));
                writer.WriteLine();
            }
            return true;
        }

        public string PersonWithBiggestArrears()
        {
            return dataInDict.MaxBy(x => x.Value[2].Indicator - x.Value[0].Indicator).Key.LastName;
        }

        public int[] ApartmentsWereNoElectricityWasUsed()
        {
            return dataInDict.Where(x => x.Value.Sum(y => y.Indicator) / 3 == x.Value[0].Indicator).Select(x => x.Key.Room).ToArray();
        }

        public Dictionary<AddressLastName, List<double>> ExpensesPerMonth()
        {
            Dictionary<AddressLastName, List<double>> res = new Dictionary<AddressLastName, List<double>>();

            DataManager.GetLastMonthPreviousQuarter(dataInDict, _year, _quarter, dataFile);

            foreach (var item in dataInDict)
            {
                var personReport = item.Value.OrderBy(x => x.Date).ToList();

                List<double> arrears = new List<double>();

                for (int i = 1; i < personReport.Count; i++)
                {
                    arrears.Add(Math.Round((personReport[i].Indicator - personReport[i - 1].Indicator) * _priceOfKilowatt, 2));
                }

                res.Add(item.Key, arrears);
            }

            return res;
        }

        public List<double> ExpensesForExactClientInOrder(AddressLastName person)
        {
            List<double> res = new List<double>();

            DataManager.GetLastMonthPreviousQuarter(dataInDict, _year, _quarter, dataFile);

            var personReport = dataInDict[DataManager.FindPersonInDict(dataInDict, person)].OrderBy(x => x.Date).ToList();

            for (int i = 1; i < personReport.Count; i++)
            {
                res.Add(Math.Round((personReport[i].Indicator - personReport[i - 1].Indicator) * _priceOfKilowatt, 2));
            }

            return res;
        }

        public double ExpensesForExactClientAndMonth(AddressLastName person, int monthOfQuarter)
        {
            if (monthOfQuarter < 0 || monthOfQuarter > 3) { throw new ArgumentOutOfRangeException("In quarter only 3 month"); }

            var res = ExpensesForExactClientInOrder(person);

            return res[monthOfQuarter];
        }

        public bool DaysTillNow()
        {
            foreach (var item in dataInDict)
            {
                Console.WriteLine($"{item.Key.Room} - {item.Key.LastName} - From {item.Value[^1].Date} Till now {DateTime.Now}: {(DateOnly.FromDateTime(DateTime.Now).DayNumber - item.Value[^1].Date.DayNumber)}");
            }

            return true;
        }

        public override string ToString()
        {
            string res = "";
            foreach (var item in dataInDict)
            {
                res += $"{item.Key.Address} - {item.Key.Room} - {item.Key.LastName}\n";
                item.Value.ForEach(x => res += $"{x.Date.ToLongDateString()} - {x.Indicator}\n");
                res += "\n";
            }
            return res;
        }
    }
}
