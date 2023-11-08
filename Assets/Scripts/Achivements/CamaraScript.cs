using Microsoft.Maps.Unity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CamaraScript : MonoBehaviour
{
    [SerializeField][Range(1, 20)] float panSpeed = 1.0f;
     GameObject[] conquistas;

    Color currentColor = Color.white;
    [SerializeField] GameObject CaixaTexto;

    [SerializeField] Text text;

    Vector3 initialMousePosition;
    Vector3 finalMousePosition;

    bool samePress = false;

    public float deadZone = 150;

    int currentIndex;
    List<GameObject> list = new List<GameObject>();
    List<ConquistaObject> listConquistaInfo = new List<ConquistaObject>();

    private void Awake()
    {
        currentIndex = 0;
        var helper = 0;


        ConquistasController.instance.LoadConquistas();

        if (ConquistasController.instance.conquistas != null)
        {

            foreach (var conquista in ConquistasController.instance.conquistas)
            {
                if (conquista.Active == true)
                {
                    var gameObject = conquista.trofeu;
                    var newGameObject = Instantiate(gameObject, new Vector3(helper, 0, 0), gameObject.transform.rotation);
                    list.Add(newGameObject);
                    listConquistaInfo.Add(conquista);
                    helper += 30;
                }

            }
        }


        conquistas = list.ToArray();


    }

    private void Start()
    {
        if (listConquistaInfo.Count > 0)
            text.text = listConquistaInfo[0].description;
    }

    private void Update()
    {

        if (!samePress)
        {
            if (Input.GetMouseButtonDown(0))
            {
                initialMousePosition = Input.mousePosition;
                samePress = true;
            }
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                finalMousePosition = Input.mousePosition;
                samePress = false;
                CamaraLogic();

            }
        }
        if (conquistas == null || conquistas.Length == 0)
        {
            transform.position = new Vector3(0, 0, -20);
            text.text = "Não Encontrou nenhuma conquista ainda";
        }
        else
        {

            if (currentIndex >= 0 || currentIndex <= conquistas.Length - 1)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Light>().color = currentColor;
                var smoothedPostion = Vector3.Lerp(transform.position, new Vector3(conquistas[currentIndex].transform.position.x, transform.position.y, transform.position.z), panSpeed * Time.deltaTime);

                transform.position = smoothedPostion;
                
            }
        }



    }

    void CamaraLogic()
    {
        if (CalculateXDifference() == 0) return;

        if (CalculateXDifference() > deadZone)
        {
            if (samePress) return;

            if (currentIndex <= 0) return;

            //esquerda
            currentIndex--;

        }
        else if (CalculateXDifference() < -deadZone)
        {
            if (samePress) return;
            //direita
            if (currentIndex >= conquistas.Length - 1) return;
            currentIndex++;
        }
        if (Mathf.Abs(CalculateXDifference()) > deadZone)
        {
            text.text = listConquistaInfo[currentIndex].description;
            CaixaTexto.SetActive(true);
        }



    }


    /// <summary>
    /// Devolve a diferenca em distancia em X 
    /// </summary>
    /// <returns></returns>
    float CalculateXDifference()
    {
        return finalMousePosition.x - initialMousePosition.x;
    }



    public void GoBackToGameClick()
    {
        SceneController.instance.ChangeScene("Game");
        UI_MenuManager.instance.GoBackToGameClick();

    }


}
