using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
   
    public GameObject currentTile;
    public GameObject[] tilePrefabs;
    private static TileManager instance;

    public static TileManager Instance { 
        get { 
            if(instance == null) instance = GameObject.FindObjectOfType<TileManager>();
            return instance;
        } 
    }


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("i was start");
        for (int i = 0; i < 5; i++)
        {
            spawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnTile()
    {
        Debug.Log("i was here");
        int randomIndex = Random.Range(0, 2);
        currentTile = (GameObject)Instantiate(tilePrefabs[randomIndex],currentTile.transform.GetChild(0).position, 
            Quaternion.identity);
    }
}
