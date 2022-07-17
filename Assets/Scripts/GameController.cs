using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Gerenciamento da bag of dices
    public GameObject[] diceSpaces;
    private PlayerController playerController;
    void Start()
    {
        playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetTheDices()
    { 
        // Limpar os outros dados se existir

        foreach(var diceSpace in diceSpaces)
        {
            // Criar objeto na localizacao do diceSpace
            DiceController diceController = diceSpace.GetComponent<DiceController>();
            diceController.dice = playerController.GetDice();
            diceController.clickable = true;
        }
    }
}
