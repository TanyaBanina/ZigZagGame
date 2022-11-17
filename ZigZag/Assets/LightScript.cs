using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new Vector3(0,2,0);
    
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }
}
