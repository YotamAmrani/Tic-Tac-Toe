using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Worked fine with the background object
public class Clicker : MonoBehaviour
{
    public GameManager gameManager;
    public Transform boardPosition;
    public BoxCollider2D boardCollider;
    void OnMouseDown()
    {
        Vector2 cellCoordinates = ExctractCellCoordinates();
        // gameManager.HandleClick(cellCoordinates);
    }

    Vector2 ExctractCellCoordinates2()
    {
        Vector2 clickPosition = UnityEngine.Input.mousePosition;
        Vector2 cellDimensions = boardCollider.size / gameManager.board.boardSize;
        Debug.Log("click: " + clickPosition);
        Debug.Log("cell dim: " + cellDimensions);

        // float cellwidth = boardCollider.size[1] / gameManager.board.boardSize;
        // float cellheight = boardCollider.size[0] / gameManager.board.boardSize;
        clickPosition -= (Vector2)boardPosition.position;

        return new Vector2(Mathf.Floor(clickPosition[1] / cellDimensions[0]), Mathf.Floor(clickPosition[0] / cellDimensions[1]));
    }

    Vector2 ExctractCellCoordinates()
    {
        Vector2 currentPosition = UnityEngine.Input.mousePosition;

        float cellwidth = Screen.width / gameManager.board.boardSize;
        float cellheight = Screen.height / gameManager.board.boardSize;
        return new Vector2(Mathf.Floor(currentPosition[1] / cellheight), Mathf.Floor(currentPosition[0] / cellwidth));
    }

}
