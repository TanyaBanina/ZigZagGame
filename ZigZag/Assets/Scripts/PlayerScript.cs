using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10;
    public GameObject resetButton;
    private bool isDead;
    public GameObject ps;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        direction = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //this determines players direction, but doesnt move him
        if (Input.GetMouseButtonDown(0) && !isDead)
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Point")
        {
            other.gameObject.SetActive(false);
            Instantiate(ps, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Tile")
        {
            RaycastHit hit;
            Ray downRay = new Ray(transform.position, -Vector3.up);
            if(!Physics.Raycast(downRay, out hit))
            {
                isDead = true;
                resetButton.SetActive(true);
                if (transform.childCount > 0) transform.GetChild(0).transform.parent = null;
            }
        }
    }
}
