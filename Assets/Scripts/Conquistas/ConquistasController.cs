using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ConquistasController : MonoBehaviour
{
    public static ConquistasController instance;
    public ConquistaObject[] conquistas;




    void Awake()
    {

        if (instance == null) instance = this;
        else gameObject.Destroy();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if(File.Exists(Application.persistentDataPath + "/achivments.utad"))
        {
            var data = LoadConquistasReturn();
            if (data != null && data.conquistasActive.Count == conquistas.Length)
            {
                for (int i = 0; i < conquistas.Length; i++)
                {
                    conquistas[i].Active = data.conquistasActive[i];
                }
            }
        }
        else
        {
            SaveConquistas();
        }
    }

    public void SaveConquistas()
    {
        string path = Application.persistentDataPath + "/achivments.utad";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream Writestream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData();

        formatter.Serialize(Writestream, data);
        Writestream.Close();

    }

    public void LoadConquistas()
    {
        string path = Application.persistentDataPath + "/achivments.utad";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            if(data != null && data.conquistasActive.Count == conquistas.Length)
            {
                for(int i = 0; i < conquistas.Length; i++)
                {
                    conquistas[i].Active = data.conquistasActive[i];
                }
            }
        }
    }
    public PlayerData LoadConquistasReturn()
    {
        string path = Application.persistentDataPath + "/achivments.utad";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }

}
