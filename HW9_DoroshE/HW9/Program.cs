using HW9.src.Service;
using HW9.src.Sort;
using HW9.test;

string path = Environment.CurrentDirectory + "\\TestCase1.txt";

//creating test file
/*RandomNumbers.CreateUnsortedFile(5, 5, 0, 10, path);*/

//split file line by line into new files
/*Split.SplitFile(path);*/

List<int> a1 = new List<int>() { 3, 1, 2, 3,6, 7 };
/*List<int> a2 = new List<int>() { 2, 5, 6  };

Sort.Merge(a1, a2).ForEach(x => Console.Write(x + " "));*/

Sort.KMergeSort(a1);
a1.ForEach(x => Console.WriteLine(x));