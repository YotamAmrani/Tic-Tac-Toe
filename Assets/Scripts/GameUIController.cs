using UnityEngine;
using UnityEngine.UI;


public class GameUIController : MonoBehaviour
{
    [SerializeField] private Text headline;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject endMenu;
    [SerializeField] private GameObject grid;
    [SerializeField] private CellButton cellToInstantiate;


    public void Start()
    {
        InitCells();
    }
    private void InitCells() // VERIFIED
    {
        // init all the cells in the board
        for (int i = 0; i < BoardModel.BOARD_SIZE; i++)
        {
            for (int j = 0; j < BoardModel.BOARD_SIZE; j++)
            {
                CellButton currentCell = Instantiate(cellToInstantiate, grid.transform);
                currentCell.SetCellCoordinates(i, j);
                currentCell.SetCellPosition();
            }
        }
    }
    public void UpdateHeadline(string toDisplay) // VERIFIED
    {
        // update the game headline
        headline.text = toDisplay;
    }
    public void MarkCell(int[] cellCoordinates, Sprite playerMark)
    {
        int cellIndex = (cellCoordinates[0] * BoardModel.BOARD_SIZE) + cellCoordinates[1];
        // Get the relevant cell based on it's coordinates:
        GameObject cellToMark = grid.transform.GetChild(cellIndex).gameObject;
        CellButton c = cellToMark.GetComponent<CellButton>();
        Debug.Log("Index: " + cellIndex);
        c.SetAsMarked(playerMark);
    }
    public void LoadStrartMenu() // VERIFIED
    {
        grid.SetActive(false);
        endMenu.SetActive(false);
        startMenu.SetActive(true);
        Debug.Log("Start Menu");
    }
    public void LoadNewGamePanel() // VERIFIED
    {
        startMenu.SetActive(false);
        endMenu.SetActive(false);
        ClearCells();
        grid.SetActive(true);
    }
    public void LoadEndMenu() // VERIFIED
    {
        // grid.SetActive(false);
        endMenu.SetActive(true);
    }
    public void ClearCells()
    {
        foreach (Transform cell in grid.transform)
        {
            CellButton c = cell.gameObject.GetComponent<CellButton>();
            c.ClearMark();
        }
    }

}