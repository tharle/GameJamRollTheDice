using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private PlayerController playerController;
    
    public GameObject[] diceSpaces; //Dices dispo
    public Button BtnRollDices;
    public Button BtnBagOfDices;
    void Start()
    {
        playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        BtnBagOfDices.enabled = false;
        BtnRollDices.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Check BtnBagOfDices
        
    }


    public void SetTheDices()
    {
        // Limpar os outros dados se existir
        BtnBagOfDices.enabled = false;
        foreach (var diceSpace in diceSpaces)
        {
            // Criar objeto na localizacao do diceSpace
            DiceController diceController = diceSpace.GetComponent<DiceController>();
            diceController.dice = playerController.GetDice();
            diceController.clickable = true;
        }
        
        BtnRollDices.enabled = true;
    }


    public void RollAllDices()
    {
        StartCoroutine("CoroutineRollAllDices");
    }

    private IEnumerator CoroutineRollAllDices()
    {

        Debug.Log($"RollAllDices'");
        BtnRollDices.enabled = false;

        foreach (var dice in diceSpaces) 
        {
            DiceController diceController = dice.GetComponent<DiceController>();
            diceController.RollTheDice();
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(1f);
        BtnBagOfDices.enabled = true;


    }
}
