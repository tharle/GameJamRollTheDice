using UnityEngine;


public class Dice
{
    // lista de lados do dados
    public DiceFace[] DiceFaces;

    //Tamanho dos dados
    public int NSides = 6;

    // Qual é a face que está sendo mostrada
    public DiceFace ActualFace;

    public int Value {
        get {
            return ActualFace != null ? ActualFace.Value : 0;
        }
    }

    public DiceFace.DiceType? Type
    {
        get
        {
            return ActualFace?.Type;
        }
    }

    public Sprite sprite
    {
        get
        {
            return ActualFace?.sprite; 
        }
    }

    public Dice() 
    {
        DiceFaces = new DiceFace[NSides];
        for (var i = 0; i < NSides; i++)
        {
            DiceFaces[i] = new DiceFace
            {
                SpriteName = $"NORMAL_{i}",
                Value = i + 1,
                Type = DiceFace.DiceType.NORMAL
            };
        }

        ActualFace = DiceFaces[0];
        
    }

    public void ChangeFace(int actualSide) 
    {
        if (actualSide < 0) actualSide = 0;
        if (actualSide > NSides - 1) actualSide = NSides - 1;

        ActualFace = DiceFaces[actualSide];
    }
}
