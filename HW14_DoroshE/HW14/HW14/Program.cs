using ConsoleApp1;

string connectionString = "Data Source=(local);Initial Catalog=SigmaCinemaDB;"
            + "Integrated Security=true";

CRUD test = new();

//SELECT
/*test.SelectAll(connectionString);

test.Select(connectionString);

//INSERT
*//*string queryForInserting = "INSERT INTO Movies VALUES (NEWID(), 'GTO', 'No Description');";*//*
test.Insert(connectionString);*/

//UPDATE
/*string queryForUpdating = "UPDATE Movies SET ,Description = 'Some kind of description' WHERE Name = 'GTO';";*/
test.Update(connectionString);

/*//DELETE
test.Delete(connectionString);
*/