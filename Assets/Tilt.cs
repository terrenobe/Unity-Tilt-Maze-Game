using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by Noah Terrell, 1/16/2020
public class Tilt : MonoBehaviour
{
    public AudioClip knockSound;
    public Vector3 currentRotation;
    public float MaxTilt = 10.0f;
    public float tiltSpeed = 30.0f;
    float maxX, minX, maxZ, minZ;

    // Start is called before the first frame update
    void Start()
    {
        currentRotation = this.transform.eulerAngles;
        maxX = currentRotation.x + MaxTilt;
        maxZ = currentRotation.z + MaxTilt;
        minX = currentRotation.x - MaxTilt;
        minZ = currentRotation.z - MaxTilt;
    }

    // Update is called once per frame
    void Update()
    {
        currentRotation.z += Input.GetAxis("Horizontal") * Time.deltaTime * tiltSpeed;
        currentRotation.x += Input.GetAxis("Vertical") * Time.deltaTime * tiltSpeed;

        currentRotation.z = Mathf.Clamp(currentRotation.z, minZ, maxZ);
        currentRotation.x = Mathf.Clamp(currentRotation.x, minX, maxX);
        this.transform.eulerAngles = currentRotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(knockSound, collision.contacts[0].point);
    }
}
