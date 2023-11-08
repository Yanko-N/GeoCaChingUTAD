using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class cardDisplay : MonoBehaviour, IPointerDownHandler
{
    public card carta;
    [SerializeField] Text nameText;
    [SerializeField] Text descriptionText;
    [SerializeField] RawImage cursoImage;
    [SerializeField] GameObject cardHolder;
    [SerializeField] GameObject frente;
    [SerializeField] GameObject tras;
    [SerializeField] GameObject cardShowing;
    [SerializeField] GameObject canvasCardShowing;
    

    public bool allowedRotate = true;
    public bool facedUp = false;

    void Update()
    {
        if (carta != null)
        {
            nameText.text = carta.name;
            descriptionText.text = carta.description;
            cursoImage.texture = carta.imagemCurso;
        }

        

        
    }



    public void show()
    {
        frente.SetActive(true);
        tras.SetActive(false);
    }

    public void hide()
    {
        frente.SetActive(false);
        tras.SetActive(true);
    }

   
    public void OnPointerDown(PointerEventData eventData)
    {

        if (CardGameController.instance.fila[0] != null && CardGameController.instance.fila[1] != null)
        {
            return;
        }

        if (allowedRotate)
        {
            
            
            
            StartCoroutine(RotateCard());
            if (!facedUp)
            {
                if(!CardGameController.instance.cartasExpostas.Any(m=>m == carta))
                {
                    
                    
                    ShowCard();
                }
                
            }
        }
        
    }
    public void ShowCard()
    {
        cardShowing.GetComponent<CardShower>().carta = carta;
        if (CardGameController.instance.canShowCards)
        {
            CardGameController.instance.cartasExpostas.Add(carta);
            canvasCardShowing.SetActive(true);

        }

    }
    public void Rotateback()
    {
        StartCoroutine(RotateCard());
    }
    public IEnumerator RotateCard()
    {
        allowedRotate = false;
        if (!facedUp)
        {
            if (CardGameController.instance.fila[0] != null && CardGameController.instance.fila[1] != null)
            {
                //Não faz nada
            }
            else
            {
                audioManager.instance.Play("cardFlip");
                for (int i = 0; i < CardGameController.instance.fila.Length; i++)
                {
                    if (CardGameController.instance.fila[i] == null)
                    {
                        CardGameController.instance.fila[i] = this;
                        break;
                    }
                }

                for (float i = 0f; i <= 180f; i += 10)
                {
                    cardHolder.transform.rotation = Quaternion.Euler(0f, i, 0f);
                    if (i == 90)
                    {
                        show();
                    }

                    yield return new WaitForSeconds(0.01f);
                }
                facedUp = !facedUp;
                allowedRotate = true;
            }
            
        }
        else if (facedUp)
        {
            audioManager.instance.Play("cardFlip");

            for (int i = 0; i < CardGameController.instance.fila.Length; i++)
            {
                if (CardGameController.instance.fila[i] == this)
                {
                    CardGameController.instance.fila[i] = null;
                    break;
                }
            }

            for (float i = 180f; i >= 0f; i -= 10)
            {
                cardHolder.transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90)
                {
                    hide();
                }

                yield return new WaitForSeconds(0.01f);
            }
            facedUp = !facedUp;
            allowedRotate = true;
        }

        
    }

   
}
