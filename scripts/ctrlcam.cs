using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlcam : MonoBehaviour
{
    //this script is copied from escape game project

    public float anglemin;
    public float anglemax;
    [Tooltip("vitesse angulaie (degrees par seconde)")]
    public float vitesseang;
    public GameObject axeRotation;

    private float angcourant;
    private float sens;
    private float deltang;

    private float counteur = 0;
    private float counteurmax = 3;

    // Start is called before the first frame update
    void Start()
    {
        deltang = vitesseang * 0.02f;
        sens = 1;
        angcourant = axeRotation.transform.localEulerAngles.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        angcourant += deltang * sens;
        if (angcourant <= anglemax && angcourant >= anglemin)
        {
            axeRotation.transform.Rotate(transform.up, sens * deltang);
        }
        else
        {
            angcourant -= deltang * sens;
            counteur += 0.02f;
            if (counteur >= counteurmax)
            {

                sens *= -1;
                counteur = 0;
            }
        }
    }
}
