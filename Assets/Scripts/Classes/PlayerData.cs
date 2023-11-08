using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public List<bool> conquistasActive = new List<bool>();
   

    public PlayerData()
    {
        foreach(var c in ConquistasController.instance.conquistas)
        {
            conquistasActive.Add(c.Active);
        }
       
    }
}
