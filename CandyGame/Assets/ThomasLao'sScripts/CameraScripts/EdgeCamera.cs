using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCamera : MonoBehaviour
{


    //object being followed
    private Transform target;
    // Start is called before the first frame update
    private Vector3 target_Offset;

    private Vector2 target_prev_position;

    public float radiusFromCenterOfScreen;

    private void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
        target_Offset = transform.position - target.position;
    }
    // Update is called once per frame
    private void Update()
    {

        CameraEdgeMovement();

    }
    private void CameraEdgeMovement()
    {

        //this script can be improved
        if (Vector2.Distance(target.transform.position, transform.position) > radiusFromCenterOfScreen)     //we have a radius from center of screen: for both x and y coordinates
        {
            Vector2 delta_position; //change in position
            delta_position = (Vector2)target.transform.position - target_prev_position; // delta = target's position - target's previous position
            transform.Translate(delta_position);
        }
        target_prev_position = target.position;



    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, radiusFromCenterOfScreen);
    }

}
