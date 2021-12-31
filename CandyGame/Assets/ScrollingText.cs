using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class ScrollingText : MonoBehaviour
{




    public TextMeshProUGUI t;

    public float delay = 0.1f;
    private string message =
        "ENTRY LOG 1\n" +
        "BEGINNING HUMAN TRIALS FOR TELEPORTATION\n" + "NOW INSERTING SPECIMEN 24601\n" +
        "FUSION CORE REACTOR STATUS: STABLE\n" +
        "SPECIMEN 24601 VITALS: STABLE\n" +

        "WARNING: UNKNOWN NON-HUMAN SPECIMEN DETECTED\n" +
        "MERGING HUMAN DNA WITH SUGAR, CORN SYRUP, AND HYDROGENTATED PALM OIL\n"
        + "FUSION CORE OVERLOAD\n..........\n\n" +

        "SYSTEM REBOOT HAS COMPLETED.............." +
         "\n.....\n"
        + "\n.....\n"
        + "\n.....\n"
        + "\n.....\n";

    private string message2 = "HELLO, MY NAME IS ZEGLER ROMANOV.\nI AM A QUANTUM PHYICIST FOR PROJECT RASPUTIN.\n" +
        "WE HAVE BEEN WORKING ON PROJECT RASPUTIN FOR 10 YEARS AND HAVE FINALLY PERFECTED THE QUANTUM TUNNELING.\n" +
        "BUT SOMETHING WAS NOT SUPPOSE TO ENTER THAT MACHINE AND SOMETHING WAS NOT SUPPOSE TO COME THROUGH THAT MACHINE. " +
        "IF YOU RECEIVE THIS MESSAGE, TURN OFF THE MACHINE!";

    private string message3 = "GAME INPUTS:\n" +
        "MOVEMENT:\n MOVE LEFT: A\nMOVE RIGHT: D\nJUMP: W\n" +
        "SHOOT: LEFT MOUSE CLICK\n";
    private string message4 = "             PRESS SPACE BAR TO CONTINUE             ";



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
        for (int i = 0; i < message2.Length; i++)
        {
            currText = message2.Substring(0, i + 1);
            t.text = currText;
            yield return new WaitForSeconds(delay);
        }
        for (int i = 0; i < message3.Length; i++)
        {
            currText = message3.Substring(0, i + 1);
            t.text = currText;
            yield return new WaitForSeconds(delay);
        }
        for (int i = 0; i < message4.Length; i++)
        {
            currText = message4.Substring(0, i + 1);
            t.text = currText;
            yield return new WaitForSeconds(delay);
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Level1");
        }
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
