using UnityEngine;
public class Player
{
    public BoardModel.Mark playerSign;
    public Sprite playerSprite;
    public string playerName;

    public Player(BoardModel.Mark pSign, Sprite pSprite, string pName)
    {
        playerSign = pSign;
        playerName = pName;
        playerSprite = pSprite;
    }

}
