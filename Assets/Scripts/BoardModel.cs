using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardModel : MonoBehaviour
{
    public enum Mark { None, X, O }
    private const int BOARD_SIZE = 3;
    private const int PLAYERS_COUNT = 2;
    private int[,] board = new int[BOARD_SIZE, BOARD_SIZE];
    public Player[] players = new Player[PLAYERS_COUNT];

}
