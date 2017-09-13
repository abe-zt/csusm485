using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	
	// Update is called once per frame
    //we will ot be using forces, so we can use update rather than forced update
	void Update () {

        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
		
	}
}
