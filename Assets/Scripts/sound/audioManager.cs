using UnityEngine.Audio;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class audioManager : MonoBehaviour
{

    [SerializeField]
    private sound[] sounds;

    public static audioManager instance;    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) instance = this;
        else gameObject.Destroy();

        DontDestroyOnLoad(gameObject);

        foreach (sound s in sounds)
        { 
            

            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip=s.clip;

            s.source.volume = s.volume;

            s.source.pitch = s.pitch;
            
            s.source.loop=s.loop;
            
        }
    }

    void Start()
    {
        //Play("LoFiBeatTheme");
    }
    public void Play(string name)
    {
        sound s = Array.Find(sounds, s => s.name == name);
        if (s == null) return;
        s.source.Play();
    }
    public void StopPlaying(string sound)
    {



        sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        

        s.source.Stop();
    }
}
