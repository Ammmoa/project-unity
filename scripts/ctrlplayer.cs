using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;



public class ctrlplayer : MonoBehaviour
{
    //for going upstears by physics
    public float facteurjump;

    //minimap
    public GameObject minimap;
    private bool minimapactive = false;

    //speed parameters
    public float vitesse;
    [Tooltip("vitesse de rotation du soldat")]
    public float vitesserotation;

    //restart
    private Vector3 posstart;
    private Quaternion posrot;

    //components
    private Rigidbody rb;
    private Animator an;

    //interface
    public Text reftext;
    public GameObject refUI;

    //transferimg functions in other scripts ****
    private static ctrlplayer instance = null;
    void Start()
    {   //****
        instance = this;

        //restart
        posrot = transform.rotation;
        posstart = transform.position;

        //components
        rb = GetComponent<Rigidbody>();
        an = transform/*.GetChild(0)*/.GetComponent<Animator>();
    }
    void Update()
    {
        //moving
        float move = Input.GetAxis("forward");
        if (move != 0)
        {
            rb.AddForce(transform.forward * vitesse * move);

        }
        float turn = Input.GetAxis("rotate");
        if (turn != 0)
        {
            transform.Rotate(transform.up * vitesserotation * turn);
        }
        //animations
        an.SetBool("movepl", move != 0 || turn != 0);

        //map   you should  press on M
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (minimapactive == false)
            {
                minimap.SetActive(true);
                minimapactive = true;
            }
            else
            {
                minimap.SetActive(false);
                minimapactive = false;
            }
        }
    }
    //****
    public static ctrlplayer getInstance()
    {
        return instance;
    }
    //restart
    public void Reinitialise()
    {
        rb.transform.position = posstart;
        rb.transform.rotation = posrot;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;    // player is not always on the same place after restart
        refUI.SetActive(false);
        ControleTime.getInstance().Reinitialiser();
        //playerdetect.getInstance().restart();  i was obliged to cancel this command                                                        ----------
        //because the script was not doing reference, but it was not always like that.                                                     !!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //so i have made references with restart button which is not practical way but which is effective in this case                     !!!!!!!!!!!!!!!!!!!!!!!!!!!!
        ctrlflag.getInstance().isPlayerinsphere = false;
        
        //ctrlENI.getInstance().restart();      in this case there will be the problem of reference which might be the problem of unity
    }

    //walking upstairs
    private void OnTriggerEnter(Collider Other)
    {
        rb.AddForce(Vector3.up * facteurjump, ForceMode.Impulse);           
    }
}
