using HW12.src.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.src.model
{
    public class Case
    {
        private readonly int _id;
        //(x ,y)
        private (int, int) _topLeft;
        private (int, int) _bottromRight;
        private Queue<User> _users;
        //лишнє, можна було б просто 2 рази розписати довше, а не створювати змінну для цього
        private (double, double) _center;
        public bool isOpen;
        public (User, int)? currentUser;

        //------------------------------------

        private readonly uint queueNorm;
        private bool queueNormFailed = false;
        private bool canGenerateUser;

        public bool QueueNormFailed { get => queueNormFailed; set => queueNormFailed = value; }
        public uint QueueNorm { get => queueNorm; }
        public bool CanGenerateUser { get => canGenerateUser; }

        public delegate void Notify(CaseRoom room, Case sCase);
        public event Notify? OutOfNorm;

        //------------------------------------

        public int Id { get => _id; }
        public (double, double) Center { get => _center; }

        //------------------------------------
        public Case(int id, (int, int) topLeft, (int, int) bottromRight, uint norm)
        {
            currentUser = null;
            isOpen = true;
            _id = id;
            _topLeft = topLeft;
            _bottromRight = bottromRight;
            _center = ((bottromRight.Item1 - topLeft.Item1) / 2.0 + topLeft.Item1, (topLeft.Item2 - bottromRight.Item2) / 2.0 + bottromRight.Item2);
            _users = new Queue<User>();

            queueNorm = norm;
            OutOfNorm += EventReaction.CloseCasesDueToOvernormQueue;
            canGenerateUser = true;
        }
        //------------------------------------

        public Queue<User> Users { get => _users; }

        public int GetUsersAmount()
        {
            return Users.Count;
        }

        public void AddUsers(IEnumerable<User> newUsers)
        {
            SortQueueWithNewUsers(newUsers);
        }

        public void AddUser(User newUser)
        {
            if (_users.Contains(newUser)) { throw new ArgumentException("User already exist in queue."); }
            if (newUser.Status == true || newUser.Age >= 50)
            {
                _users.Enqueue(newUser);
                SortQueue();
                ChangeUsersCoordinates();
            }
            else if (newUser.Status == true)
            {
                _users.Enqueue(newUser);
                SortQueue();
               ChangeUsersCoordinates();
            }
            else
            {
                _users.Enqueue(newUser);
                ChangeUserCoordinates(newUser);
            }
        }

        public void SortQueue()
        {
            List<User> temp = _users.ToList();
            temp = temp.OrderBy(x => x.Status).ThenBy(x => x.Age).ToList();
            temp.Reverse();
            _users = new Queue<User>(temp);
        }

        public void SortQueueWithNewUsers(IEnumerable<User> newUsers)
        {
            List<User> temp = _users.ToList();
            temp.AddRange(newUsers.ToList());
            temp = temp.OrderBy(x => x.Status).ThenBy(x => x.Age).ToList();
            temp.Reverse();
            _users = new Queue<User>(temp);
        }

        public void RemoveUser()
        {
            _users.Dequeue();
        }

        public void RemoveUser(User user)
        {
            var temp = Users.ToList();
            temp.Remove(user);
            temp.Reverse();
            _users = new Queue<User>(temp);
        }

        public void RemoveUsers(IEnumerable<User> users)
        {
            List<User> temp = Users.ToList();
            temp.RemoveAll(x => users.Contains(x));
            temp.Reverse();
            _users = new Queue<User>(temp);
        }

        public void UserServing(CaseRoom room, int currentTime)
        {
            if (isOpen == true)
            {
                if (currentUser.HasValue)
                {
                    if (currentUser.Value.Item1 != null)
                    {
                        if (currentUser.Value.Item2 + currentUser.Value.Item1.GetTimeToBuyAllTickets() <= currentTime)
                        {
                            room.servedUsers.Add((currentUser.Value.Item1.DeepCopy(), (currentUser.Value.Item2, currentTime), Id));
                            currentUser = null;

                            UserServing(room, currentTime);
                        }
                    }
                }
                else
                {
                    SetCurrentUserWithTime(currentTime);
                }
            }
        }

        public void CloseCase(CaseRoom room)
        {
            if (Users.Count != 0) 
            {
                var userList = Users.ToList();
                var queuesWithMinUsersAmount = room.FindCasesWithMinQueue();

                int amountOfUsersToAddToQueue = Convert.ToInt32(Math.Floor(userList.Count / queuesWithMinUsersAmount.Count * 1.0));
                int start = 0;
                int remainder = userList.Count % queuesWithMinUsersAmount.Count;
                if (remainder == 0) 
                {
                    //test
                    foreach (var queue in queuesWithMinUsersAmount)
                    {
                        queue.AddUsers(userList.GetRange(start, amountOfUsersToAddToQueue));
                        start += amountOfUsersToAddToQueue;
                    }
                }
                else
                {
                    foreach (var queue in queuesWithMinUsersAmount)
                    {
                        queue.AddUsers(userList.GetRange(start, amountOfUsersToAddToQueue + remainder));
                        start += amountOfUsersToAddToQueue;
                    }
                }    
            }
            isOpen = false;
        }

        public void SetCurrentUserWithTime(int currentTime)
        {
            var cUser = GetFirstInQueue();
            if (cUser != null)
            {
                currentUser = (cUser, currentTime);
                RemoveUser();
            }
        }

        //GetCurrentUser
        public User GetFirstInQueue()
        {
            if (!_users.TryPeek(out User user)) { return null; }
            return user;
        }

        //changing users coordinates when they enter a queue
        public User ChangeUserCoordinates(User user)
        {
            user.X = this._topLeft.Item1 - this.Users.Count;
            user.Y = this._center.Item2;
            return user;
        }

        public void ChangeUsersCoordinates()
        {
            List<User> temp = _users.ToList();
            foreach (var user in temp)
            {
                user.X = this._topLeft.Item1 - temp.IndexOf(user) - 1;
                user.Y = this._center.Item2;
            }
            _users = new Queue<User>(temp);
        }


        //------------------------------------------------------------------------------------------

        public void CaseNormChecker(CaseRoom room)
        {
            if (GetUsersAmount() > queueNorm)
            {
                if (!queueNormFailed)
                {
                    OutOfNorm?.Invoke(room, this);
                    queueNormFailed = true;
                }
                else { canGenerateUser = false; }
            }
            else if (GetUsersAmount() <= Math.Ceiling(QueueNorm / 2.0)) 
            { 
                canGenerateUser = true;
            }
        }

        //------------------------------------------------------------------------------------------


        public void CloseAndClearCase()
        {
            isOpen = false;
            _users.Clear();
            currentUser = null;
            queueNormFailed = false;
        }

        public override string ToString()
        {
            return $"Case:{Id}, {Center}";
        }
    }
}