using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScrollingText : MonoBehaviour
{


    public TextMeshProUGUI t;
    public float delay = 0.1f;
    private string message =
        "ENTRY LOG 1\n" +
        "BEGINNING HUMAN TRIALS FOR TELEPORTATION\n" + "NOW INSERTING SPECIMEN 24601\n" +
        "FUSION CORE REACTOR STATUS: STABLE\n" +
        "SPECIMEN 24601 VITALS: STABLE\n" +

        "WARNING: UNKNOWN SPECIMEN DETECTED\n" +
        "MERGING HUMAN DNA WITH SUGAR, CORN SYRUP, AND HYDROGENTATED PALM OIL\n"
        + "FUSION CORE OVERLOAD\n..........\n\n" +

        "SYSTEM REBOOT HAS COMPLETED\n" +
        "HELLO, MY NAME IS ZEGLER ROMANOV.I AM A QUANTUM PHYICIST FOR PROJECT RASPUTIN.\n" +
        "WE HAVE BEEN WORKING ON PROJECT RASPUTIN FOR 10 YEARS AND HAVE FINALLY PERFECTED THE QUANTUM TUNNELING.\n" +
        "BUT SOMETHING WAS NOT SUPPOSE TO ENTER THAT MACHINE AND SOMETHING WAS NOT SUPPOSE TO COME THROUGH THAT MACHINE. " +
        "IF YOU RECEIVE THIS MESSAGE, TURN OFF THE MACHINE!";







    private string currText = "";
    private void Start()
    {

        StartCoroutine(ShowText());

    }
    IEnumerator ShowText()
    {
        for (int i = 0; i < message.Length; i++)
        {
            currText = message.Substring(0, i + 1);
            t.text = currText;
            yield return new WaitForSeconds(delay);
        }
    }
    private void Update()
    {

        //if(t)
    }
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

}
