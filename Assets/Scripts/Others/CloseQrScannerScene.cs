using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseQrScannerScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void sairQrScanner()
    {
        SceneController.instance.ChangeScene("Game");
        UI_MenuManager.instance.GoBackToGameClick();
    }
}
