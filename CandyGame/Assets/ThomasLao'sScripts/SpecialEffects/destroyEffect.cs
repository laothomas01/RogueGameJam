using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEffect : MonoBehaviour
{


    private void Update()
    {

        Destroy(this.gameObject, 0.4f);
    }

}
