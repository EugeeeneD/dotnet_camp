using HW5;

Wrapper wrapper = new Wrapper(10, 0, 20);

wrapper.FillAnArr();

wrapper.GetFrequencyTable();

/*wrapper.PrintFrequencyTable();*/

Console.WriteLine($"Array:\n{wrapper}");

var sequences = wrapper.GetSequenceOfPrimeNumbers();

wrapper.PrintSequencesOfPrimeNumbers(sequences);
