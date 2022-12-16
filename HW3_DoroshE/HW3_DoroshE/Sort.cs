using HW1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_DoroshE
{
    public class Sort
    {
        //pivot as last element
        public static Storage SortStoragePivotHigh(Storage storage)
        {
            var res = storage.StorageCopy.ToList();

            QuickSortLast(res, 0, res.Count - 1);

            return new Storage(res.ToDictionary(x => x.Key, y => y.Value));
        }

        public static void QuickSortLast(List<KeyValuePair<Product, int>> list, int low, int high)
        {
            if (low < high)
            {
                int pi = PartitionLast(list, low, high);
                QuickSortLast(list, low, pi - 1);
                QuickSortLast(list, pi + 1, high);
            }
        }

        private static int PartitionLast(List<KeyValuePair<Product, int>> list, int low, int high)
        {
            var pivotProduct = list[high];
            int i = low - 1;

            for (int j = low; j <= high; j++)
            {
                if (list[j].Key.Price > pivotProduct.Key.Price)
                {
                    i++;
                    Swap(list, i, j);
                }
            }
            Swap(list, i + 1, high);
            return i + 1;
        }

        //pivot as first element
        public static Storage SortStoragePivotLow(Storage storage)
        {
            var res = storage.StorageCopy.ToList();

            QuickSortFirst(res, 0, res.Count - 1);

            return new Storage(res.ToDictionary(x => x.Key, y => y.Value));
        }
        
        public static void QuickSortFirst(List<KeyValuePair<Product, int>> list, int low, int high)
        {
            if (low < high)
            {
                int pi = PartitionFirst(list, low, high);
                QuickSortFirst(list, low, pi - 1);
                QuickSortFirst(list, pi + 1, high);
            }
        }

        private static int PartitionFirst(List<KeyValuePair<Product, int>> list, int low, int high)
        {
            var pivotProduct = list[low];
            int k = high;

            for (int i = high; i > low; i--)
            {
                if (list[i].Key.Price < pivotProduct.Key.Price)
                {
                    Swap(list, i, k);
                    k--;
                }
            }
            Swap(list, k, low);
            return k;
        }

        private static void Swap(List<KeyValuePair<Product, int>> list, int indx1, int indx2)
        {
            var temp = list[indx1];
            list[indx1] = list[indx2];
            list[indx2] = temp;
        }
    }
}
