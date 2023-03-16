using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CellButton : MonoBehaviour
{
    [SerializeField] private const int CELL_SIZE = 20;
    [SerializeField] private int[] boardCoordinates = new int[2];
    private bool isMarked = false;
    public Image mark;
    public static Action<int[]> Clicked;
    public void TriggerClickEvent() // VERIFIED
    {
        Clicked?.Invoke(boardCoordinates);
        Debug.Log("Clicked " + (boardCoordinates[0], boardCoordinates[1]));
        // SetAsMarked(mark);
    }
    public void SetCellCoordinates(int row, int column) //VERIFIED
    {
        boardCoordinates[0] = row;
        boardCoordinates[1] = column;
    }
    public void SetCellPosition() //VERIFIED
    {
        // default position is  0,0 based on the center cell 
        int xPos = CELL_SIZE * (boardCoordinates[0] - 1);
        int yPos = CELL_SIZE * (boardCoordinates[1] - 1);
        transform.localPosition = new Vector3(xPos, yPos, 0);
    }
    public void SetAsMarked(Sprite playerMark) // VERIFIED
    {
        if (!isMarked)
        {
            isMarked = !isMarked;
            // Set alpha to full visibility 
            mark.sprite = playerMark;
            Color tmp = mark.color;
            tmp.a = 255;
            mark.color = tmp;
        }
    }
    public void ClearMark()
    {
        isMarked = false;
        // Set alpha to full visibility 
        mark.sprite = null;
        Color tmp = mark.color;
        tmp.a = 0;
        mark.color = tmp;
    }

}
