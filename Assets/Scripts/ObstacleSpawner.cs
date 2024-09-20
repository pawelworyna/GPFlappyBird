using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float spawnTime = 3.5f;
    [SerializeField] List<GameObject> obstacles;
    [SerializeField] float height;
    private System.Random random;
    
    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
        InvokeRepeating("SpawnObject",0f,spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
        
       
    }

    void SpawnObject()
    {
        if(!GameManagement.IsGameOver)
        {
            GameObject go = Instantiate(obstacles[random.Next(obstacles.Count)],gameObject.transform);
            go.transform.position += new Vector3(0, Random.Range(-height,height),0);
        }
       
    }
}
