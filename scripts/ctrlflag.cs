using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlflag : MonoBehaviour
{
    public List<Vector3> flagposition;

    private static ctrlflag instance;

    private SphereCollider sc;
    public bool isPlayerinsphere = false;
    // Start is called before the first frame update
    void Start()
    {
        //components
        sc = GetComponent<SphereCollider>();
        
        instance = this;

        //random location of flag
        int n = Random.Range(0, flagposition.Count);
        transform.position = flagposition[n];
    }
    public static ctrlflag getInstance()
    {
        return instance;
    }
    private GameObject GetRacine(GameObject fils)
    {
        GameObject racine = fils;
        while (racine.transform.parent != null)
        {
            racine = racine.transform.parent.gameObject;
        }
        return racine;
    }

    //if player will take the flag...
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.tag == "playerobj")
        {
            isPlayerinsphere = true;
            ctrllevel.getInstance().win();
            sc.isTrigger = false;
        }
    }
    public void restart()
    {
        isPlayerinsphere = false;
        sc.isTrigger = true;
    }
}
