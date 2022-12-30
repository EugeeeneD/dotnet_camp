using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW9.src.Service;

namespace HW9.src.Sort
{
    public class Sort
    {
        public static void MergeSortAction(string path)
        {
            FileHandler.SplitFile(path);

            string p0 = Environment.CurrentDirectory + "\\splited0.txt";
            string p1 = Environment.CurrentDirectory + "\\splited1.txt";

            string s0 = Environment.CurrentDirectory + "\\sorted0.txt";
            string s1 = Environment.CurrentDirectory + "\\sorted1.txt";

            List<int> numbers = Converter.GetListOfNumbersFromFile(p0);
            MergeSort(numbers, 0, numbers.Count - 1);
            FileHandler.WriteToFile(s0, Converter.IntListToString(numbers));

            numbers.Clear();
            numbers = Converter.GetListOfNumbersFromFile(p1);
            MergeSort(numbers, 0, numbers.Count - 1);
            FileHandler.WriteToFile(s1, Converter.IntListToString(numbers));

            MergeTwoSortedFiles(s0, s1);

            File.Delete(p0);
            File.Delete(p1);
            File.Delete(s0);
            File.Delete(s1);
        }

        public static void MergeSort(List<int> list, int leftPoint, int rightPoint)
        {
            if (rightPoint > leftPoint)
            {
                int mid = leftPoint + (rightPoint - leftPoint) / 2;

                MergeSort(list, leftPoint, mid);
                MergeSort(list, mid + 1, rightPoint);

                Merge(list, leftPoint, rightPoint, mid);
            }
        }

        public static void Merge(List<int> list, int leftPoint, int rightPoint, int mid)
        {

            int leftSize = mid - leftPoint + 1;
            int rightSize = rightPoint - mid;

            int[] leftHalf = new int[leftSize];
            int[] rightHalf = new int[rightSize];

            for (int l = 0; l < leftSize; l++)
                leftHalf[l] = list[leftPoint + l];
            for (int m = 0; m < rightSize; m++)
                rightHalf[m] = list[mid + 1 + m];

            //for left point
            int i = 0;
            //for right point
            int j = 0;

            int k = leftPoint;

            while (i < leftSize && j < rightSize)
            {
                if (leftHalf[i] <= rightHalf[j])
                {
                    list[k] = leftHalf[i];
                    i++;
                }
                else
                {
                    list[k] = rightHalf[j];
                    j++;
                }
                k++;
            }

            while (i < leftSize)
            {
                list[k] = leftHalf[i];
                i++;
                k++;
            }

            while (j < rightSize)
            {
                list[k] = rightHalf[j];
                j++;
                k++;
            }
        }

        public static void MergeTwoSortedFiles(string path1, string path2)
        {
            int leftSize = GetArrayFromFileCount(path1);
            int rightSize = GetArrayFromFileCount(path2);

            int left = 0;
            int right = 0;

            int leftNumber = GetNumberFromFileAtIndex(path1, left);
            int rightNumber = GetNumberFromFileAtIndex(path2, right);

            while (leftSize > left && rightSize > right)
            {
                leftNumber = GetNumberFromFileAtIndex(path1, left);
                rightNumber = GetNumberFromFileAtIndex(path2, right);

                if (leftNumber < rightNumber) 
                {
                    FileHandler.WriteNumberToResultFile(leftNumber);
                    left++;
                }
                else
                {
                    FileHandler.WriteNumberToResultFile(rightNumber);
                    right++;
                }
            }

            while (leftSize > left)
            {
                leftNumber = GetNumberFromFileAtIndex(path1, left);
                FileHandler.WriteNumberToResultFile(leftNumber);
                left++;
            }

            while (rightSize > right)
            {
                rightNumber = GetNumberFromFileAtIndex(path2, right);
                FileHandler.WriteNumberToResultFile(rightNumber);
                right++;
            }
        }

        public static int GetNumberFromFileAtIndex(string path, int index)
        {
            return Converter.GetListOfNumbersFromFile(path)[index];
        }

        public static int GetArrayFromFileCount(string path)
        {
            return Converter.GetListOfNumbersFromFile(path).Count;
        }
    }
}
