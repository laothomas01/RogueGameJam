using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBoss : MonoBehaviour
{
    public GameObject setBossActive; //boss. i should rename it something else
    public GameObject cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Debug.Log(scf.cameraZoomOut);
        if (collision.gameObject.tag == "Player")
        {
            cam.GetComponent<SmoothCameraFollow>().cameraZoomOut = true;
            setBossActive.SetActive(true);
        }

        if (setBossActive.GetComponent<Boss>().isDead == true)
        {
            cam.GetComponent<SmoothCameraFollow>().cameraZoomOut = false;
            Destroy(gameObject);
        }


    }
}
