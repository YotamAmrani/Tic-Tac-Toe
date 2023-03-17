using UnityEngine;

public class BoardModel : MonoBehaviour
{
    public enum Mark { None, X, O };
    public const int BOARD_SIZE = 3;
    public const int PLAYERS_COUNT = 2;
    public Mark[,] board = new Mark[BOARD_SIZE, BOARD_SIZE];
    public Player[] players = new Player[PLAYERS_COUNT];
}
