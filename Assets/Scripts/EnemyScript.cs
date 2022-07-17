using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int HP;
    public int HPMax;
    public MonsterType Type;
    public Dice MonsterDice;
    public GameObject HPBar;
    private float originalXBarLife;

    // Start is called before the first frame update
    void Start()
    {
        originalXBarLife = HPBar.transform.localScale.x;
        initDiceMonster();
    }

    // Update is called once per frame
    void Update()
    {
        // atualizacao da barra de vida do inimigo
        var scaleBarLife = originalXBarLife * (float)HP / (float)HPMax;
        HPBar.transform.localScale = new Vector3(scaleBarLife, HPBar.transform.localScale.y, HPBar.transform.localScale.z);
    }

    public void initDiceMonster()
    {
        switch (Type) 
        {
            case MonsterType.SLIME:
                break;
            default:
                break;
        }
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;

        Debug.Log($"O Monstro '{Type}' tomou {damage} de dano. '");

        if (HP <= 0)
        {
            HP = 0;

            // Then die
        }
    }

    public enum MonsterType
    {
        SLIME,
        GOBLIN,
        ORC
    }
}
