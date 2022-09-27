using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autito : MonoBehaviour
{
    public Rigidbody rb;
    public float speed= 18;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(hAxis, 0, vAxis)* speed * Time.deltaTime;

        rb.MovePosition( transform.position + move );
    }
}
