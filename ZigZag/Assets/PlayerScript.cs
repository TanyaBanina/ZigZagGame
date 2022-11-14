using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //this determines players direction, but doesnt move him
        if (Input.GetMouseButtonDown(0))
        {
            if (direction == Vector3.back)
            {
                direction = Vector3.right;
            }
            else
            {
                direction = Vector3.back;
            }
        }
        //this thing moves the player
        float amountToMove = speed * Time.deltaTime;
        transform.Translate(direction * amountToMove);
    }
}
