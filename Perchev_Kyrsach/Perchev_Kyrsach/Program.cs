using Perchev_Kyrsach.Fields;
using System.Drawing;
/*
int n = 5;
GameBoard board = new GameBoard(n);
for (int i = 0; i < n; i++)
{
    for(int j = 0; j < n; j++)
    {
        Console.Write(board.Board[i*n+j] + " ");
    }
    Console.WriteLine();
}
Console.WriteLine(board.Board[4].CellState);*/
int n = 10;
GameBoard board = new GameBoard(n);

int i = 0;
foreach (AbstractField abstractField in board.Board)
{
    if (i >= n)
    {
        Console.WriteLine();
        i = 0;
    }
    Console.Write(abstractField + " ");
    ++i;
}
Console.WriteLine("\n\n");
board.OpenCell(5, 5);
Console.WriteLine(board.ToString());