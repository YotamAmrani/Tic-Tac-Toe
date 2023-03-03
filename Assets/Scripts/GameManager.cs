using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// https://www.youtube.com/watch?v=PNzXXKCw4-U&list=PLkzh1bySTmYB83ybePBUtsP4t0DAdspiw&index=2&ab_channel=UYStudios

public class GameManager : MonoBehaviour
{
    public GameBoard board;
    public Player playerA;
    public Player playerB;
    private Camera cam;
    [SerializeField] private Text boardHeadline;
    [SerializeField] private float clickRadius;

    // Start is called before the first frame update
    Player currentPlayer;
    void Start()
    {
        // Set starting player
        currentPlayer = playerA;
        cam = Camera.main;
        updateTurnHeadline();
        // TODO: Init Players
        // TODO: Init board?
    }

    public void SwitchPlayer()
    {
        currentPlayer = currentPlayer == playerA ? playerB : playerA;
    }

    void updateTurnHeadline()
    {
        boardHeadline.text = " It is player's " + currentPlayer.playerName + " turn !";
    }
    public void HandleHit(Cell clickedCell)
    {
        int row = clickedCell.cellRow;
        int col = clickedCell.cellCol;

        if (board.IsOpenCell(row, col))
        {
            // Update board logic
            board.UpdateCell(row, col, currentPlayer);
            // Update board UI
            clickedCell.SetAsMarked(currentPlayer.playerSprite);

            if (board.IsWinner(currentPlayer))
            {
                Debug.Log("We have a winner!");
                boardHeadline.text = "Player " + currentPlayer.playerName + " won !";
                SceneManager.LoadScene("EndingScene");
            }
            else if (board.IsTie())
            {
                Debug.Log("It's a Tie !");
                boardHeadline.text = "It's a Tie !";
                SceneManager.LoadScene("EndingScene");
            }
            else
            {
                SwitchPlayer();
                updateTurnHeadline();
            }
            board.PrintBoard();
        }

    }

    public void detectClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 clickPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapCircle(clickPosition, clickRadius);
            if (hit)
            {
                Cell clickedCell = hit.GetComponent<Cell>();
                HandleHit(clickedCell);
            }
        }
    }
    void Update()
    {
        detectClick();
    }
}
