using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardGameController : MonoBehaviour
{
    public static CardGameController instance;


    List<card> cardList = new List<card>();
    public List<cardDisplay> cardDisplays;
    public List<GameObject> cartas;
    [HideInInspector] public cardDisplay[] fila = new cardDisplay[2];

    public Text pista;
    public GameObject GameCanvas;
    public GameObject WinningCanvas;

    [HideInInspector] public List<card> cartasExpostas;

    public bool canShowCards = true;
    public Text cardShowText;


    bool canCheck = true;
    bool won = false;

    int nrMatching = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            cartasExpostas = new List<card>();
            StartCoroutine(StartCardGame(0));
            GameCanvas.SetActive(true);
            WinningCanvas.SetActive(false);
        }
        else
        {
            gameObject.Destroy();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (MiniGameController.instance.miniGameCards.Length >= 6)
        {
            foreach (var i in GetRandomNumber(6, MiniGameController.instance.miniGameCards.Length))
            {
                cardList.Add(MiniGameController.instance.miniGameCards[i]);
            }

            var randomIndex = GetRandomNumber(cardDisplays.Count, cardDisplays.Count);
            List<card> duplicatedCards = new List<card>();

            foreach (var card in cardList)
            {
                duplicatedCards.Add(card);
                duplicatedCards.Add(card);
            }

            card[] cardArray = duplicatedCards.ToArray();
            for (int i = 0; i < cardDisplays.Count; i++)
            {
                cardDisplays[randomIndex[i]].carta = cardArray[i];
            }
        }
        else
        {
            foreach (var c in MiniGameController.instance.miniGameCards)
            {
                cardList.Add(c);
            }
            var randomIndex = GetRandomNumber(cardList.Count * 2, cardList.Count * 2);

            List<card> duplicatedCards = new List<card>();
            foreach (var card in cardList)
            {
                duplicatedCards.Add(card);
                duplicatedCards.Add(card);
            }
            card[] cardArray = duplicatedCards.ToArray();
            for (int i = 0; i < cardDisplays.Count; i++)
            {
                cardDisplays[randomIndex[i]].carta = cardArray[i];
            }
        }

    }

    private void Update()
    {
        if (canShowCards)
        {
            cardShowText.text = "ON";
        }
        else
        {
            cardShowText.text = "OFF";
        }

        foreach (var c in cardDisplays)
        {
            if (c.carta == null)
            {
                cardDisplays.Remove(c);
                c.gameObject.Destroy();
            }
        }

        if (fila[0] != null && fila[1] != null)
        {
            if (canCheck)
            {
                canCheck = false;
                if (fila[0].carta == fila[1].carta)
                {
                    audioManager.instance.Play("Match");
                }
                Invoke("CheckResults", 0.8f);

            }

        }

        //Wining Situation
        if (nrMatching == cardList.Count)
        {
            if (!won)
            {
                Won();
            }
            won = true;

        }

    }


    public void ChangeCardShowerClick()
    {
        audioManager.instance.Play("clickSound");
        canShowCards = !canShowCards;
    }
    void Won()
    {
        if (GameObject.Find("CardShowerUI") != null) GameObject.Find("CardShowerUI").SetActive(false);

        audioManager.instance.Play("wonSound");
        GameCanvas.SetActive(false);
        WinningCanvas.SetActive(true);
        var p = MiniGameController.instance.pistas.First(p => p.Polo == MiniGameController.instance.miniGamePolo);

        pista.text = p.pista;
    }
    public void GoBackGameLocation()
    {
        SceneController.instance.ChangeScene("Game");
        UI_MenuManager.instance.GoBackToGameClick();

    }
    void CheckResults()
    {


        var first = fila[0];
        var second = fila[1];

        if (first.carta == second.carta)
        {

            first.allowedRotate = false;
            second.allowedRotate = false;
            nrMatching++;

            Invoke("destroyCards", 0.7f);

        }
        else
        {
            first.Rotateback();
            second.Rotateback();
        }
        fila[0] = null;
        fila[1] = null;
        canCheck = true;

    }

    void destroyCards(cardDisplay first, cardDisplay second)
    {
        first.Destroy();
        second.Destroy();
    }
    /// <summary>
    /// devolve n numeros aleatorios de 0 a Max todos diferentes
    /// </summary>
    /// <param name="n"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    int[] GetRandomNumber(int n, int max)
    {
        List<int> array = new List<int>();
        for (int i = 0; i < n; i++)
        {
            int r;
            do
            {
                r = Random.Range(0, max);
            } while (array.Contains(r));
            array.Add(r);
        }
        return array.ToArray();

    }

    public IEnumerator StartCardGame(int index)
    {
        if (cartas[index] != null)
        {
            audioManager.instance.Play("PlacingCard");
            cartas[index].SetActive(true);
        }

        yield return new WaitForSeconds(0.2f);
        if (index < 11)
        {
            StartCoroutine(StartCardGame(index + 1));
        }

    }

}
