using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BoardController boardController;
    [SerializeField] private GameUIController uIController;

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