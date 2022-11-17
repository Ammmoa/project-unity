using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleTime : MonoBehaviour
{
    //script is  created for showing time tesult on the interface

    //components and modifiers
    float time;
    private static ControleTime instance = null;
    //references
    public Text refText;
    // Start is called before the first frame update
    void Start()
    {       
        time = (int)Time.time;
        instance = this;
    }

    public void finishgame()
    {
        refText.text = ((int)Time.time - (int)time).ToString();
    }

    public void Reinitialiser()
    {
        time = (int)Time.time;
    }
    public static ControleTime getInstance()
    {
        return instance;
    }
}
