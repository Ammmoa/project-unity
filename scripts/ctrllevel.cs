using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ctrllevel : MonoBehaviour
{
    //there are some functions of showing the end of the game

    private static ctrllevel instance = null;
  
    //references
    public Text reftext;
    public GameObject refUI;
    public GameObject refplayer;

    void Start()
    {
        instance = this;
    }
    public void lose()
    {
        reftext.text = "Game over";
        refUI.SetActive(true);
        ControleTime.getInstance().finishgame();
    }
    public void win()
    {
        reftext.text = "cool!!";
        refUI.SetActive(true);
        ControleTime.getInstance().finishgame();
    }

    public static ctrllevel getInstance()
    {
        return instance;
    }

    
}
