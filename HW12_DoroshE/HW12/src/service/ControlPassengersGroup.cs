using HW12.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.src.service
{
    public class ControlPassengersGroup
    {
        public static void WriteControlPassengersGroupToFile(CaseRoom room, int time, string path)
        {
            StringBuilder res = new();

            for (int i = 0; i < room.cases.Count; i++)
            {
                var tempCasa = room.cases[i];
                res.AppendLine($"Case id: {tempCasa.Id}");

                int j = 1;
                foreach (var user in tempCasa.Users)
                {
                    res.AppendLine($"{j}. {user}");
                    j++;
                }
                j = 1;
                res.AppendLine($"--------- time: {time} ---------");
            }

            FileHandler.WriteToFile(res.ToString(), path);
        }
    }
}
