using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiScriptMainMenu : MonoBehaviour
{
    public static int onceMenu = 0;
    // Start is called before the first frame update
    void Start()
    {
        onceMenu = 0;
    }
    float timer = 0;
    public static string pickButton;
    // Update is called once per frame

    void stayMenu()
    {
        GameObject.Find("mainCube").GetComponent<Animator>().applyRootMotion = true;
        Debug.Log("work");
    }
    void hideMenu()
    {
        GameObject.Find("mainCube").GetComponent<Animator>().applyRootMotion = false;
    }

    void Update()
    {
        if ( onceMenu == 0 )
        {
            if (pickButton == "Play")
            {
                GameObject.Find("mainCube").GetComponent<Animator>().applyRootMotion = false;
                GameObject.Find("mainCube").GetComponent<Animator>().SetBool("hide", false);

                if ( timer > 150 )
                {
                    Play();
                }
                else
                {
                    timer++;
                }
            }
            if (pickButton == "Inventory")
            {
                GameObject.Find("mainCube").GetComponent<Animator>().SetBool("hide", false);
                GameObject.Find("buttonBack").GetComponent<Animator>().SetBool("btnBack", true);
                GameObject.Find("settingRoom").GetComponent<Animator>().SetBool("settingRoom", true);
                Inventory();
            }
            if (pickButton == "Store")
            {
                MessageMenu();
            }
            if (pickButton == "Setting")
            {
                MessageMenu();
            }
            if (pickButton == "buttonBack")
            {
                GameObject.Find("buttonBack").GetComponent<Animator>().SetBool("btnBack", false);
                GameObject.Find("settingRoom").GetComponent<Animator>().SetBool("settingRoom", false);
                GameObject.Find("mainCube").GetComponent<Animator>().applyRootMotion = false;
                GameObject.Find("mainCube").GetComponent<Animator>().SetBool("hide", true);

                onceMenu = 0;
            }
        }

    }

    public void Play()
    {
        Debug.Log("play");
        onceMenu = 1;
        moveRoad.GoStart(GameObject.Find("Sphere"), GameObject.Find("Main Camera"));
    }
    public void Inventory()
    {
        Debug.Log("OPEN INVENTORY");
        onceMenu = 0;
    }
    void MessageMenu()
    {
        GameObject.Find("alarm").GetComponent<Text>().text = "Tehnical work, try again.";
    }
    void btnStay()
    {
        GameObject.Find("buttonBack").GetComponent<Animator>().applyRootMotion = true;
    }
}
