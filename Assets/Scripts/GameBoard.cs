using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    private int boardSize = 3;
    public Cell cellToInstansiate;

    private int turnsCount = 0;
    List<List<Mark>> board = new List<List<Mark>>();

    public void Start()
    {
        InitializeBoard();
        // PrintBoard();
    }

    public void InitCells()
    {
        for (int i = 0; i < boardSize * boardSize; i++)
        {
            Cell tempCell = Instantiate(cellToInstansiate, transform);
            tempCell.cellRow = (int)(i / boardSize);
            tempCell.cellCol = (int)(i % boardSize);
            tempCell.SetCellPosition(tempCell.cellRow, tempCell.cellCol);
            tempCell.name = "Cell " + i.ToString();
        }

    }

    public void DisableCells()
    {
        foreach (Cell child in GetComponentsInChildren<Cell>())
        {
            if (IsOpenCell(child.cellRow, child.cellCol))
            {
                child.SetAsMarked(null);
            }

        }
    }

    private void InitializeBoard()
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

    private bool CheckRows(Player player)
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

    private bool CheckColumns(Player player)
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

    private bool CheckDiagonlA(Player player)
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

    private bool CheckDiagonlB(Player player)
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

    public bool IsOpenCell(int row, int col)
    {
        return board[row][col] == Mark.None;
    }

    public void UpdateCell(int row, int column, Player player)
    {
        board[row][column] = player.playerSign;
        turnsCount += 1;
    }

    public bool IsTie()
    {
        return turnsCount == boardSize * boardSize;
    }

    public bool IsWinner(Player player)
    {
        return CheckRows(player) || CheckColumns(player) || CheckDiagonlA(player) || CheckDiagonlB(player);
    }

}
