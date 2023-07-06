using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homeButton : MonoBehaviour
{
    public string mainScene;
    public string guide;
    public string arScene;
    
    public void goToMainScene(){
        Application.LoadLevel(mainScene);
    }
    public void goToGuide(){
        Application.LoadLevel(guide);
    }
    public void goToArScene(){
        Application.LoadLevel(arScene);
    }
    public void exitApplication(){
        Application.Quit();
    }
}
