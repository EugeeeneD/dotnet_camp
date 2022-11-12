using HW2;

/*Task1 matrix = new Task1();*/

/*int[,] snakeMatrix1 = matrix.VerticalSnake(3, 4);
matrix.Print(snakeMatrix1);*/

/*int[,] snakeMatrix2 = matrix.DiagonalSnake(5);
matrix.Print(snakeMatrix2);*/

/*int[,] snakeMatrix3 = matrix.HorizontalSpiralSnake(3, 4);
matrix.Print(snakeMatrix3);
*/

/*int[,] snakeMatrix3 = matrix.VerticalSpiralSnake(4, 6);
matrix.Print(snakeMatrix3);*/

/*int[] pixMatrix = { 0, 1, 3, 3, 4, 4 };
int[] pixMatrix1 = { 1, 1, 1, 2};
int[] pixMatrix2 = { 1, 2, 3, 4};*/

/*Task2 matrix = new Task2();*/

/*var mat = matrix.LongestHorizontalLine(pixMatrix);
var mat1 = matrix.LongestHorizontalLine(pixMatrix1);
var mat2 = matrix.LongestHorizontalLine(pixMatrix2);*/

/*matrix.Print(mat);
matrix.Print(mat1);
matrix.Print(mat2);
*/

Task3 task3Obj = new Task3();

/*var cube1 = new int[,,] { { { 0, 1, 1 }, { 0, 1, 1 }, { 0, 1, 1 } },
                        { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } },
                        { { 1, 3, 3 }, { 3, 3, 3 }, { 3, 3, 3 } } };*/

/*var cube2 = new int[,,] { { { 0, 0, 0 }, { 1, 1, 1 }, { 1, 1, 1 } },
                        { { 0, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } },
                        { { 1, 3, 3 }, { 3, 3, 3 }, { 3, 3, 3 } } };*/

/*var cube3 = new int[,,] { { { 1, 1, 1 }, { 1, 1, 1 }, { 0, 1, 1} },
                        { { 1, 1, 2 }, { 0, 1, 2 }, { 2, 1, 1 } },
                        { { 0, 3, 1 }, { 3, 3, 1 }, { 1, 1, 1 } } };*/

/*Console.WriteLine(task3Obj.HaveThroughHole(cube3));*/
/*Console.WriteLine(task3Obj.HaveThroughHole(cube1));*/
/*Console.WriteLine(task3Obj.HaveThroughHole(cube2));*/

var cube = Task3.CreatingCube(3);

Task3.Print(cube);

Console.WriteLine(Task3.HaveThroughHole(cube));

