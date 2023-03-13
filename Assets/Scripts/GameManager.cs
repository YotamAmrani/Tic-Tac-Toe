using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public BoardController boardController;
    public Cell cellToInstansiate;
    public Player playerA;
    public Player playerB;
    // private Camera cam;
    // public Canvas boardUI;
    public GameUIController uIController;

    private Text boardHeadline;
    [SerializeField] private float clickRadius;

    // Player currentPlayer;
    void Start()
    {
        // Set starting player
        // currentPlayer = playerA;
        // cam = Camera.main;
        // board.InitCells(); //TODO: to fix
        // uIController.UpdateHeadline("Player " + boardController.GetCurrentPlayer().playerName + " - You go first...");
        boardController.PrintBoard();
    }

    void Update()
    {
        // DetectClick();
    }


    private void HandleHit(Cell clickedCell)
    {
        int row = clickedCell.cellRow;
        int col = clickedCell.cellCol;

        if (boardController.IsOpenCell(row, col))
        {
            // Update board inner logic
            boardController.UpdateCell(row, col);
            // Update board UI
            clickedCell.SetAsMarked(boardController.GetCurrentPlayer().playerSprite);

            if (boardController.IsWinner(boardController.GetCurrentPlayer()))
            {
                uIController.UpdateHeadline("Player " + boardController.GetCurrentPlayer().playerName + " won !");
                EndGame();
            }
            else if (boardController.IsTie())
            {
                uIController.UpdateHeadline("It's a Tie !");
                EndGame();
            }
            else
            {
                boardController.SwitchPlayer();
                uIController.UpdateHeadline("Player " + boardController.GetCurrentPlayer().playerName + " - it is your turn !");
            }
            // board.PrintBoard();
        }

    }

    private void DetectClick()
    {
        // if (Input.GetMouseButtonUp(0))
        // {
        //     Vector2 clickPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        //     Collider2D hit = Physics2D.OverlapCircle(clickPosition, clickRadius);
        //     if (hit)
        //     {
        //         Cell clickedCell = hit.GetComponent<Cell>();
        //         HandleHit(clickedCell);
        //     }
        // }
    }

    private void EndGame()
    {
        // Transform child = boardUI.transform.Find("EndUI");
        // child.gameObject.SetActive(true);
        // boardController.DisableCells();
        uIController.LoadEndMenu();
    }



    // load start UI
    // load game run
    // load end UI
    // check for clicks events
    // update board
    // look for special cases
    //  update UI
}
