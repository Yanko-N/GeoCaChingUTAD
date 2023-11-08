using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    public static MiniGameController instance;

    public Auxiliar.Polo miniGamePolo;
    [SerializeField] card[] cartasAll;
    public List<PistaClass> pistas = new List<PistaClass>();
    List<card> cartas = new List<card>();
    [HideInInspector] public card[] miniGameCards;

    void Awake()
    {
        if (instance == null) instance = this;
        else gameObject.Destroy();

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        cartas.AddRange(cartasAll);
    }
    // Update is called once per frame
    void Update()
    {
        switch (miniGamePolo)
        {
            case Auxiliar.Polo.ECT://ciencas e tecnologia
                miniGameCards = cartas.Where(c => c.polo == Auxiliar.Polo.ECT).ToArray();
                break;
            case Auxiliar.Polo.ESS: // saude
                miniGameCards = cartas.Where(c => c.polo == Auxiliar.Polo.ESS).ToArray();

                break;
            case Auxiliar.Polo.ECAV: //agrarias e veterinarias
                miniGameCards = cartas.Where(c => c.polo == Auxiliar.Polo.ECAV).ToArray();

                break;
            case Auxiliar.Polo.ECHS: //humanas sociais
                miniGameCards = cartas.Where(c => c.polo == Auxiliar.Polo.ECHS).ToArray();

                break;
            case Auxiliar.Polo.ECVA: // vida e ambiente
                miniGameCards = cartas.Where(c => c.polo == Auxiliar.Polo.ECVA).ToArray();

                break;
        }
    }


}
