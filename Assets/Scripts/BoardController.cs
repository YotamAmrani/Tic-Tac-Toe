using UnityEngine;
using System;

public class BoardController : MonoBehaviour
{
    private BoardModel boardModel;
    [SerializeField] private GameUIController uIController;
    [SerializeField] private Sprite[] playersSprites = new Sprite[BoardModel.PLAYERS_COUNT];

    private Player currentPlayer;
    private int currentPlayerIndex = 0;
    private int turnsCount = 0;

    public enum GameState { WIN, TIE, SWITCH };

    void Start()
    {
        // Init the board model object Once, when launching the game scene
        boardModel = new BoardModel();
        InitializePlayers();
        StartNewGame();
    }

    void OnEnable()
    {
        CellButton.Clicked += DetectClick;
    }

    void OnDisable()
    {
        CellButton.Clicked -= DetectClick;
    }

    public void StartNewGame()
    {
        InitializeBoard();
        currentPlayer = boardModel.players[currentPlayerIndex];
        turnsCount = 0;
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

    private void InitializePlayers()
    {
        for (int i = 0; i < BoardModel.PLAYERS_COUNT; i++)
        {
            boardModel.players[i] = new Player((BoardModel.Mark)(i + 1), playersSprites[i], "" + (char)(((int)'A') + i));
        }
    }

    private void SwitchPlayer()
    {
        currentPlayerIndex = (currentPlayerIndex + 1) % BoardModel.PLAYERS_COUNT;
        currentPlayer = boardModel.players[currentPlayerIndex];
    }

    public Player GetCurrentPlayer()
    {
        return currentPlayer;
    }

    private bool CheckRows()
    {
        for (int i = 0; i < BoardModel.BOARD_SIZE; i++)
        {
            int signCounter = 0;
            for (int j = 0; j < BoardModel.BOARD_SIZE; j++)
            {
                if (currentPlayer.playerSign == boardModel.board[i, j])
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

    private bool CheckColumns()
    {
        for (int i = 0; i < BoardModel.BOARD_SIZE; i++)
        {
            int signCounter = 0;
            for (int j = 0; j < BoardModel.BOARD_SIZE; j++)
            {
                if (currentPlayer.playerSign == boardModel.board[j, i])
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

    private bool CheckDiagonlA()
    {
        int signCounter = 0;
        for (int j = 0; j < BoardModel.BOARD_SIZE; j++)
        {
            if (currentPlayer.playerSign == boardModel.board[j, j])
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

    private bool CheckDiagonlB()
    {
        int signCounter = 0;
        for (int j = 0; j < BoardModel.BOARD_SIZE; j++)
        {
            if (currentPlayer.playerSign == boardModel.board[BoardModel.BOARD_SIZE - 1 - j, j])
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

    private bool IsOpenCell(int[] cellCoordinates)
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
                HandleGameEvent(GameState.WIN);
            }
            else if (IsTie())
            {
                // invoke tie event
                HandleGameEvent(GameState.TIE);
            }
            else
            {
                SwitchPlayer();
                HandleGameEvent(GameState.SWITCH);
            }
            PrintBoard();
        }

    }

    private bool IsTie()
    {
        return turnsCount == BoardModel.BOARD_SIZE * BoardModel.BOARD_SIZE;
    }

    private bool IsWinner()
    {
        return CheckRows() || CheckColumns()
        || CheckDiagonlA() || CheckDiagonlB();
    }

    private void DetectClick(int[] cellCoordinates)
    {
        // mark board with current player mark
        uIController.MarkCell(cellCoordinates, GetCurrentPlayer().playerSprite);
        // update game logic - update board, switch turn, test for endGame event
        UpdateBoard(cellCoordinates);
    }

    private void HandleGameEvent(BoardController.GameState msg)
    {
        if (msg == BoardController.GameState.WIN)
        {
            uIController.UpdateHeadline("Player " + GetCurrentPlayer().playerName + " win!");
            uIController.LoadEndMenu();
        }
        else if (msg == BoardController.GameState.TIE)
        {
            uIController.UpdateHeadline("It's a TIE!");
            uIController.LoadEndMenu();
        }
        else
        {
            uIController.UpdateHeadline("Player " + GetCurrentPlayer().playerName
            + " it is your turn!");
        }
        // boardController.PrintBoard();

    }

}
