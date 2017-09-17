using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerControllerY : MonoBehaviour {

    public float speed;
    public Boundary bound;

    public Rigidbody rb;

    void start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        rb.velocity = movement * speed;

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, bound.xMin, bound.xMax), Mathf.Clamp(rb.position.y, bound.yMin, bound.yMax), 0.0f);

    }

}
