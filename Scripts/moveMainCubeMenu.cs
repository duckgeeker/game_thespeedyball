using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveMainCubeMenu : MonoBehaviour
{
    private float posY;
    private float posX;
    private float angleY;
    private float angleX;
    //private bool axisX = true;
    //private bool axisY = true;

    Vector3 selectAngle = new Vector3(0f, 0f, 0f);

    public string selectBtn = "play";

    public static string ClickButton = "none";
    public string clickBtn;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(2.226198e-07f, 5.77f, -88.2f);//start pos
        posX = cameraControl.positionInScreanY;
        posY = cameraControl.positionInScreanX;
        angleX = this.transform.eulerAngles.x;
        angleY = this.transform.eulerAngles.y;
        //this.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.position.y, 0);
        clickBtn = ClickButton;

        if (Input.GetMouseButtonDown(0))
        {
            //this.transform.localScale *= 1.2f;   
        }//CLICK
        else if (Input.GetMouseButton(0))
        {
            this.transform.localScale = new Vector3(12f, 12f, 12f);
            //ROTATE on axis Y
            if ( angleY > 315 || angleY < 45 )
            {
                if (-0.1 > posY)
                {
                    this.transform.RotateAround(this.transform.position, new Vector3(0, 1, 0), 190 * Time.deltaTime);
                }//left rotate
                else if (0.1 < posY)
                {
                    this.transform.RotateAround(this.transform.position, new Vector3(0, 1, 0), -190 * Time.deltaTime);
                }//right rotate
            }
            else if ( angleY > 135 && angleY < 225 )
            {
                if (-0.1 > posY)
                {
                    this.transform.RotateAround(this.transform.position, new Vector3(0, 1, 0), 190 * Time.deltaTime);
                }//left rotate
                else if (0.1 < posY)
                {
                    this.transform.RotateAround(this.transform.position, new Vector3(0, 1, 0), -190 * Time.deltaTime);
                }//right rotate
            }

            //ROTATE on axis X
            if (-0.1 > posX)
            {
                this.transform.RotateAround(this.transform.position, new Vector3(1, 0, 0), 290 * Time.deltaTime);
            }//up rotate
            else if (0.1 < posX)
            {
                this.transform.RotateAround(this.transform.position, new Vector3(1, 0, 0), -290 * Time.deltaTime);
            }//down rotate

            //GET A NAME SELECTED BUTTON
            if ( transform.eulerAngles.z != 180 || transform.eulerAngles.y != 180 )
            {
                if (angleX > 45 && angleX <= 135)
                {
                    selectBtn = "inventory";
                }//left
                else if (angleX > 135 && angleX <= 225)
                {
                    selectBtn = "store";
                }//down
                else if (angleX > 225 && angleX <= 315)
                {
                    selectBtn = "setting";
                }//right
                else if (angleX <= 45 || angleX > 315)
                {
                    selectBtn = "play";
                }//up
            }
            else
            {
                if (angleX <= 45 || angleX > 315)
                {
                    selectBtn = "store";
                }//up
            }

        }
        else
        {
            this.transform.localScale = new Vector3(10f, 10f, 10f);
            
            if (angleY < 3 && angleY > -3)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0f, 0f);
            }
            else
            {
                if ( selectBtn == "play" || selectBtn == "setting" )
                {

                }
                if ( angleY > 3 && angleY < 45)
                {
                    transform.RotateAround(transform.position, new Vector3(0, 1, 0), -angleY * Time.deltaTime * 5f);
                }
                if (angleY > -3 && angleY < 315)
                {
                    transform.RotateAround(transform.position, new Vector3(0, 1, 0), angleY * Time.deltaTime * 0.3f);
                }
                if (angleY > 183 && angleY < 225)
                {
                    transform.RotateAround(transform.position, new Vector3(0, 1, 0), -angleY * Time.deltaTime * 5f);
                }
                if (angleY > 135 && angleY < 177)
                {
                    transform.RotateAround(transform.position, new Vector3(0, 1, 0), angleY * Time.deltaTime * 0.3f);
                }
            }

            
            if (selectBtn == "play")
            {
                selectAngle = new Vector3(0f + 0f, 0f, 0f);//10f +
            }
            else if (selectBtn == "inventory")
            {
                selectAngle = new Vector3(0f + 90f, 0f, 0f);
            }
            else if (selectBtn == "store")
            {
                selectAngle = new Vector3(0f + 180f, 0f, 0f);
            }
            else if (selectBtn == "setting")
            {
                selectAngle = new Vector3(0f + 270f, 0f, 0f);
            }
            //transform.eulerAngles = selectAngle;

            Quaternion needRotation = Quaternion.Euler(selectAngle);
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, needRotation, 300 * Time.deltaTime);

        }
        //GameObject.Find("TextVector").GetComponent<Text>().text = "angle: " + transform.eulerAngles.x + "/" + transform.eulerAngles.y + "/" + transform.eulerAngles.z + ";";

    }



}