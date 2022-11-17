using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//it is marked on the map by red circle
//the mine can be put by player and it also reacts when enemy touches it 
//but in the place of explosing, the gaming regime turns of.

public class mine : MonoBehaviour
{
    public GameObject explosioneffect;
    public float radius = 5f;
    public float force = 700f;
    public GameObject bombe;
    public GameObject refui;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        //we press F
        if (Input.GetKey(KeyCode.F))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            bombe.gameObject.transform.parent = null;
            bombe.transform.rotation = Quaternion.identity;
            Transform player = GameObject.FindGameObjectWithTag("playerobj").transform;
            bombe.transform.position = player.position + player.forward;
            refui.SetActive(true);
        }
    }
    void explosion()
    {
        Instantiate(explosioneffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    //explosing case
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ENI")
        {
            explosion();
            ctrlENI.getInstance().explosion();
        }
    }

}