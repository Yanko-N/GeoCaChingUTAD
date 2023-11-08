using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestRotateScript : MonoBehaviour
{
    #region Variaveis

    [SerializeField] float speed = 50f;
    [SerializeField] float amplitude = 2f;
    [SerializeField] float frequency = 0.5f;
    [SerializeField] float offSet = 10f;
    [SerializeField] Eixo eixo = Eixo.z;

    #endregion

    // Update is called once per frame
    void Update()
    {
        FloatAndRotate();
    }

    //Method that rotates te gameobject
    void FloatAndRotate() {
        switch (eixo)
        {
            
            case Eixo.x:
                transform.Rotate(Vector3.right, speed * Time.deltaTime);
                break;
            case Eixo.y:
                transform.Rotate(Vector3.up, speed * Time.deltaTime);
                break;
            case Eixo.z:
                transform.Rotate(Vector3.forward, speed * Time.deltaTime);
                break;
        }
        
        transform.position = new Vector3(transform.position.x, (Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude) + offSet, transform.position.z);

    }

    public enum Eixo
    {
        x,y,z
    }
}
