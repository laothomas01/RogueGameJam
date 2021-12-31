using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform followTarget;
    private Camera camera;
    Vector3 newPosition;
    public float xOffset,yOffset,zOffSet=1f;
    public float xbound,ybound,xSpeed,ySpeed,x,y;
    public float xDistance, yDistance, w, h,distance;
    private void Start()
    {
        //Cursor.visible = false;
    }
    void Awake()
    {
        // get the Camera component when the game runs
        // note if this script is not on the same GameObject as the Camera component, there will be an error
        camera = GetComponent<Camera>();
        newPosition = transform.position;
        x = transform.position.x;
        y = transform.position.y;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        

        w = transform.position.x;
        h = transform.position.y;
        distance = followTarget.position.x;
        if (followTarget.position.x > w + xbound)
        {
            x += xSpeed * Time.fixedDeltaTime;
        }
        if (followTarget.position.x <w-xbound)
        {
            x -= xSpeed * Time.fixedDeltaTime;
        }
        if (followTarget.position.y > h + ybound)
        {
            y += ySpeed * Time.fixedDeltaTime;
        }
        if (followTarget.position.y < h - ybound)
        {
            y -= ySpeed * Time.fixedDeltaTime;
        }


        // set camera position to new position
        newPosition = new Vector3(x + xOffset, y + yOffset, zOffSet);
        transform.position = newPosition;
    }
}
