using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleUI : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameOverScreen gos;
    public GameObject gos;
    public Player p;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (p.isPlayerDead)
        {
            p.healthBar.gameObject.SetActive(false);
            gos.SetActive(true);

        }
    }
}
