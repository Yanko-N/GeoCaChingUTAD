using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ICards 
{
    public Image imagem { get; set; }
    public string curso { get; set; }

    public string descricao { get; set; }
}
