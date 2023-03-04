using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameBoard board;
    public Cell cellToInstansiate;
    public Player playerA;
    public Player playerB;
    private Camera cam;
    public Canvas boardUI;
    private Text boardHeadline;
    [SerializeField] private float clickRadius;

    Player currentPlayer;
    void Start()
    {
        // Set starting player
        currentPlayer = playerA;
        cam = Camera.main;
        board.InitCells();
        UpdateHeadline("Player " + currentPlayer.playerName + " - You go first...");

    }

    void Update()
    {
        DetectClick();
    }

    private void SwitchPlayer()
    {
        currentPlayer = currentPlayer == playerA ? playerB : playerA;
    }

    private void UpdateHeadline(string toDisplay)
    {
        Transform child = boardUI.transform.Find("BoardHeadline");
        Text headline = child.GetComponent<Text>();
        headline.text = toDisplay;
    }

    private void HandleHit(Cell clickedCell)
    {
        int row = clickedCell.cellRow;
        int col = clickedCell.cellCol;

        if (board.IsOpenCell(row, col))
        {
            // Update board inner logic
            board.UpdateCell(row, col, currentPlayer);
            // Update board UI
            clickedCell.SetAsMarked(currentPlayer.playerSprite);

            if (board.IsWinner(currentPlayer))
            {
                UpdateHeadline("Player " + currentPlayer.playerName + " won !");
                EndGame();
            }
            else if (board.IsTie())
            {
                UpdateHeadline("It's a Tie !");
                EndGame();
            }
            else
            {
                SwitchPlayer();
                UpdateHeadline("Player " + currentPlayer.playerName + " - it is your turn !");
            }
            // board.PrintBoard();
        }

    }

    private void DetectClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 clickPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapCircle(clickPosition, clickRadius);
            if (hit)
            {
                Cell clickedCell = hit.GetComponent<Cell>();
                Debug.Log(clickedCell.cellCol + " " + clickedCell.cellRow);
                HandleHit(clickedCell);
            }
        }
    }

    private void EndGame()
    {
        Transform child = boardUI.transform.Find("EndUI");
        child.gameObject.SetActive(true);
        board.DisableCells();
    }

}
