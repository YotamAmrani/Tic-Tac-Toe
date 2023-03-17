using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BoardController boardController;
    [SerializeField] private GameUIController uIController;

    void OnEnable()
    {
        CellButton.Clicked += DetectClick;
        BoardController.gameEvent += HandleGameEvent;
    }
    void OnDisable()
    {
        CellButton.Clicked -= DetectClick;
        BoardController.gameEvent -= HandleGameEvent;

    }
    void Start()
    {
        uIController.UpdateHeadline("");
        uIController.LoadStrartMenu();
        // boardController.PrintBoard();
    }
    public void RunGame()
    {
        boardController.StartNewGame();
        uIController.LoadNewGamePanel();
        uIController.UpdateHeadline("Player " + boardController.GetCurrentPlayer().playerName
            + " it is your turn!");
    }
    private void DetectClick(int[] cellCoordinates)
    {
        // mark board with current player mark
        uIController.MarkCell(cellCoordinates, boardController.GetCurrentPlayer().playerSprite);
        // update game logic - update board, switch turn, test for endGame event
        boardController.UpdateBoard(cellCoordinates);
    }
    private void HandleGameEvent(BoardController.Message msg)
    {
        if (msg == BoardController.Message.WIN)
        {
            uIController.UpdateHeadline("Player " + boardController.GetCurrentPlayer().playerName + " win!");
            uIController.LoadEndMenu();
        }
        else if (msg == BoardController.Message.TIE)
        {
            uIController.UpdateHeadline("It's a TIE!");
            uIController.LoadEndMenu();
        }
        else
        {
            uIController.UpdateHeadline("Player " + boardController.GetCurrentPlayer().playerName
            + " it is your turn!");
        }
        // boardController.PrintBoard();

    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Qui game!");
    }

}

// Change text components to TextMeshPro
// Create animation in the right way
// Look for Permissions issues: 
// ----- board model should be private, not public

// private void HandleHit(Cell clickedCell)
// {
//     int row = clickedCell.cellRow;
//     int col = clickedCell.cellCol;

//     if (boardController.IsOpenCell(new int[] { row, col }))
//     {
//         // Update board inner logic
//         boardController.UpdateBoard(new int[] { row, col });
//         // Update board UI
//         // clickedCell.SetAsMarked(boardController.GetCurrentPlayer().playerImage);

//         if (boardController.IsWinner())
//         {
//             uIController.UpdateHeadline("Player " + boardController.GetCurrentPlayer().playerName + " won !");
//             EndGame();
//         }
//         else if (boardController.IsTie())
//         {
//             uIController.UpdateHeadline("It's a Tie !");
//             EndGame();
//         }
//         else
//         {
//             boardController.SwitchPlayer();
//             uIController.UpdateHeadline("Player " + boardController.GetCurrentPlayer().playerName + " - it is your turn !");
//         }
//         // board.PrintBoard();
//     }

// }