using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObstacles : MonoBehaviour
{

    [SerializeField] private List<GameObject> obstacleList;
    private int spawnInterval = 11;
    private int lastSpawnZ = 22;
    private int spawnAmount = 4;
    //[SerializeField] private Vector3 _spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObstaculo();
    }

    public void SpawnObstaculo()
    {
        lastSpawnZ += spawnInterval;

        for (int i = 0; i < spawnAmount; i++)
        {
            if (Random.Range(0,4) == 0)
            {
                int randomIndex = Random.Range(0,obstacleList.Count);
                GameObject obstacle = obstacleList[randomIndex];
                //                               
                Instantiate(obstacle, new Vector3(0,-0.25f, lastSpawnZ), Quaternion.identity);
            }
        }
    }
}
