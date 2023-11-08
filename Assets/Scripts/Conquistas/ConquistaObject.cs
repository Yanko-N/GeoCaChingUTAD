using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "New Conquista", menuName = "Conquista")]

public class ConquistaObject : ScriptableObject
{
    public new string name;
    public GameObject trofeu;
    public string description;
    public string qrCodeText;
    public Color color;
    public bool Active = false;

}
