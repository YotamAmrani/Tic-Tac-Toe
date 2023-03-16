using UnityEngine;

public class Cell : MonoBehaviour
{
    public int cellRow;
    public int cellCol;

    [SerializeField] private float cellSize;
    private SpriteRenderer spriteRenderer;
    // public GameBoard gameBoard;
    private void Awake()
    {
        cellSize = 0.85f;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetCellPosition(int cellRow, int cellCol)
    {
        // Calculate the cell location based on the cell size, its and location on board
        transform.localPosition = new Vector3(cellSize * (cellRow - 1), cellSize * (cellCol - 1), 0);
    }

    // public void SetAsMarked(Sprite playerSprite)
    // {
    //     spriteRenderer.sprite = playerSprite;
    //     // Disable the circle collider after it is clicked
    //     GetComponent<CircleCollider2D>().enabled = false;
    // }

}
