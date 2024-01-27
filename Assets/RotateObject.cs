using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed; // Adjust this value to control the rotation speed

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its up (Y) axis
        transform.localEulerAngles = new Vector3(0, Mathf.PingPong(Time.time * rotationSpeed, 50) - 25, 0);
    }
}
