using HW6;
using HW6.models;

Accounting electricity = new Accounting(1.2, "F:\\sigma_dotnet_camp\\HW6_DoroshE\\HW6\\data\\2022-2.txt");

electricity.FillDict();

/*electricity.PrintReportIntoFile();*/

/*electricity.PrintReportForSingleApartmentIntoFile(55);*/

/*Console.WriteLine(electricity.PersonWithBiggestArrears());*/

// For this change quarter to 4
/*Console.WriteLine(electricity.ApartmentsWereNoElectricityWasUsed()[0]);*/


// not working properlu yet
/*AddressLastName morgentau = new AddressLastName() { Address = "Alexander platz 41/22", LastName = "Morgentau", Room = 25 };

electricity.ExpensesForExactClient(morgentau).ForEach(x => Console.WriteLine(x));*/

/*electricity.DaysTillNow();*/

/*Console.WriteLine(electricity);*/