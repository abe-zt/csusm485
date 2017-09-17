using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // from youtube comments, to reload scene

public class GameController : MonoBehaviour {

    public GameObject hazard;

    private Vector3[] enemySpace = new Vector3[9];  //creating array with enemycube locations to be iterated

    public Vector3 spawnValues1;
    public Vector3 spawnValues2;
    public Vector3 spawnValues3;
    public Vector3 spawnValues4;
    public Vector3 spawnValues5;
    public Vector3 spawnValues6;
    public Vector3 spawnValues7;
    public Vector3 spawnValues8;
    public Vector3 spawnValues9;

    public float waveWait;

    public float startWait;

    public int maxHazards;
    //public int minHazards;

    private int hazardCount;

    public int waveCount;
    public int stageCount;

    public GUIText waveText;
    public GUIText stageText;

    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;

    void Start ()
    {
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";


        //loading up the array with vectos containing the position oc the cubes being dodged
        enemySpace[0] = spawnValues1;
        enemySpace[1] = spawnValues2;
        enemySpace[2] = spawnValues3;
        enemySpace[3] = spawnValues4;
        enemySpace[4] = spawnValues5;
        enemySpace[5] = spawnValues6;
        enemySpace[6] = spawnValues7;
        enemySpace[7] = spawnValues8;
        enemySpace[8] = spawnValues9;

        StartCoroutine (SpawnWaves());

        stageCount = 1;
        stageText.text = "Stage: " + stageCount;
    }

    //capture keypress 'R'
   void Update()
    {
        if (restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    //spawning cubes function
    void SpawnCubes(Vector3 vector)
    {
        Vector3 spawnPosition = new Vector3(vector.x, vector.y, vector.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(hazard, spawnPosition, spawnRotation);

        hazardCount += 1;
    
    }

    //spanwaves function, based on spaceshooter
    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);     //first wave wait 
        while (true)
        {
            hazardCount = 0;    //to keep track of all the hazards, to make sure not to spawn more than the max (9)

            for (int i = 0; i < enemySpace.Length; i++)
            {
                if (Random.value > 0.5f && hazardCount < maxHazards)
                {
                    SpawnCubes(enemySpace[i]);
                    hazardCount += 1;
                }
            }

            waveCount += 1;

            waveText.text = "Wave: " + waveCount;

            if (waveCount % 5 == 0 && waveCount != 0)
            {
                waveWait -= 0.1f;
                stageCount += 1;

                stageText.text = "Stage: " + stageCount;
            }

            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = " Press 'R' to Restart";
                restart = true;
                break;
            }
        }

    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

}
