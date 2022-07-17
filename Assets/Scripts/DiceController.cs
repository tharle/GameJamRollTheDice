﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour {

    public Dice dice;

    private SpriteRenderer rend;

    public bool clickable = true;

	private void Start () 
    {
        dice = new Dice();
        rend = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {

        if(dice != null && dice.sprite != null) rend.sprite = dice.ActualFace.sprite;
    }

    private void OnMouseDown()
    {
        if (clickable) RollTheDice();
    }

    public void RollTheDice() 
    {
        StartCoroutine("CoroutineRollTheDice");
    }

    private IEnumerator CoroutineRollTheDice()
    {
        clickable = false;

        for (int i = 0; i <= 20; i++)
        {
            var actualSide = Random.Range(0, dice.NSides - 1);

            // Para antes da proxima interacao
            yield return new WaitForSeconds(0.05f);
            dice.ChangeFace(actualSide);
        }

        

        Debug.Log($"Rolamos um D{dice.NSides} e o resultado foi '{dice.Value}' do tipo '{dice.Type}'");
    }
}
