using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefabs;
    public Vector3 spawnPos;
    public float startDelay = 3;
    public float repeatRate = 3;
    public TextMeshProUGUI scoreText;

    public int score;
    private PlayerController playerControllerScript;
    private EnemyController enemyController;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        
        playerControllerScript = GameObject.Find("Slime").GetComponent<PlayerController>(); 
        spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        InvokeRepeating("SpawnEnemy", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        if (playerControllerScript.isGameOver == false) 
        {
            Instantiate(obstaclePrefabs, spawnPos, obstaclePrefabs.transform.rotation);
        }
    }
    
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
