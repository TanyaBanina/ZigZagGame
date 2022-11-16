using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileManager : MonoBehaviour
{
   
    public GameObject currentTile;
    public GameObject[] tilePrefabs;
    private static TileManager instance;
    private Stack<GameObject> leftTiles = new Stack<GameObject>();
    private Stack<GameObject> topTiles = new Stack<GameObject>();

    public static TileManager Instance { 
        get { 
            if(instance == null) instance = GameObject.FindObjectOfType<TileManager>();
            return instance;
        } 
    }

    public Stack<GameObject> LeftTiles { get => leftTiles; set => leftTiles = value; }
    public Stack<GameObject> TopTiles { get => topTiles; set => topTiles = value; }


    // Start is called before the first frame update
    void Start()
    {
        createTiles(22);
        for (int i = 0; i < 22; i++)
        {
            spawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void createTiles(int amount)
    {
        for(int i = 0;i<amount; i++)
        {
            LeftTiles.Push(Instantiate(tilePrefabs[0]));
            TopTiles.Push(Instantiate(tilePrefabs[1]));
            LeftTiles.Peek().name = "LeftTile";
            TopTiles.Peek().name = "TopTile";
            TopTiles.Peek().SetActive(false);
            LeftTiles.Peek().SetActive(false);
        }
    }
    public void spawnTile()
    {
        //if(LeftTiles.Count == 0 || LeftTiles.Count == 0) { createTiles(10); }

        int randomIndex = Random.Range(0, 2);
        if(randomIndex == 0)
        {
            GameObject tmp = LeftTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).position;
            currentTile = tmp;
        }
        else if(randomIndex == 1){
            GameObject tmp = TopTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).position;
            currentTile = tmp;
        }
        int pointIndex = Random.Range(0, 10);
        if(pointIndex == 0)
        {
            currentTile.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
