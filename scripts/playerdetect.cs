using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdetect : MonoBehaviour
{
    private static playerdetect instance;
    public bool isPlayerDetected = false;

    //components
    private MeshCollider mc;

    private void Start()
    {    
        instance = this; 
        mc = GetComponent<MeshCollider>();
    }

    public static playerdetect getInstance()
    {
        return instance;
    }

    //if the playe is in the vision area of the enemy...
    private void OnTriggerEnter (Collider Other)
    {
        if (Other.gameObject.tag == "playerobj")
        {
            isPlayerDetected = true;
            ctrllevel.getInstance().lose();
            mc.isTrigger = false;           
        }
    }  

    //fonction for easyer understanding of restart function in ctrlplayer
    public void restart()
    {
        isPlayerDetected = false;
        Debug.Log("rrrrrrrr ");
        mc.isTrigger = true;
    }
}
