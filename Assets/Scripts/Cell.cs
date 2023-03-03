using UnityEngine;

public class Cell : MonoBehaviour
{
    public int cellRow;
    public int cellCol;

    private float cellSize;
    private SpriteRenderer spriteRenderer;
    // public GameBoard gameBoard;
    private void Awake()
    {
        cellSize = 0.85f;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetCellPosition()
    {
        transform.localPosition = new Vector3(cellSize * (cellRow - 1), cellSize * (cellCol - 1), 0);
    }

    public void SetAsMarked(Sprite playerSprite)
    {
        spriteRenderer.sprite = playerSprite;
        // Disable the circle collider after it is clicked
        GetComponent<CircleCollider2D>().enabled = false;
    }

}
