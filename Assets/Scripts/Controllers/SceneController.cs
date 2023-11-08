using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] string[] scenes;
    // Start is called before the first frame update
    public static SceneController instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Object.Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }
    public void ChangeScene(string s) 
    {
        SceneManager.LoadScene(s);
    }
    public void ChangeScene(int s)
    {
        SceneManager.LoadScene(scenes[s]);
    }
}
