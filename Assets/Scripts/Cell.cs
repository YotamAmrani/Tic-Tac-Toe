using UnityEngine;

public class Cell : MonoBehaviour
{
    public int cellRow;
    public int cellCol;
    private SpriteRenderer spriteRenderer;
    public GameBoard gameBoard;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cellRow = (int)(transform.GetSiblingIndex() / gameBoard.boardSize);
        cellCol = (int)(transform.GetSiblingIndex() % gameBoard.boardSize);
    }

    public void SetAsMarked(Sprite playerSprite)
    {
        spriteRenderer.sprite = playerSprite;
        // Disable the circle collider after it is clicked
        GetComponent<CircleCollider2D>().enabled = false;
    }

}
