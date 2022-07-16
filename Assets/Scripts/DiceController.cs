using System.Collections;
using UnityEngine;

public class DiceController : MonoBehaviour {

    // lista de lados do dados
    public DiceFace[] diceFaces;

    //Tamanho dos dados
    public int nSides;

    // Qual é a face que está sendo mostrada
    public DiceFace actualFace;

    private SpriteRenderer rend;

    public bool clickable = true;

	private void Start () {
        rend = GetComponent<SpriteRenderer>();


        //diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        intValueDices();
    }

    private void intValueDices()
    {
        diceFaces = new DiceFace[nSides];
        for (var i = 0; i < nSides; i++)
        {
            diceFaces[i] = new DiceFace
            {
                SpriteName = $"NORMAL_{i}",
                Value = i+1,
                Type = DiceFace.DiceType.NORMAL
            };
        }

        actualFace = diceFaces[0];
    }

    private void LateUpdate()
    {
        rend.sprite = actualFace.Sprite;
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
            var actualSide = Random.Range(0, nSides - 1);

            // Para antes da proxima interacao
            yield return new WaitForSeconds(0.05f);

            actualFace = diceFaces[actualSide];
        }

        

        Debug.Log($"Rolamos um D{nSides} e o resultado foi '{actualFace.Value}' do tipo '{actualFace.Type}'");
    }
}
