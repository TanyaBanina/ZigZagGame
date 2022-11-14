using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject leftTilePrefab;
    public GameObject topTilePrefab;
    public GameObject currentTile;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++)
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
        currentTile = (GameObject)Instantiate(topTilePrefab,currentTile.transform.GetChild(0).transform.GetChild(1).position, 
            Quaternion.identity);
    }
}
