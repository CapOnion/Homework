using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int Highscore;
    public int BombsExploded;

    public PlayerData(int highscore, int bombsExploded)
    {
        Highscore = highscore;
        BombsExploded = bombsExploded;
    }
}
