using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minmapctrl : MonoBehaviour
{
    // mini map parameters
    [SerializeField] private minimapsett settings;
    [SerializeField] private float cameraheight;
    private Transform player;
    private void Awake()
    {
        settings = GetComponentInParent<minimapsett>();
        cameraheight = transform.position.y;       
    }

    // Update is called once per frame
    void Update()
    {
        //follow on player and rotate with player
        Vector3 targetposition = settings.targetfollow.transform.position;
        transform.position = new Vector3(targetposition.x, targetposition.y + cameraheight, targetposition.z);
        if (settings.rotatewithtarget)
        {
            Quaternion targetrotation = settings.targetfollow.transform.rotation;
            transform.rotation = Quaternion.Euler (90, targetrotation.eulerAngles.y, 0);
        }       
    }
      
       
}
