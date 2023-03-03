using System.Collections.Generic;
using UnityEngine;

// https://stackoverflow.com/questions/39114670/how-to-create-dynamic-table-in-unity

// Click objects
// https://www.youtube.com/watch?v=EANtTI6BCxk&ab_channel=Omnirift
public class GameBoard : MonoBehaviour
{
    public int boardSize = 3;
    private int turnsCount = 0;
    List<List<char>> board = new List<List<char>>();

    public void Start()
    {
        InitializeBoard();
        PrintBoard();

    }
    void InitializeBoard()
    {
        for (int i = 0; i < boardSize; i++)
        {
            board.Add(new List<char>());
            for (int j = 0; j < boardSize; j++)
            {
                board[i].Add('-');
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
        return board[row][col] == '-';
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
