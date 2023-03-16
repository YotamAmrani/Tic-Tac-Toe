using UnityEngine;
using System;

public class BoardController : MonoBehaviour
{
    // private int boardSize = 3;
    // public Cell cellToInstansiate;
    public Player playerToInstansiate;
    public BoardModel boardModel;
    private Player currentPlayer;
    private int currentPlayerIndex = 0;
    private int turnsCount = 0;

    public enum Message { WIN, TIE, SWITCH };
    public static Action<Message> gameEvent;

    public void Start()
    {
        InitializeBoard();
        currentPlayer = boardModel.players[currentPlayerIndex];
        // PrintBoard();
    }

    // public void InitCells()
    // {
    //     for (int i = 0; i < BoardModel.BOARD_SIZE * BoardModel.BOARD_SIZE; i++)
    //     {
    //         Cell tempCell = Instantiate(cellToInstansiate, transform);
    //         tempCell.cellRow = (int)(i / BoardModel.BOARD_SIZE);
    //         tempCell.cellCol = (int)(i % BoardModel.BOARD_SIZE);
    //         tempCell.SetCellPosition(tempCell.cellRow, tempCell.cellCol);
    //         tempCell.name = "Cell " + i.ToString();
    //     }

    // }

    // public void DisableCells()
    // {
    //     foreach (Cell child in GetComponentsInChildren<Cell>())
    //     {
    //         if (IsOpenCell(child.cellRow, child.cellCol))
    //         {
    //             child.SetAsMarked(null);
    //         }

    //     }
    // }

    public void SwitchPlayer()
    {
        currentPlayerIndex += 1;
        currentPlayer = boardModel.players[(currentPlayerIndex) % BoardModel.PLAYERS_COUNT];
    }

    public Player GetCurrentPlayer()
    {
        return currentPlayer;
    }

    private void InitializeBoard() // VERIFIED
    {
        for (int i = 0; i < BoardModel.BOARD_SIZE; i++)
        {
            for (int j = 0; j < BoardModel.BOARD_SIZE; j++)
            {
                boardModel.board[i, j] = BoardModel.Mark.None;
            }
        }
    }

    private bool CheckRows(Player player)
    {
        for (int i = 0; i < BoardModel.BOARD_SIZE; i++)
        {
            int signCounter = 0;
            for (int j = 0; j < BoardModel.BOARD_SIZE; j++)
            {
                if (player.playerSign == boardModel.board[i, j])
                {
                    signCounter += 1;
                }
            }
            if (signCounter == BoardModel.BOARD_SIZE)
            {
                return true;
            }
        }
        return false;
    }

    private bool CheckColumns(Player player)
    {
        for (int i = 0; i < BoardModel.BOARD_SIZE; i++)
        {
            int signCounter = 0;
            for (int j = 0; j < BoardModel.BOARD_SIZE; j++)
            {
                if (player.playerSign == boardModel.board[j, i])
                {
                    signCounter += 1;
                }
            }
            if (signCounter == BoardModel.BOARD_SIZE)
            {
                return true;
            }
        }
        return false;
    }

    private bool CheckDiagonlA(Player player)
    {
        int signCounter = 0;
        for (int j = 0; j < BoardModel.BOARD_SIZE; j++)
        {
            if (player.playerSign == boardModel.board[j, j])
            {
                signCounter += 1;
            }
        }
        if (signCounter == BoardModel.BOARD_SIZE)
        {
            return true;
        }

        return false;
    }

    private bool CheckDiagonlB(Player player)
    {
        int signCounter = 0;
        for (int j = 0; j < BoardModel.BOARD_SIZE; j++)
        {
            if (player.playerSign == boardModel.board[BoardModel.BOARD_SIZE - 1 - j, j])
            {
                signCounter += 1;
            }
        }
        if (signCounter == BoardModel.BOARD_SIZE)
        {
            return true;
        }

        return false;
    }

    public void PrintBoard() // VERIFIED
    {
        string boardString = "";
        for (int i = 0; i < BoardModel.BOARD_SIZE; i++)
        {
            string line = "";
            for (int j = 0; j < BoardModel.BOARD_SIZE; j++)
            {
                line += boardModel.board[i, j] + " ";
            }
            boardString += "\n" + line;
        }
        Debug.Log(boardString);

    }

    public bool IsOpenCell(int[] cellCoordinates)
    {
        return boardModel.board[cellCoordinates[0], cellCoordinates[1]] == BoardModel.Mark.None;
    }

    public void UpdateBoard(int[] cellCoordinates)
    {
        if (IsOpenCell(cellCoordinates))
        {
            boardModel.board[cellCoordinates[0], cellCoordinates[1]] = currentPlayer.playerSign;
            turnsCount += 1;
            if (IsWinner())
            {
                // invoke winning event !
                gameEvent(Message.WIN);
            }
            else if (IsTie())
            {
                // invoke tie event
                gameEvent(Message.TIE);
            }
            else
            {
                SwitchPlayer();
                gameEvent(Message.SWITCH);
            }
            PrintBoard();
        }

    }

    public bool IsTie()
    {
        return turnsCount == BoardModel.BOARD_SIZE * BoardModel.BOARD_SIZE;
    }

    public bool IsWinner()
    {
        return CheckRows(currentPlayer) || CheckColumns(currentPlayer)
        || CheckDiagonlA(currentPlayer) || CheckDiagonlB(currentPlayer);
    }

}
