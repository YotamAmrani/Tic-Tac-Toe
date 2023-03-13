using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUIController : MonoBehaviour
{
    public BoardModel boardModel;
    public Sprite[] playersSigns = new Sprite[BoardModel.PLAYERS_COUNT];
    [SerializeField] private Text headline;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject boardUI;
    [SerializeField] private GameObject endMenu;

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
        boardUI.SetActive(true);
    }
    public void LoadEndMenu() // VERIFIED
    {
        boardUI.SetActive(false);
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
