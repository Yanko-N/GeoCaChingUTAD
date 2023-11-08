using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UI_MenuManager : MonoBehaviour
{
    public static UI_MenuManager instance;

    [SerializeField] GameObject miniJogoEventUI;
    [SerializeField] GameObject gamePlayUI;
    [SerializeField] GameObject sideMenuPanel;




    enum Scenes
    {
        cardGame = 0,
        Conquistas = 1,
    }
    public void Awake()
    {
        if (instance == null) instance = this;
        else Object.Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SearchUI());
        gamePlayUI.SetActive(true);

        miniJogoEventUI.SetActive(false);
        sideMenuPanel.SetActive(false);
        miniJogoEventUI.SetActive(false);



    }

    public IEnumerator SearchUI()
    {
        while (true)
        {
            if (miniJogoEventUI == null || gamePlayUI == null || sideMenuPanel == null)
            {
                
                gamePlayUI = GameObject.FindGameObjectWithTag("GamePlayUI");

                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return new WaitForSeconds(0f);
            }


            
        }
    }


    public void DisplayGamePlayPanel()
    {

        if (miniJogoEventUI != null && gamePlayUI != null && sideMenuPanel != null)
        {
            PlaySoundClick();
            gamePlayUI.SetActive(true);
            miniJogoEventUI.SetActive(false);
            sideMenuPanel.SetActive(false);
        }



    }

    public void CloseGamePlayPanel()
    {
        if (miniJogoEventUI != null && gamePlayUI != null && sideMenuPanel != null)
        {
            PlaySoundClick();

            gamePlayUI.SetActive(false);
        }
    }

    public void DisplayStartEventPanel()
    {
        if (miniJogoEventUI != null && gamePlayUI != null && sideMenuPanel != null)
        {
            PlaySoundClick();

            miniJogoEventUI.SetActive(true);
            sideMenuPanel.SetActive(false);
            gamePlayUI.SetActive(false);
        }
    }

    public void CloseStartEventPanel()
    {
        if (miniJogoEventUI != null && gamePlayUI != null && sideMenuPanel != null)
        {
            PlaySoundClick();

            miniJogoEventUI.SetActive(false);
            sideMenuPanel.SetActive(false);
            gamePlayUI.SetActive(true);
        }
    }


    public void CloseEventPanelButtonClick()
    {
        if (miniJogoEventUI != null && gamePlayUI != null && sideMenuPanel != null)
        {
            PlaySoundClick();

            miniJogoEventUI.SetActive(false);
            gamePlayUI.SetActive(true);
            sideMenuPanel.SetActive(false);
        }
    }

    public void EnterQrScannerClick()
    {
        if (miniJogoEventUI != null && gamePlayUI != null && sideMenuPanel != null)
        {
            PlaySoundClick();

            SceneController.instance.ChangeScene(3);

            miniJogoEventUI.SetActive(false);
            gamePlayUI.SetActive(false);
            sideMenuPanel.SetActive(false);
        }
    }

    public void EnterConquistasClick()
    {
        if (miniJogoEventUI != null && gamePlayUI != null && sideMenuPanel != null)
        {
            PlaySoundClick();

            SceneController.instance.ChangeScene(2);

            miniJogoEventUI.SetActive(false);
            gamePlayUI.SetActive(false);
            sideMenuPanel.SetActive(false);
        }
    }
    public void EnterCardGameButtonClick()
    {
        if (miniJogoEventUI != null && gamePlayUI != null && sideMenuPanel != null)
        {
            PlaySoundClick();

            SceneController.instance.ChangeScene("MemoryGame");

            miniJogoEventUI.SetActive(false);
            gamePlayUI.SetActive(false);
            sideMenuPanel.SetActive(false);
        }

    }

    public void OpenSideMenuButtonClick()
    {
        if (miniJogoEventUI != null && gamePlayUI != null && sideMenuPanel != null)
        {
            PlaySoundClick();

            sideMenuPanel.SetActive(true);
            gamePlayUI.SetActive(false);
            miniJogoEventUI.SetActive(false);

        }

    }
    public void ExitSideMenuButtonClick()
    {
        if (miniJogoEventUI != null && gamePlayUI != null && sideMenuPanel != null)
        {
            PlaySoundClick();

            sideMenuPanel.SetActive(false);
            gamePlayUI.SetActive(true);
            miniJogoEventUI.SetActive(false);
        }
    }

    public void GoBackToGameClick()
    {
    
            PlaySoundClick();
            
            DisplayGamePlayPanel();

        

    }
    public void testeSceneClick()
    {
        SceneController.instance.ChangeScene("teste");
    }
    public void PlaySoundClick()
    {
        audioManager.instance.Play("clickSound");
    }
}
