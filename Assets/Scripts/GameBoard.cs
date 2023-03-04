using System.Collections.Generic;
using UnityEngine;

// https://stackoverflow.com/questions/39114670/how-to-create-dynamic-table-in-unity

// Click objects
// https://www.youtube.com/watch?v=EANtTI6BCxk&ab_channel=Omnirift
public class GameBoard : MonoBehaviour
{
    private int boardSize = 3; // TODO: set to private
    public Cell cellToInstansiate;

    private int turnsCount = 0;
    List<List<Mark>> board = new List<List<Mark>>();

    public void Start()
    {
        InitializeBoard();
        InitCell();
        PrintBoard();

    }

    private void InitCell()
    {
        for (int i = 0; i < boardSize * boardSize; i++)
        {
            Cell tempCell = Instantiate(cellToInstansiate, transform);
            tempCell.cellRow = (int)(i / boardSize);
            tempCell.cellCol = (int)(i % boardSize);
            tempCell.SetCellPosition(tempCell.cellRow, tempCell.cellCol);
            tempCell.name = "Cell " + i.ToString();
            Debug.Log(tempCell.cellRow + " " + tempCell.cellCol);
        }

    }

    void InitializeBoard()
    {
        for (int i = 0; i < boardSize; i++)
        {
            board.Add(new List<Mark>());
            for (int j = 0; j < boardSize; j++)
            {
                board[i].Add(Mark.None);
            }
        }
    }

    public void PrintBoard()
    {
        string boardString = "";
        for (int i = 0; i < boardSize; i++)
        {
            string line = "";
            for (int j = 0; j < boardSize; j++)
            {
                line += board[i][j] + " ";
            }
            boardString += "\n" + line;
        }
        Debug.Log(boardString);

    }

    bool CheckRows(Player player)
    {
        for (int i = 0; i < boardSize; i++)
        {
            int signCounter = 0;
            for (int j = 0; j < boardSize; j++)
            {
                if (player.playerSign == board[i][j])
                {
                    signCounter += 1;
                }
            }
            if (signCounter == boardSize)
            {
                return true;
            }
        }
        return false;
    }

    bool CheckCol(Player player)
    {
        for (int i = 0; i < boardSize; i++)
        {
            int signCounter = 0;
            for (int j = 0; j < boardSize; j++)
            {
                if (player.playerSign == board[j][i])
                {
                    signCounter += 1;
                }
            }
            if (signCounter == boardSize)
            {
                return true;
            }
        }
        return false;
    }

    bool CheckDiagonlA(Player player)
    {
        int signCounter = 0;
        for (int j = 0; j < boardSize; j++)
        {
            if (player.playerSign == board[j][j])
            {
                signCounter += 1;
            }
        }
        if (signCounter == boardSize)
        {
            return true;
        }

        return false;
    }

    bool CheckDiagonlB(Player player)
    {
        int signCounter = 0;
        for (int j = 0; j < boardSize; j++)
        {
            if (player.playerSign == board[boardSize - 1 - j][j])
            {
                signCounter += 1;
            }
        }
        if (signCounter == boardSize)
        {
            return true;
        }

        return false;
    }

    public bool IsOpenCell(int row, int col)
    {
        return board[row][col] == Mark.None;
    }

    public bool IsTie()
    {
        return turnsCount == boardSize * boardSize;
    }
    public void UpdateCell(int row, int column, Player player)
    {
        board[row][column] = player.playerSign;
        turnsCount += 1;
    }

    public bool IsWinner(Player player)
    {
        return CheckRows(player) || CheckCol(player) || CheckDiagonlA(player) || CheckDiagonlB(player);
    }
}
