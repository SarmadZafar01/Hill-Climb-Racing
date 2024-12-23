using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D frontTireRb;
    [SerializeField] private Rigidbody2D backTireRb;
    [SerializeField] private Rigidbody2D carRb;
    [SerializeField] private float speed = 150f;
    [SerializeField] private float rotationSpeed = 300f;

    private float moveinput;

    private void Update()
    {
        moveinput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        frontTireRb.AddTorque(-moveinput * speed*Time.fixedDeltaTime );
        backTireRb.AddTorque(-moveinput* speed*Time.fixedDeltaTime) ;
        carRb.AddTorque(moveinput*rotationSpeed*Time.fixedDeltaTime);
    }
}
