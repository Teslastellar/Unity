using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow2DPlatformer : MonoBehaviour
{
    public Transform target; // What the camera is following
    public float smoothing;  // Dampening effect

    Vector3 offset; // Difference between camera and player positions
    float lowY;  // Lowest Y-position of camera

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position; // Calculate difference between camer'as position and the position of the player. If target was declared as GameObject then it would've been target.transform.position
        lowY = transform.position.y; // Set current Y-position of camera as lowest possible

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

        if(transform.position.y < lowY) // In case character falls off
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
    }
}
