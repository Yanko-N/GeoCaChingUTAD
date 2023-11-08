using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTesteScript : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void randomtext()
    {
        text.text= Random.value.ToString();
    }
    public void SaveClick()
    {
       ConquistasController.instance.SaveConquistas();
    }

    public void LoadClick()
    {
        var data = ConquistasController.instance.LoadConquistasReturn();
        foreach(var c in data.conquistasActive)
        {
            text.text += "\n " + c;
        }
    }
}
