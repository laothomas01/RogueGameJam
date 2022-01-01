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
        "ENTRY LOG 1\n\n" +
        "BEGINNING HUMAN TRIALS FOR TELEPORTATION\n\n" + "NOW INSERTING SPECIMEN 24601\n\n" +
        "FUSION CORE REACTOR STATUS: STABLE\n\n" +
        "SPECIMEN 24601 VITALS: STABLE\n\n" +

        "WARNING: UNKNOWN NON-HUMAN SPECIMEN DETECTED\n\n" +
        "MERGING HUMAN DNA WITH SUGAR, CORN SYRUP, AND HYDROGENTATED PALM OIL\n\n"
        + "FUSION CORE OVERLOAD\n..........\n\n" +

        "SYSTEM REBOOT HAS COMPLETED.............." +
         "\n............................\n"
        + "\n...........................\n"
        + "\n...........................\n"
        + "\n...........................\n";

    private string message2 = "HELLO, MY NAME IS ZEGLER ROMANOV.\n\nI AM A QUANTUM PHYSICIST FOR PROJECT RASPUTIN\n\n" +
        "WE HAVE BEEN WORKING ON PROJECT RASPUTIN FOR 10 YEARS AND HAVE FINALLY PERFECTED THE QUANTUM TUNNELING\n\n" +
        "BUT SOMETHING WAS NOT SUPPOSE TO ENTER THAT MACHINE AND SOMETHING WAS NOT SUPPOSE TO COME THROUGH THAT MACHINE\n\n" +
        "IF YOU RECEIVE THIS MESSAGE, TURN OFF THE MACHINE!";

    private string message3 = "[================= GAME CONTROLS =================]\n" +
        "[=================== MOVE LEFT: A ===============]\n [================== MOVE RIGHT: D ===============]\n [================== JUMP: SPACEBAR =================]\n" +
        "[=================== SHOOT: LEFT MOUSE CLICK ===========]";

    private string message4 = "\n[====== PRESS SPACE BAR TO START YOUR MISSION =====]";

    private string message5 = "\n                                TIPS!!!!\n" +
    " YOUR WEAPON USES YOUR HEALTH AS AMMUNITION SO SHOOT RESPONSIBLY!!   \n" +
    "            ENEMIES THAT ARE KILLED DROP HEALTH PACKS!     \n" +
    "\n" + "\n";



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
        delay = 0.1f;
        for (int i = 0; i < message3.Length; i++)
        {
            currText = message3.Substring(0, i + 1);
            t.text = currText;
            yield return new WaitForSeconds(delay);
        }

        for (int i = 0; i < message5.Length; i++)
        {
            currText = message5.Substring(0, i + 1);
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
