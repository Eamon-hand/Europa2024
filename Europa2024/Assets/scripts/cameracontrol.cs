using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrol : MonoBehaviour
{
    private Vector3 startPosition;
    public Transform followTarget;
    private Vector3 targetPos;
    public float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (followTarget != null)
        {
            // this code allows for the camera to follow the player.
            // I don't actually know how this works, it's magic or something
            targetPos = new Vector3(followTarget.position.y, transform.position.z);
            Vector3 velocity = (targetPos - transform.position) * moveSpeed;
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 1.0f, Time.deltaTime);
        }
    }
}
