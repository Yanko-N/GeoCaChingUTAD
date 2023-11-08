using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardShower : MonoBehaviour, IPointerDownHandler
{
    public card carta;
    [SerializeField] Text nameText;
    [SerializeField] Text descriptionText;
    [SerializeField] RawImage cursoImage;
    [SerializeField] GameObject cardHolder;
    [SerializeField] GameObject frente;
    [SerializeField] GameObject tras;
    [SerializeField] GameObject canvas;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        canvas.SetActive(false);
        

    }


    // Update is called once per frame
    void Update()
    {
        if (carta != null)
        {
            nameText.text = carta.name;
            descriptionText.text = carta.description;
            cursoImage.texture = carta.imagemCurso;
        }
    }
}
