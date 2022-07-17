using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceFace
{
    private const string RESOURCE_SPRINT_ICON = "Dice/";
    public int Value;
    public DiceType Type;

    private string spriteName;

    public string SpriteName {
        get {
            return spriteName;
        }

        set 
        {
            spriteName = value;
            sprite = Resources.Load<Sprite>($"DiceSides/{spriteName}");
        }
    }
    public Sprite sprite;

    public enum DiceType 
    { 
        NORMAL
    }
}
