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
            res.AppendLine($"--------- time: {time} ---------");

            for (int i = 0; i < room.cases.Count; i++)
            {
                var tempCasa = room.cases[i];
                res.AppendLine($"Case id: {tempCasa.Id} - {tempCasa.CanGenerateUser}");

                int j = 1;
                foreach (var user in tempCasa.Users)
                {
                    res.AppendLine($"{j}. {user}");
                    j++;
                }
                j = 1;
            }

            FileHandler.WriteToFile(res.ToString(), path);
        }
    }
}
