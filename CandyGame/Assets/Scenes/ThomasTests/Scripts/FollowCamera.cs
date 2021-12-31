using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform followTarget;
    private Camera camera;
    Vector3 newPosition;
    public float xOffset,yOffset,zOffSet=1f;
    public float bound,speed,x,y;
    public float xDistance, yDistance, w, h;
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
    void Update()
    {

        //Debug.DrawRay(new Vector2(xEdge,transform.position.y) , Vector2.up * 100, Color.red);
        //Debug.DrawRay(new Vector2(-xEdge, transform.position.y), Vector2.up * 100, Color.red);
        //Debug.DrawRay(new Vector2(transform.position.x,yEdge), Vector2.right * 100, Color.green);
        //Debug.DrawRay(new Vector2(transform.position.x, -yEdge), Vector2.right * 100, Color.green);

        // get the X and Y position of the follow target and the Z position of the camera.
        // if the camera Z position is zero or position, the screen will be blank, so we are setting it to -10 (any negative number will work)
        //if (followTarget.position.x > Screen.width - bound)
        //{
        //    x += speed * Time.deltaTime;
        //}
        //if (followTarget.position.x < bound)
        //{
        //    x -= speed * Time.deltaTime;
        //}
        //if (followTarget.position.y > Screen.height - bound)
        //{
        //    y += speed * Time.deltaTime;
        //}
        //if (followTarget.position.x <  bound)
        //{
        //    y -= speed * Time.deltaTime;
        //}

        w = Screen.width;
        h = Screen.height;
        xDistance = followTarget.position.x - w;
        yDistance = followTarget.position.y - h;
        // set camera position to new position
        newPosition = new Vector3(x + xOffset, y + yOffset, zOffSet);
        transform.position = newPosition;
    }
}
