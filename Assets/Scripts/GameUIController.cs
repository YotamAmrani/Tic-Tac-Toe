using UnityEngine;
using UnityEngine.UI;


public class GameUIController : MonoBehaviour
{
    public BoardModel boardModel;
    [SerializeField] private Text headline;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject endMenu;
    [SerializeField] private GameObject grid;

    [SerializeField] private CellButton cellToInstantiate;

    public void UpdateHeadline(string toDisplay) // VERIFIED
    {
        // update the game headline
        headline.text = toDisplay;
    }
    public void MarkCell(int cellIndex, Sprite playerSign)
    {
        // mark the relevant cell in the board grid
    }
    public void InitCells()
    {
        // init all the cells in the board
        for (int i = 0; i < BoardModel.BOARD_SIZE; i++)
        {
            for (int j = 0; j < BoardModel.BOARD_SIZE; j++)
            {
                CellButton currentCell = Instantiate(cellToInstantiate, grid.transform);
                currentCell.SetCellCoordinates(i, j); // TODO: place in the awake?
                currentCell.SetCellPosition();
            }
        }
    }
    private int DetectClick()
    {
        // detect a cell click and trigger an event with the relevant cell index
        return 0;
    }
    public void LoadStrartMenu() // VERIFIED
    {
        startMenu.SetActive(true);
        Debug.Log("Start Menu");
    }
    public void LoadGamePanel() // VERIFIED
    {
        startMenu.SetActive(false);
        grid.SetActive(true);
    }
    public void LoadEndMenu() // VERIFIED
    {
        grid.SetActive(false);
        endMenu.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        // instanciate all cells
        // LoadStrartMenu();
    }


    // Update is called once per frame
    void Update()
    {

    }
}
