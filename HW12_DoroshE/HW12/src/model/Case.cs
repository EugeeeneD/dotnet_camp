using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.src.model
{
    public class Case
    {
        private int _id;
        //(x ,y)
        private (int, int) _topLeft;
        private (int, int) _bottromRight;
        private Queue<User> _users;
        private (double, double) _center;
        public bool isOpen;
        public (User, int)? currentUser;

        public int Id { get => _id; }
        public (double, double) Center { get => _center; }

        public Case(int id, (int, int) topLeft, (int, int) bottromRight)
        {
            currentUser = null;
            isOpen = true;
            _id = id;
            _topLeft = topLeft;
            _bottromRight = bottromRight;
            _center = ((bottromRight.Item1 - topLeft.Item1) / 2.0 + topLeft.Item1, (topLeft.Item2 - bottromRight.Item2) / 2.0 + bottromRight.Item2);
            _users = new Queue<User>();
        }

        public Queue<User> Users { get => _users; }

        public int GetUsersAmount()
        {
            return _users.Count;
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

        public void UserServing(CaseRoom room, int currentTime)
        {
            if (isOpen != false)
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
            var cUser = GetCurrentUser();
            if (cUser != null)
            {
                currentUser = (cUser, currentTime);
                RemoveUser();
            }
        }

        public User GetCurrentUser()
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

        public void CloseAndClearCase()
        {
            isOpen = false;
            _users.Clear();
            currentUser = null;
        }

        public override string ToString()
        {
            return $"Case:{Id}, {Center}";
        }
    }
}