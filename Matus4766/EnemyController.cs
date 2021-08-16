using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 30;
    private PlayerController playerControllerScript;
    public float leftBound;
    public int targetScore = 1;

    public SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Slime").GetComponent<PlayerController>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (playerControllerScript.isGameOver == false)
        { transform.Translate(Vector3.left * Time.deltaTime * speed); }

        if (transform.position.x < leftBound && gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            
            spawnManager.UpdateScore(targetScore);
        }


    }

    


}
