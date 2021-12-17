using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawning : MonoBehaviour
{
    [SerializeField]
    GameObject tiles;
    [SerializeField]
    Vector3 spawnPoint;

   
    public GameObject Tiles
    {
        get { return tiles; }
    }
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnTiles();
        }
    }
    // Update is called once per frame

    public void SpawnTiles()
    {
        GameObject nextTile = Instantiate(tiles, spawnPoint, Quaternion.identity);
        spawnPoint = nextTile.transform.GetChild(1).transform.position;
    }
}

//[SerializeField]
//List<GameObject> little;
/*  little = little.OrderBy(little => little.transform.position.z).ToList();
        
        }*/
