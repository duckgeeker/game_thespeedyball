using UnityEngine;
using UnityEngine.UI;

public class moveRoad : MonoBehaviour
{
    private float pos;
    private Vector3 start, jumpPos;
    public float spdSphr = 10f;
    public float spdToward = 10f;
    public float spdRotate = 5f;
    public static bool stopMove = true;
    public bool ChangeAll = false;

    public bool infoTurn = false; private int countX = 1;
    public GameObject stayCube;

    void Start()
    {
        start = GetComponent<Transform>().position;
        jumpPos = new Vector3(0f, 0f, 0f);
        rightTrue = true;
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        //readyStay = transform.position;

        point = new Vector3(0f, 0f, 0f);
        axis = new Vector3(0f, 0f, 0f);
    }

    public static bool rightTrue = false;
    public static bool press = false;

    bool exactlyStay = true;
    float timer = 0;
    public string turnStay = "up";
    public int sideName = 2;
    bool jump = true;

    public static Vector3 point;
    private Vector3 axis;
    private float angle;
    Vector3 upStay = new Vector3(0f, 0f, 0f);
    Vector3 downStay = new Vector3(0f, 0f, 0f);
    Vector3 leftStay = new Vector3(0f, 0f, 0f);
    Vector3 rightStay = new Vector3(0f, 0f, 0f);
    Vector3 backStay = new Vector3(0f, 0f, 0f);
    Vector3 forwardStay = new Vector3(0f, 0f, 0f);

    Vector3 upAngle = new Vector3(0f, 0f, 0f);
    Vector3 downAngle = new Vector3(0f, 0f, 0f);
    Vector3 leftAngle = new Vector3(0f, 0f, 0f);
    Vector3 rightAngle = new Vector3(0f, 0f, 0f);
    Vector3 backAngle = new Vector3(0f, 0f, 0f);
    Vector3 forwardAngle = new Vector3(0f, 0f, 0f);

    Vector3 upAngleC = new Vector3(0f, 0f, 0f);
    Vector3 downAngleC = new Vector3(0f, 0f, 0f);
    Vector3 leftAngleC = new Vector3(0f, 0f, 0f);
    Vector3 rightAngleC = new Vector3(0f, 0f, 0f);
    Vector3 backAngleC = new Vector3(0f, 0f, 0f);
    Vector3 forwardAngleC = new Vector3(0f, 0f, 0f);

    Vector3 readyStay = new Vector3(0f, 0f, 0f);
    int xReadyStay = 0;

    public GameObject cameraObj;
    Vector3 center = new Vector3(0f, 0f, 0f);
    Vector3 lastReadyStay;
    void Update()
    {
        sideName = eventSphere.inTurn;

        //(swipeX)detect position point of touch for X axis
        pos = cameraControl.positionInScreanX;

        //get angle relative to axis
        if (eventSphere.inTurn == 0 || eventSphere.inTurn == 2 || eventSphere.inTurn == 4 )
        {
            angle = transform.eulerAngles.z;
        }
        else
        {
            angle = transform.eulerAngles.y;
        }

        //get a default angle and a default jump value for ball 
        if (eventSphere.inTurn == 0)
        {
            upAngle = new Vector3(0f, 270f, 0f);
            downAngle = new Vector3(0f, 270f, 180f);
            //leftAngle = new Vector3(0f, 270f, 90f);
            //rightAngle = new Vector3(0f, 270f, 270f);
            backAngle = new Vector3(0f, 270f, 90f);
            forwardAngle = new Vector3(0f, 270f, 270f);

            upAngleC = new Vector3(0f, -90f, 0f);
            downAngleC = new Vector3(0f, -90f, -180f);
            //leftAngleC = new Vector3(0f, -90f, 90f);
            //rightAngleC = new Vector3(0f, -90f, -90f);
            backAngleC = new Vector3(0f, -90f, 90f);
            forwardAngleC = new Vector3(0f, -90f, -90f);

            upStay = new Vector3(0f, 1.563f, 0f);
            downStay = new Vector3(0f, -1.563f, 0f);
            //leftStay = new Vector3(0f, 0f, -1.563f);
            //rightStay = new Vector3(0f, 0f, 1.563f);
            backStay = new Vector3(0f, 0f, -1.563f);
            forwardStay = new Vector3(0f, 0f, 1.563f);

            upJump = new Vector3(0f, 1.563f + jumpStep, 0f);
            downJump = new Vector3(0f, -1.563f - jumpStep, 0f);
            //leftJump = new Vector3(0f, 0f, -1.563f - jumpStep);
            //rightJump = new Vector3(0f, 0f, 1.563f + jumpStep);
            backJump = new Vector3(0f, 0f, -1.563f - jumpStep);
            forwardJump = new Vector3(0f, 0f, 1.563f + jumpStep);
        }//left
        else if (eventSphere.inTurn == 4)
        {
            upAngle = new Vector3(0f, 90f, 0f);
            downAngle = new Vector3(0f, 90f, 180f);
            //leftAngle = new Vector3(0f, 90f, 90f);
            //rightAngle = new Vector3(0f, 90f, 270f);
            backAngle = new Vector3(0f, 90f, 270f);
            forwardAngle = new Vector3(0f, 90f, 90f);

            upAngleC = new Vector3(0f, 90f, 0f);
            downAngleC = new Vector3(0f, 90f, 180f);
            //leftAngleC = new Vector3(0f, 90f, 90f);
            //rightAngleC = new Vector3(0f, 90f, -90f);
            backAngleC = new Vector3(0f, 90f, 270f);
            forwardAngleC = new Vector3(0f, 90f, 90f);

            upStay = new Vector3(0f, 1.563f, 0f);
            downStay = new Vector3(0f, -1.563f, 0f);
            //leftStay = new Vector3(0f, 0f, 1.563f);
            //rightStay = new Vector3(0f, 0f, -1.563f);
            backStay = new Vector3(0f, 0f, -1.563f);
            forwardStay = new Vector3(0f, 0f, 1.563f);

            upJump = new Vector3(0f, 1.563f + jumpStep, 0f);
            downJump = new Vector3(0f, -1.563f - jumpStep, 0f);
            //leftJump = new Vector3(0f, 0f, 1.563f + jumpStep);
            //rightJump = new Vector3(0f, 0f, -1.563f - jumpStep);
            backJump = new Vector3(0f, 0f, -1.563f - jumpStep);
            forwardJump = new Vector3(0f, 0f, 1.563f + jumpStep);
        }//right
        else if (eventSphere.inTurn == 1)
        {
            //upAngle = new Vector3(90f, 0f, 0f);
            //downAngle = new Vector3(90f, 180f, 0f);
            leftAngle = new Vector3(90f, 270f, 0f);
            rightAngle = new Vector3(90f, 90f, 0f);
            backAngle = new Vector3(90f, 0f, 0f);
            forwardAngle = new Vector3(90f, 180f, 0f);

            //upAngleC = new Vector3(90f, 0f, 0f);
            //downAngleC = new Vector3(90f, 180f, 0f);
            leftAngleC = new Vector3(90f, 270f, 0f);
            rightAngleC = new Vector3(90f, 90f, 0f);
            backAngleC = new Vector3(90f, 0f, 0f);
            forwardAngleC = new Vector3(90f, 180f, 0f);

            //upStay = new Vector3(0f, 0f, 1.563f);
            //downStay = new Vector3(0f, 0f, -1.563f);
            leftStay = new Vector3(-1.563f, 0f, 0f);
            rightStay = new Vector3(1.563f, 0f, 0f);
            backStay = new Vector3(0f, 0f, 1.563f);
            forwardStay = new Vector3(0f, 0f, -1.563f);

            //upJump = new Vector3(0f, 0f, 1.563f + jumpStep);
            //downJump = new Vector3(0f, 0f, -1.563f - jumpStep);
            leftJump = new Vector3(-1.563f - jumpStep, 0f, 0f);
            rightJump = new Vector3(1.563f + jumpStep, 0f, 0f);
            backJump = new Vector3(0f, 0f, 1.563f + jumpStep);
            forwardJump = new Vector3(0f, 0f, -1.563f - jumpStep);

        }//down
        else if (eventSphere.inTurn == 3)
        {
            //upAngle = new Vector3(270f, 0f, 0f);
            //downAngle = new Vector3(270f, 180f, 0f);
            leftAngle = new Vector3(270f, 90f, 0f);
            rightAngle = new Vector3(270f, 270f, 0f);
            backAngle = new Vector3(270f, 0f, 0f);
            forwardAngle = new Vector3(270f, 180f, 0f);

            //upAngleC = new Vector3(270f, 0f, 0f);
            //downAngleC = new Vector3(270f, 0f, -180f);
            leftAngleC = new Vector3(270f, 0f, 90f);
            rightAngleC = new Vector3(270f, 0f, 270f);
            backAngleC = new Vector3(270f, 0f, 0f);
            forwardAngleC = new Vector3(270f, 0f, -180f);

            //upStay = new Vector3(0f, 0f, -1.563f);
            //downStay = new Vector3(0f, 0f, 1.563f);
            leftStay = new Vector3(-1.563f, 0f, 0f);
            rightStay = new Vector3(1.563f, 0f, 0f);
            backStay = new Vector3(0f, 0f, -1.563f);
            forwardStay = new Vector3(0f, 0f, 1.563f);

            //upJump = new Vector3(0f, 0f, -1.563f - jumpStep);
            //downJump = new Vector3(0f, 0f, 1.563f + jumpStep);
            leftJump = new Vector3(-1.563f - jumpStep, 0f, 0f);
            rightJump = new Vector3(1.563f + jumpStep, 0f, 0f);
            backJump = new Vector3(0f, 0f, -1.563f - jumpStep);
            forwardJump = new Vector3(0f, 0f, 1.563f + jumpStep);
        }//up
        else if (eventSphere.inTurn == 2)
        {
            upAngle = new Vector3(0f, 0f, 0f);
            downAngle = new Vector3(0f, 0f, 180f);
            leftAngle = new Vector3(0f, 0f, 90f);
            rightAngle = new Vector3(0f, 0f, 270f);
            //backAngle = new Vector3(0f, 0f, 0f);
            //forwardAngle = new Vector3(0f, 0f, 0f);

            upAngleC = new Vector3(0f, 0f, 0f);
            downAngleC = new Vector3(0f, 0f, 180f);
            leftAngleC = new Vector3(0f, 0f, 90f);
            rightAngleC = new Vector3(0f, 0f, 270f);
            //backAngleC = new Vector3(0f, 0f, 0f);
            //forwardAngleC = new Vector3(0f, 0f, 0f);

            upStay = new Vector3(0f, 1.563f, 0f);
            downStay = new Vector3(0f, -1.563f, 0f);
            leftStay = new Vector3(-1.563f, 0f, 0f);
            rightStay = new Vector3(1.563f, 0f, 0f);
            //backStay = new Vector3(0f, 0f, 0f);
            //forwardStay = new Vector3(0f, 0f, 0f);

            upJump = new Vector3(0f, 1.563f + jumpStep, 0f);
            downJump = new Vector3(0f, -1.563f - jumpStep, 0f);
            leftJump = new Vector3(-1.563f - jumpStep, 0f, 0f);
            rightJump = new Vector3(1.563f + jumpStep, 0f, 0f);
            //backJump = new Vector3(0f, 0f, 0f);
            //forwardJump = new Vector3(0f, 0f, 0f);
        }//forward

        if (timer < 45)
        {
            timer++;
        }//wait start animation
        else
        {
            this.GetComponent<Animator>().applyRootMotion = true;
            
            //0 - left
            //1 - down
            //2 - forward
            //3 - up
            //4 - right
            if (!stopMove && !ChangeAll)
            {
                //set value axis
                if (eventSphere.inTurn == 0)
                {
                    axis = new Vector3(1, 0, 0);
                }
                else if (eventSphere.inTurn == 4)
                {
                    axis = new Vector3(1, 0, 0);
                }
                else if (eventSphere.inTurn == 1)
                {
                    axis = new Vector3(0, 1, 0);
                    
                }
                else if (eventSphere.inTurn == 3)
                {
                    axis = new Vector3(0, 1, 0);
                }
                else if (eventSphere.inTurn == 2)
                {
                    axis = new Vector3(0, 0, 1);
                }

                //change angle ball of Euler to default
                if (turnStay == "left")
                {
                    transform.eulerAngles = leftAngle;
                }
                else if (turnStay == "down")
                {
                    transform.eulerAngles = downAngle;
                }
                else if (turnStay == "right")
                {
                    transform.eulerAngles = rightAngle;
                }
                else if (turnStay == "up")
                {
                    transform.eulerAngles = upAngle;
                }
                else if (turnStay == "back")
                {
                    transform.eulerAngles = backAngle;
                }
                else if (turnStay == "forward")
                {
                    transform.eulerAngles = forwardAngle;
                }
                
                //Debug.Log("Поворот " + eventSphere.inTurn + ";  point" + point + "; axis" + axis + "; angleWay.z" + angleWay);
            }//ПРИЗНАЧЕННЯ КУТА ДЛЯ М'ЯЧА ПРИ ПОВОРОТАХ

            //move sphere
            if (!stopMove)
            {
                if (eventSphere.inTurn == 0)
                {
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(-5f, 0f, 0f), Time.fixedDeltaTime * spdSphr);
                }
                else if (eventSphere.inTurn == 4)
                {
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(5f, 0f, 0f), Time.fixedDeltaTime * spdSphr);
                }
                else if (eventSphere.inTurn == 1)
                {
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0f, -5f, 0f), Time.fixedDeltaTime * spdSphr);
                }
                else if (eventSphere.inTurn == 3)
                {
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0f, 5f, 0f), Time.fixedDeltaTime * spdSphr);
                }
                else if (eventSphere.inTurn == 2)
                {
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0f, 0f, 5f), Time.fixedDeltaTime * spdSphr);
                }
            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            xReadyStay = 0;
            press = true;
            jump = true;
            if (!stopMove)
            {
                if (jump)
                {
                    changeJump(); //create point for jump
                    jump = false;
                }
            }
        }//CLICK
        else if (Input.GetMouseButton(0))
        {
            press = true;
            if ( !stopMove )
            {
                if (-0.1 > pos)//left rotate
                {
                    if (eventSphere.inTurn == 0 || eventSphere.inTurn == 1)
                    {
                        this.transform.RotateAround(point, axis, -190 * Time.deltaTime);
                        cameraObj.transform.RotateAround(point, axis, -190 * Time.deltaTime);
                    }//LEFT and DOWN
                    else
                    {
                        this.transform.RotateAround(point, axis, 190 * Time.deltaTime);
                        cameraObj.transform.RotateAround(point, axis, 190 * Time.deltaTime);
                    }//RIGHT and UP and FORWARD

                }//left rotate
                else if (0.1 < pos)//right rotate
                {

                    if (eventSphere.inTurn == 0 || eventSphere.inTurn == 1)
                    {
                        this.transform.RotateAround(point, axis, 190 * Time.deltaTime);
                        cameraObj.transform.RotateAround(point, axis, 190 * Time.deltaTime);
                    }//LEFT and DOWN
                    else
                    {
                        this.transform.RotateAround(point, axis, -190 * Time.deltaTime);
                        cameraObj.transform.RotateAround(point, axis, -190 * Time.deltaTime);
                    }//RIGHT and UP and FORWARD

                }//right rotate
            }
            
            else if (0.1 > pos && -0.1 < pos) //pressed in center screen
            {
               
            }//pressed in CENTER screen
            ChangeAll = true;//з'явились зміни
            //GameObject.Find("TextAngleSelf").GetComponent<Text>().text = "AngleSelf: " + transform.eulerAngles.y + ";";

        }//PRESS ROTATION
        else //don't touch screen
        {
            press = false;
            
            if (eventSphere.inTurn == 0)
            {
                upAngle = new Vector3(0f, 270f, 0f);
                downAngle = new Vector3(0f, 270f, 180f);
                //leftAngle = new Vector3(0f, 270f, 90f);
                //rightAngle = new Vector3(0f, 270f, 270f);
                backAngle = new Vector3(0f, 270f, 90f);
                forwardAngle = new Vector3(0f, 270f, 270f);

                upAngleC = new Vector3(0f, -90f, 0f);
                downAngleC = new Vector3(0f, -90f, -180f);
                //leftAngleC = new Vector3(0f, -90f, 90f);
                //rightAngleC = new Vector3(0f, -90f, -90f);
                backAngleC = new Vector3(0f, -90f, 90f);
                forwardAngleC = new Vector3(0f, -90f, -90f);

                upStay = new Vector3(0f, 1.563f, 0f);
                downStay = new Vector3(0f, -1.563f, 0f);
                //leftStay = new Vector3(0f, 0f, -1.563f);
                //rightStay = new Vector3(0f, 0f, 1.563f);
                backStay = new Vector3(0f, 0f, -1.563f);
                forwardStay = new Vector3(0f, 0f, 1.563f);

                upJump = new Vector3(0f, 1.563f + jumpStep, 0f);
                downJump = new Vector3(0f, -1.563f - jumpStep, 0f);
                //leftJump = new Vector3(0f, 0f, -1.563f - jumpStep);
                //rightJump = new Vector3(0f, 0f, 1.563f + jumpStep);
                backJump = new Vector3(0f, 0f, -1.563f - jumpStep);
                forwardJump = new Vector3(0f, 0f, 1.563f + jumpStep);
            }//вибір позиції для виконання поворота
            else if (eventSphere.inTurn == 4)
            {
                upAngle = new Vector3(0f, 90f, 0f);
                downAngle = new Vector3(0f, 90f, 180f);
                //leftAngle = new Vector3(0f, 90f, 90f);
                //rightAngle = new Vector3(0f, 90f, 270f);
                backAngle = new Vector3(0f, 90f, 270f);
                forwardAngle = new Vector3(0f, 90f, 90f);

                upAngleC = new Vector3(0f, 90f, 0f);
                downAngleC = new Vector3(0f, 90f, 180f);
                //leftAngleC = new Vector3(0f, 90f, 90f);
                //rightAngleC = new Vector3(0f, 90f, -90f);
                backAngleC = new Vector3(0f, 90f, 270f);
                forwardAngleC = new Vector3(0f, 90f, 90f);

                upStay = new Vector3(0f, 1.563f, 0f);
                downStay = new Vector3(0f, -1.563f, 0f);
                //leftStay = new Vector3(0f, 0f, 1.563f);
                //rightStay = new Vector3(0f, 0f, -1.563f);
                backStay = new Vector3(0f, 0f, -1.563f);
                forwardStay = new Vector3(0f, 0f, 1.563f);

                upJump = new Vector3(0f, 1.563f + jumpStep, 0f);
                downJump = new Vector3(0f, -1.563f - jumpStep, 0f);
                //leftJump = new Vector3(0f, 0f, 1.563f + jumpStep);
                //rightJump = new Vector3(0f, 0f, -1.563f - jumpStep);
                backJump = new Vector3(0f, 0f, -1.563f - jumpStep);
                forwardJump = new Vector3(0f, 0f, 1.563f + jumpStep);
            }//вибір позиції для виконання поворота
            else if (eventSphere.inTurn == 1)
            {
                //upAngle = new Vector3(90f, 0f, 0f);
                //downAngle = new Vector3(90f, 180f, 0f);
                leftAngle = new Vector3(90f, 270f, 0f);
                rightAngle = new Vector3(90f, 90f, 0f);
                backAngle = new Vector3(90f, 0f, 0f);
                forwardAngle = new Vector3(90f, 180f, 0f);

                //upAngleC = new Vector3(90f, 0f, 0f);
                //downAngleC = new Vector3(90f, 180f, 0f);
                leftAngleC = new Vector3(90f, 270f, 0f);
                rightAngleC = new Vector3(90f, 90f, 0f);
                backAngleC = new Vector3(90f, 0f, 0f);
                forwardAngleC = new Vector3(90f, 180f, 0f);

                //upStay = new Vector3(0f, 0f, 1.563f);
                //downStay = new Vector3(0f, 0f, -1.563f);
                leftStay = new Vector3(-1.563f, 0f, 0f);
                rightStay = new Vector3(1.563f, 0f, 0f);
                backStay = new Vector3(0f, 0f, 1.563f);
                forwardStay = new Vector3(0f, 0f, -1.563f);

                //upJump = new Vector3(0f, 0f, 1.563f + jumpStep);
                //downJump = new Vector3(0f, 0f, -1.563f - jumpStep);
                leftJump = new Vector3(-1.563f - jumpStep, 0f, 0f);
                rightJump = new Vector3(1.563f + jumpStep, 0f, 0f);
                backJump = new Vector3(0f, 0f, 1.563f + jumpStep);
                forwardJump = new Vector3(0f, 0f, -1.563f - jumpStep);

            }//вибір позиції для виконання поворота
            else if (eventSphere.inTurn == 3)
            {
                //upAngle = new Vector3(270f, 0f, 0f);
                //downAngle = new Vector3(270f, 180f, 0f);
                leftAngle = new Vector3(270f, 90f, 0f);
                rightAngle = new Vector3(270f, 270f, 0f);
                backAngle = new Vector3(270f, 0f, 0f);
                forwardAngle = new Vector3(270f, 180f, 0f);

                //upAngleC = new Vector3(270f, 0f, 0f);
                //downAngleC = new Vector3(270f, 0f, -180f);
                leftAngleC = new Vector3(270f, 0f, 90f);
                rightAngleC = new Vector3(270f, 0f, 270f);
                backAngleC = new Vector3(270f, 0f, 0f);
                forwardAngleC = new Vector3(270f, 0f, -180f);

                //upStay = new Vector3(0f, 0f, -1.563f);
                //downStay = new Vector3(0f, 0f, 1.563f);
                leftStay = new Vector3(-1.563f, 0f, 0f);
                rightStay = new Vector3(1.563f, 0f, 0f);
                backStay = new Vector3(0f, 0f, -1.563f);
                forwardStay = new Vector3(0f, 0f, 1.563f);

                //upJump = new Vector3(0f, 0f, -1.563f - jumpStep);
                //downJump = new Vector3(0f, 0f, 1.563f + jumpStep);
                leftJump = new Vector3(-1.563f - jumpStep, 0f, 0f);
                rightJump = new Vector3(1.563f + jumpStep, 0f, 0f);
                backJump = new Vector3(0f, 0f, -1.563f - jumpStep);
                forwardJump = new Vector3(0f, 0f, 1.563f + jumpStep);
            }//вибір позиції для виконання поворота
            else if (eventSphere.inTurn == 2)
            {
                upAngle = new Vector3(0f, 0f, 0f);
                downAngle = new Vector3(0f, 0f, 180f);
                leftAngle = new Vector3(0f, 0f, 90f);
                rightAngle = new Vector3(0f, 0f, 270f);
                //backAngle = new Vector3(0f, 0f, 0f);
                //forwardAngle = new Vector3(0f, 0f, 0f);

                upAngleC = new Vector3(0f, 0f, 0f);
                downAngleC = new Vector3(0f, 0f, 180f);
                leftAngleC = new Vector3(0f, 0f, 90f);
                rightAngleC = new Vector3(0f, 0f, 270f);
                //backAngleC = new Vector3(0f, 0f, 0f);
                //forwardAngleC = new Vector3(0f, 0f, 0f);

                upStay = new Vector3(0f, 1.563f, 0f);
                downStay = new Vector3(0f, -1.563f, 0f);
                leftStay = new Vector3(-1.563f, 0f, 0f);
                rightStay = new Vector3(1.563f, 0f, 0f);
                //backStay = new Vector3(0f, 0f, 0f);
                //forwardStay = new Vector3(0f, 0f, 0f);

                upJump = new Vector3(0f, 1.563f + jumpStep, 0f);
                downJump = new Vector3(0f, -1.563f - jumpStep, 0f);
                leftJump = new Vector3(-1.563f - jumpStep, 0f, 0f);
                rightJump = new Vector3(1.563f + jumpStep, 0f, 0f);
                //backJump = new Vector3(0f, 0f, 0f);
                //forwardJump = new Vector3(0f, 0f, 0f);
            }//вибір позиції для виконання поворота

            //Position of center inside road
            if (eventSphere.inTurn == 0)
            {
                center = new Vector3(transform.position.x, point.y, point.z);
            }
            else if (eventSphere.inTurn == 4)
            {
                center = new Vector3(transform.position.x, point.y, point.z);
            }
            else if (eventSphere.inTurn == 1)
            {
                center = new Vector3(point.x, transform.position.y, point.z);
            }
            else if (eventSphere.inTurn == 3)
            {
                center = new Vector3(point.x, transform.position.y, point.z);
            }
            else if (eventSphere.inTurn == 2)
            {
                center = new Vector3(point.x, point.y, transform.position.z);
            }

            GetComponent<eventSphere>().center.transform.position = center;

            if (ChangeAll)
            {
                //GET TURNSTAY - a text value of turn after movement
                if (eventSphere.inTurn == 2)
                {
                    if (angle > 45 && angle <= 135)
                    {
                        turnStay = "left";
                    }//left
                    else if (angle > 135 && angle <= 225)
                    {
                        turnStay = "down";
                    }//down
                    else if (angle > 225 && angle <= 315)
                    {
                        turnStay = "right";
                    }//right
                    else if (angle <= 45 || angle > 315)
                    {
                        turnStay = "up";
                    }//up
                }
                else if (eventSphere.inTurn == 0 || eventSphere.inTurn == 4)
                {
                    if (angle > 45 && angle <= 135)
                    {
                        if (eventSphere.inTurn == 4)
                        {
                            turnStay = "forward";
                        }
                        else
                        {
                            turnStay = "back";
                        }
                    }//back
                    else if (angle > 135 && angle <= 225)
                    {
                        turnStay = "down";
                    }//down
                    else if (angle > 225 && angle <= 315)
                    {
                        if (eventSphere.inTurn == 4)
                        {
                            turnStay = "back";
                        }
                        else
                        {
                            turnStay = "forward";
                        }
                    }//forward
                    else if (angle <= 45 || angle > 315)
                    {
                        turnStay = "up";
                    }//up
                }
                else if (eventSphere.inTurn == 1 || eventSphere.inTurn == 3)
                {
                    if (angle > 45 && angle <= 135)
                    {
                        if (eventSphere.inTurn == 1)
                        {
                            turnStay = "right";
                        }
                        else
                        {
                            turnStay = "left";
                        }
                    }//left
                    else if (angle > 135 && angle <= 225)
                    {
                        turnStay = "forward";
                    }//forward
                    else if (angle > 225 && angle <= 315)
                    {
                        if (eventSphere.inTurn == 1)
                        {
                            turnStay = "left";
                        }
                        else
                        {
                            turnStay = "right";
                        }
                    }//right
                    else if (angle <= 45 || angle > 315)
                    {
                        turnStay = "back";
                    }//back
                }

                //ПРИЗЕМЛЕННЯ М'ЯЧА
                if (turnStay == "left")
                {
                    transform.position = Vector3.MoveTowards(transform.position, center + leftStay, Time.deltaTime * spdToward);
                    readyStay = center + leftStay;
                }
                else if (turnStay == "down")
                {
                    transform.position = Vector3.MoveTowards(transform.position, center + downStay, Time.deltaTime * spdToward);
                    readyStay = center + downStay;
                }
                else if (turnStay == "right")
                {
                    transform.position = Vector3.MoveTowards(transform.position, center + rightStay, Time.deltaTime * spdToward);
                    readyStay = center + rightStay;
                }
                else if (turnStay == "up")
                {
                    transform.position = Vector3.MoveTowards(transform.position, center + upStay, Time.deltaTime * spdToward);
                    readyStay = center + upStay;
                }
                else if (turnStay == "back")
                {
                    transform.position = Vector3.MoveTowards(transform.position, center + backStay, Time.deltaTime * spdToward);
                    readyStay = center + backStay;
                }
                else if (turnStay == "forward")
                {
                    transform.position = Vector3.MoveTowards(transform.position, center + forwardStay, Time.deltaTime * spdToward);
                    readyStay = center + forwardStay;
                }

                if ( lastReadyStay != readyStay )
                {
                    stayCube.transform.position = readyStay;
                    lastReadyStay = readyStay;
                }
                

            }//ПРИЗЕМЛЕННЯ М'ЯЧА
            
            //if ball in right location after movement then changing angle ball
            if (transform.position == readyStay)
            {
                if (turnStay == "left")
                {
                    transform.eulerAngles = leftAngle;
                }//left
                else if (turnStay == "down")
                {
                    transform.eulerAngles = downAngle;
                }//down
                else if (turnStay == "right")
                {
                    transform.eulerAngles = rightAngle;
                }//right
                else if (turnStay == "up")
                {
                    transform.eulerAngles = upAngle;
                }//up
                else if (turnStay == "back")
                {
                    transform.eulerAngles = backAngle;
                }//up
                else if (turnStay == "forward")
                {
                    transform.eulerAngles = forwardAngle;
                }//up
                ChangeAll = false;
            }//ПОВНЕ ВИРІВНЮВАННЯ М'ЯЧА

            //camera angle align
            if (!stopMove)
            {
                if (turnStay == "left")
                {
                    cameraObj.transform.eulerAngles = leftAngle;
                }//left
                else if (turnStay == "down")
                {
                    cameraObj.transform.eulerAngles = downAngle;
                }//down
                else if (turnStay == "right")
                {
                    cameraObj.transform.eulerAngles = rightAngle;
                }//right
                else if (turnStay == "up")
                {
                    cameraObj.transform.eulerAngles = upAngle;
                }//up
                else if (turnStay == "back")
                {
                    cameraObj.transform.eulerAngles = backAngle;
                }//up
                else if (turnStay == "forward")
                {
                    cameraObj.transform.eulerAngles = forwardAngle;
                }//up
            }

        }//don't touch screen
        GameObject.Find("TextAngle").GetComponent<Text>().text = "Angle: " + transform.rotation.eulerAngles + ";";
        //GameObject.Find("TextVector").GetComponent<Text>().text = "Vector: (" + transform.eulerAngles.x + "/" + transform.eulerAngles.y + "/" + transform.eulerAngles.z + ");";
        //GameObject.Find("TextVector").GetComponent<Text>().text = "Vector: " + transform.rotation + ";";
        
    }

    Vector3 upJump = new Vector3(0f, 0f, 0f);
    Vector3 downJump = new Vector3(0f, 0f, 0f);
    Vector3 leftJump = new Vector3(0f, 0f, 0f);
    Vector3 rightJump = new Vector3(0f, 0f, 0f);
    Vector3 backJump = new Vector3(0f, 0f, 0f);
    Vector3 forwardJump = new Vector3(0f, 0f, 0f);
    float jumpStep = 1f;

    public void changeJump()
    {
        GetComponent<Animator>().applyRootMotion = true;
        
        if (turnStay == "left")
        {
            transform.position = point + leftJump;
        }//left
        else if (turnStay == "down")
        {
            transform.position = point + downJump;
        }//down
        else if (turnStay == "right")
        {
            transform.position = point + rightJump;
        }//right
        else if (turnStay == "up")
        {
            transform.position = point + upJump;
        }//up
        else if (turnStay == "back")
        {
            transform.position = point + backJump;
        }//back
        else if (turnStay == "forward")
        {
            transform.position = point + forwardJump;
        }//forward

        //point = GetComponent<eventSphere>().center.transform.position;
        //GameObject.Find("TextAngle").GetComponent<Text>().text = "Angle: " + angle.ToString() + ";";
    }// changeJump().

    public static void GoStart()
    {
        //SPHERE
        SphereToStart();

        //CAMERA
        CameraToStart();
        
        //MAP
        moveRoad.stopMove = false;
        generateWay.createWay = true;

        //UI
        uiScriptMainMenu.onceMenu = 0;
        GameObject.Find("CoinCount").GetComponent<Text>().text = "cyka";
    }

    public static void GoMenu(GameObject cam)
    {
        GoStart();
        moveRoad.stopMove = true;
        Vector3 posCam = new Vector3(0f, 17f, -40);
        Vector3 angleCam = new Vector3(10f, 180f, 0f);
        cam.gameObject.transform.position = posCam;
        cam.gameObject.transform.eulerAngles = angleCam;
        uiScriptMainMenu.onceMenu = 0;
        GameObject.Find("CoinCount").GetComponent<Text>().text = "";

        GameObject.Find("mainCube").GetComponent<Animator>().applyRootMotion = false;
        GameObject.Find("mainCube").GetComponent<Animator>().SetBool("hide", true);

    }

    public static void SphereToStart()
    {
        GameObject sphere = GameObject.Find("MainSphere");
        sphere.transform.position = eventSphere.positionShpere;
        sphere.transform.eulerAngles = new Vector3(0f, 0f, 0f);

        GameObject.Find("paint").transform.position = new Vector3(0f, 0f, 0f); //center
        //point = eventSphere.center.transform.position;
        //GameObject.Find("paint_stay").GetComponent<Transform>().position = new Vector3(0f, 1.563f, 0f); //position of stay
        eventSphere.inTurn = 2;
    }
    public static void CameraToStart()
    {
        GameObject camera = GameObject.Find("Main Camera");
        camera.gameObject.transform.position = eventSphere.positionShpere + new Vector3(0f, 4.563f, -10);
        camera.gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }
}
