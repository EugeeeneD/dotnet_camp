using HW12.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.src.service
{
    public class EventReaction
    {
        public static void CloseCasesDueToOvernormQueue(CaseRoom room, Case sCase)
        {
            var overnormUsers = sCase.Users.Skip((int)sCase.QueueNorm).ToList();

            try
            {
                foreach (var user in overnormUsers)
                {
                    List<Case> casesWithMinQueue = room.FindCasesWithMinQueue(sCase).ToList();

                    if (casesWithMinQueue[0].GetUsersAmount() >= sCase.GetUsersAmount()) { throw new ArgumentException(); }

                    if (casesWithMinQueue.Count == 1) { casesWithMinQueue[0].AddUser(user.DeepCopy()); }
                    else { user.GetCaseWithMinDistanceInbetween(casesWithMinQueue).AddUser(user.DeepCopy()); }
                    sCase.RemoveUser(user);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("no cases available.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Other cases have more or same amount of user.");
            }

        }
    }
}
