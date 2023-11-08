using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName ="New Card",menuName ="Card")]
public class card : ScriptableObject
{
    public new string name;
    public string description;
    public Texture2D imagemCurso;
    public Auxiliar.Polo polo;
   
}
