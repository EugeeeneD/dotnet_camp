using HW9.src.Service;
using HW9.src.Sort;
using HW9.test;

string path = Environment.CurrentDirectory + "\\TestCase1.txt";

//creating test file
/*RandomNumbers.CreateUnsortedFile(5, 5, 0, 10, path);*/

Sort.MergeSortAction(path);