using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eventSphere : MonoBehaviour
{
    Vector3 positionShpere;
    public Animator startAnim;
    private Rigidbody rb;
    public bool start;
    public GameObject center;

    void Start()
    {
        startAnim = GetComponent<Animator>();
        positionShpere = GetComponent<Transform>().position;
        rb = GetComponent<Rigidbody>();
        start = true;
    }

    void Update()
    {
        startAnim.SetBool("start", start);
    }

    public static int inTurn = 2;
    private int turnNum = -1;

    float timer = 0;
    private float angle = 0;
    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "rotateRoadMove")
        {
            if (timer > 12)
            {

                Debug.Log("Зачіпили поворот " + other.GetComponent<rotateRM>().turnNum);
                inTurn = other.GetComponent<rotateRM>().turnNum;
                  
                timer = 0;
                Vector3 posTurn = other.GetComponent<Transform>().position;

                if ( turnNum != other.GetComponent<rotateRM>().num )
                {
                    if (eventSphere.inTurn == 0 || eventSphere.inTurn == 4)
                    {
                        if (other.GetComponent<rotateRM>().pastTurnNum == 3 || other.GetComponent<rotateRM>().pastTurnNum == 1)
                        {
                            transform.position = new Vector3(posTurn.x, posTurn.y, posTurn.z);
                        }
                        if (other.GetComponent<rotateRM>().pastTurnNum == 2)
                        {
                            transform.position = new Vector3(posTurn.x, transform.position.y, posTurn.z);
                        }
                        //transform.position = new Vector3(posTurn.x, transform.position.y, posTurn.z);
                    }
                    else if (eventSphere.inTurn == 1 || eventSphere.inTurn == 3)
                    {
                        if (other.GetComponent<rotateRM>().pastTurnNum == 4 || other.GetComponent<rotateRM>().pastTurnNum == 0)
                        {
                            transform.position = new Vector3(posTurn.x, transform.position.y, transform.position.z);
                        }
                        if (other.GetComponent<rotateRM>().pastTurnNum == 2)
                        {
                            transform.position = new Vector3(transform.position.x, posTurn.y, posTurn.z);
                        }
                    }
                    else if (eventSphere.inTurn == 2)
                    {
                        if (other.GetComponent<rotateRM>().pastTurnNum == 3 || other.GetComponent<rotateRM>().pastTurnNum == 1)
                        {
                            transform.position = new Vector3(transform.position.x, posTurn.y, transform.position.z);
                        }
                        if (other.GetComponent<rotateRM>().pastTurnNum == 0 || other.GetComponent<rotateRM>().pastTurnNum == 4)
                        {
                            transform.position = new Vector3(posTurn.x, transform.position.y, transform.position.z);
                        }
                    }

                }//вирівнювання виконується в цьому повороті лише один раз

                turnNum = other.GetComponent<rotateRM>().num;
            }
            else
            {
                timer++;
                //Debug.Log("timer " + timer);
            }
        }

        if (other.tag == "wayCube")
        {
            //Debug.Log("Їдемо");
            moveRoad.point = other.GetComponent<Transform>().position;
            center.transform.position = moveRoad.point;
        }

        if (other.tag == "someCube")
        {
            Debug.Log("KICK");
            GameObject.Find("alarm").GetComponent<Text>().text = "You are kick in wall!";
            //moveRoad.GoStart(GameObject.Find("Sphere"), GameObject.Find("Main Camera"));
            moveRoad.GoMenu(GameObject.Find("Main Camera"));
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "mapBorder")
        {
            transform.position = new Vector3(0f, 1.563f, 0f);
            Debug.Log("U lose");
            //виліт з дороги, при виході з колайдера шляху
        }
    }

        /*
        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "wayCube")
            {
                Debug.Log("Втаранився в стіну");
            }
        }
        */
}
