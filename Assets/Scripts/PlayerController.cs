using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Vida
    public int HP;
    public int HPMax;

    public List<Dice> DicesPool;
    public List<Dice> DicesUsed;

    // Quantidade de dados por turno
    public int DiceMax;


    // Start is called before the first frame update
    void Start()
    {
        DicesUsed = new List<Dice>();
        DicesPool = new List<Dice>();

        for(var i = 0; i<DiceMax; i++)
        {
            DicesPool.Add(new Dice());
        }
    }

    public Dice GetDice()
    {
        Debug.Log("GET DICE");
        if (DicesPool.Count <= 0) {
            Debug.Log($"Pacode de dados vazio, recuperando....'");
            DicesPool.AddRange(DicesUsed);
            //DicesPool.Sort();
            ShuffleDices(DicesPool);
            DicesUsed = new List<Dice>();
        }

        var dice = DicesPool[0];
        DicesPool.RemoveAt(0);
        DicesUsed.Add(dice);


        Debug.Log($"DicesPool : {DicesPool.Count}'");
        Debug.Log($"DicesUsed : {DicesUsed.Count}'");

        return dice;

    }

    public void ShuffleDices(List<Dice> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, DiceMax - 1);
            Dice value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
