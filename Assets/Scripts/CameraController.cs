using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

	// Use this for initialization
	void Start () {

        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
    //in this case we will use LateUpdate it is "guaranteed to run after all items have been proesssed in update"
    //so we know absolutely that the player has moved for that frame
	void LateUpdate () {

        transform.position = player.transform.position + offset;

	}
}
