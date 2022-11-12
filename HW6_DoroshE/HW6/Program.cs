using HW6;
using HW6.models;

Accounting electricity = new Accounting(1.2, "F:\\sigma_dotnet_camp\\HW6_DoroshE\\HW6\\data\\2022-2.txt");

electricity.FillDict();

/*electricity.PrintReportIntoFile();*/

/*electricity.PrintReportForSingleApartmentIntoFile(55);*/

/*Console.WriteLine(electricity.PersonWithBiggestArrears());*/

/*foreach (var item in electricity.ExpensesPerMonth())
{
    Console.WriteLine($"{item.Key.Room} - {item.Key.Address} - {item.Key.LastName}");
    item.Value.ForEach(x => Console.Write($"{x} | "));
    Console.WriteLine("\n");
}*/

// For this change quarter to 4
/*Console.WriteLine(electricity.ApartmentsWereNoElectricityWasUsed()[0]);*/

AddressLastName PinkMan = new AddressLastName() { Address = "St.Green 7", LastName = "PinkMan", Room = 1 };

/*electricity.ExpensesForExactClientInOrder(PinkMan).ForEach(x => Console.WriteLine(x));*/

/*Console.WriteLine(electricity.ExpensesForExactClientAndMonth(PinkMan, 2));*/

/*electricity.DaysTillNow();*/

/*Console.WriteLine(electricity);*/