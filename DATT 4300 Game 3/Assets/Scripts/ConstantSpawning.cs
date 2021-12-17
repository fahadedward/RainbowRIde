using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSpawning : MonoBehaviour
{
    TileSpawning tileSpawning;
    [SerializeField]
    GameObject blocks;
    [SerializeField]
    Transform[] blockSpawnPoints;
    [SerializeField]
    Transform[] coinSpawnPoints;
    [SerializeField]
    Transform[] planetSpawnPoints;
    [SerializeField]
    Transform[] mushroomSpawnPoints;
    int randomBlockSpawn;
    int randomBlockSpawn2;
    int randomCoinSpawn;
    GameObject obstacles;
    [SerializeField]
    GameObject leafs;

    GameObject leafObject;
    [SerializeField]
    GameObject[] planets;
    [SerializeField]
    GameObject luckyMushroom;
    [SerializeField]
    int[] randomPlanetSpawner;

    int planetSpawner;
    PlayerMovement player;
    Timer timer;
    private void Awake()
    {
        randomBlockSpawn = Random.Range(0, blockSpawnPoints.Length);
        randomBlockSpawn2 = Random.Range(0, blockSpawnPoints.Length);
        randomCoinSpawn = Random.Range(0, coinSpawnPoints.Length);
        player = FindObjectOfType<PlayerMovement>();
        timer = FindObjectOfType<Timer>();
       
    }
    void Start()
    {

        if (player.SpeedIncrease >= 29)
        {
                Instantiate(luckyMushroom, new Vector3(mushroomSpawnPoints[randomBlockSpawn].transform.position.x,
                mushroomSpawnPoints[randomBlockSpawn].transform.position.y + 0.3f, 
                mushroomSpawnPoints[randomBlockSpawn].transform.position.z), Quaternion.identity);
        }
        planetSpawner = Random.Range(0, 5);
        tileSpawning = FindObjectOfType<TileSpawning>();
        if(randomBlockSpawn != randomCoinSpawn)
        {
            for (int i = 0; i < 5; i++)
            {
                    leafObject = Instantiate(leafs, new Vector3(coinSpawnPoints[randomCoinSpawn].transform.position.x,
                    coinSpawnPoints[randomCoinSpawn].transform.position.y + 0.35f,
                    coinSpawnPoints[randomCoinSpawn].transform.position.z + i),
                    Quaternion.identity);
                    leafObject.transform.parent = transform;
            }
        }
        if(planetSpawner > 3)
        {
            for (int i = 0; i < 2; i++)
            {
                randomPlanetSpawner[i] = Random.Range(0, 6);
                Instantiate(planets[randomPlanetSpawner[i]], planetSpawnPoints[i]);
            }
        }
        if(randomBlockSpawn == randomBlockSpawn2)
        {
            randomBlockSpawn = Random.Range(0, blockSpawnPoints.Length);
            randomBlockSpawn2 = Random.Range(0, blockSpawnPoints.Length);
        }
        if(randomBlockSpawn != randomBlockSpawn2 && timer.Timerr > 500000f)
        {
            obstacles = Instantiate(blocks, blockSpawnPoints[randomBlockSpawn2].transform.position, Quaternion.identity);
            obstacles.transform.parent = transform;
        }
        obstacles = Instantiate(blocks, blockSpawnPoints[randomBlockSpawn].transform.position, Quaternion.identity);
    }
    private void OnTriggerExit(Collider other)
    {
        tileSpawning.SpawnTiles();
        Destroy(gameObject, 3);
    }
    void Update()
    {
        if (randomBlockSpawn == randomCoinSpawn || randomBlockSpawn2 == randomCoinSpawn)
        {
            randomCoinSpawn = Random.Range(0, coinSpawnPoints.Length);
        }
    }
}
