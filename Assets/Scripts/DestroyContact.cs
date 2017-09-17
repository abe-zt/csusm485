using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;

    public GameController gameController;


    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if  (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find GameController script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

        Destroy(other.gameObject);
        Destroy(gameObject);

        gameController.GameOver();

    }

}
