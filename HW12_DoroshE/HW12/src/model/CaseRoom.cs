using HW12.src.model.tickets;
using HW12.src.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.src.model
{
    public class CaseRoom
    {
        public (int, int) topLeftRoom;
        public (int, int) bottromRightRoom;
        public int _caseWidth;
        public List<Case> cases;
        //customer, serving ended, case id
        public List<(User, (int, int), int)> servedUsers; 

        public CaseRoom(int amountOfCases, int caseWidth, (int, int) topLeft, (int, int) bottromRight)
        {
            _caseWidth = caseWidth;
            servedUsers = new();
            cases = new();

            topLeftRoom = topLeft;
            bottromRightRoom = bottromRight;
            int deltaY = Convert.ToInt32(Math.Floor(topLeft.Item2 / amountOfCases * 1.0));

            int caseStarXtCoordinate = bottromRight.Item1 - caseWidth;
            int caseEndXCoordinate = bottromRight.Item1;

            // bottom right position of case
            int caseEndYCoordinate = 0;
            // top left position of case
            int caseStarYtCoordinate = deltaY;

            for (int i = 0; i < amountOfCases; i++)
            {
                cases.Add(new Case(i, (caseStarXtCoordinate, caseStarYtCoordinate), (caseEndXCoordinate, caseEndYCoordinate)));
                caseEndYCoordinate = caseStarYtCoordinate;
                caseStarYtCoordinate += deltaY;
            }
        }

        //------------------------------------------------------------------------------------------

        public void SpawnUser(int x, int y, string name, int age, bool status, List<ITicket> tickets)
        {
            if (!CheckIfPlaceIsFree(x, y)) { throw new ArgumentOutOfRangeException("User cannot be spawn in this coordinates."); }
            User newUser = new User(x, y, name, age, status, tickets);
            List<Case> casesWithMinQueue = FindCasesWithMinQueue();
            try
            {
                if (casesWithMinQueue.Count == 1) { casesWithMinQueue[0].AddUser(newUser); }
                else { newUser.GetCaseWithMinDistanceInbetween(casesWithMinQueue).AddUser(newUser); }
                FileHandler.WriteToFile(newUser.ToString(), Environment.CurrentDirectory + "\\OAllUsers.txt");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("there are no case, so user cannot be added to case queue");
            }
        }

        public void SpawnUser(User user)
        {
            if (!CheckIfPlaceIsFree(user.X, user.Y)) { throw new ArgumentOutOfRangeException("User cannot be spawn in this coordinates."); }
            List<Case> casesWithMinQueue = FindCasesWithMinQueue();
            try
            {
                if (casesWithMinQueue.Count == 1) { casesWithMinQueue[0].AddUser(user); }
                else { user.GetCaseWithMinDistanceInbetween(casesWithMinQueue).AddUser(user); }
                FileHandler.WriteToFile(user.ToString(), Environment.CurrentDirectory + "\\OAllUsers.txt");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("there are no case, so user cannot be added to case queue");
            }
        }

        public bool CheckIfPlaceIsFree(double x, double y)
        {
            //out of room boundery
            if (y >= topLeftRoom.Item2 || y <= bottromRightRoom.Item2)
            {
                return false;
            }
            if (x <= topLeftRoom.Item1 || x >= bottromRightRoom.Item1)
            {
                return false;
            }

            foreach (var queue in cases)
            {
                //inside cases
                if (x >= bottromRightRoom.Item1 - _caseWidth) { return false; }
                foreach (var user in queue.Users)
                {
                    //already in taken place
                    if (x == user.X && y == user.Y) { return false; }
                }
            }

            return true;
        }

        //------------------------------------------------------------------------------------------

        public List<Case> FindCasesWithMinQueue()
        {
            if (cases.Count == 0) { throw new ArgumentOutOfRangeException("List with cases contains 0 elements."); }
            int min = cases.Where(x => x.isOpen == true).Min(x => x.GetUsersAmount());
            return cases.Where(x => x.GetUsersAmount() == min).ToList();
        }

        public void SaveServedUsers(string path)
        {
            foreach (var user in servedUsers)
            {
                FileHandler.WriteToFile($"User: {user.Item1}, Serving started at: {user.Item2.Item1}, Serving ended at: {user.Item2.Item2}, Case id: {user.Item3}", path);
            }
            servedUsers.Clear();
        }

        public void CloseRoom(string path)
        {
            SaveServedUsers(path);
            CloseAndClearCases();
        }

        public void CloseAndClearCases()
        {
            foreach (var sCase in cases)
            {
                sCase.CloseAndClearCase();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            foreach (var queue in cases)
            {
                sb.AppendLine($"Case: {queue.Id} - center coordinates: ({queue.Center})");
                foreach (var user in queue.Users)
                {
                    sb.AppendLine(user.ToString());
                }
            }
            return sb.ToString();
        }
    }
}
