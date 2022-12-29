using HW12.src.model;
using HW12.src.service;
using HW12.test;

CaseRoom room = new CaseRoom(3, 4, (0, 15), (15, 0));

string path = Environment.CurrentDirectory + "\\users.txt";

int time = 0;

Console.WriteLine(room);

//need 1 more method to serve users with intervals
while (time <= 100)
{
    //clients serving
    foreach (var singleCase in room.cases)
    {
        singleCase.CaseNormChecker(room);
        singleCase.UserServing(room, time);
    }

    //Serverd users
    if (time % 3 == 0) { room.SaveServedUsers(Environment.CurrentDirectory + "\\OServedUsers.txt"); }

    //create new users
    if (time % 4 == 0)
    {
        if (time == 20)
        {
            string[] data = FileHandler.ReadFile(path);
            List<User> users = Parser.ParseDataToUserList(data);
            foreach (User user in users)
            {
                room.SpawnUser(user);
            }
        }
        else { GenerateUsers.GenerateUsersForRoomPerTick(room, time); }
    }

    //control passengers group
    if (time % 5 == 0) { ControlPassengersGroup.WriteControlPassengersGroupToFile(room, time, Environment.CurrentDirectory + "\\OControlGroup.txt"); }

    //close 1 case
    if (time == 80)
    {
        room.cases[2].CloseCase(room);
    }

    //write Serverd users before closing
    if (time == 100) { room.CloseRoom(Environment.CurrentDirectory + "\\OServedUsers.txt"); }
    time += 1;
}

