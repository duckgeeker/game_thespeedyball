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
        readyStay = transform.position;

        point = new Vector3(0f, 0f, 0f);
        axis = new Vector3(0f, 0f, 0f);
    }

    public static bool rightTrue = false;
    public static bool press = false;
    //public static bool changeRoad = true;

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

    void Update()
    {
        sideName = eventSphere.inTurn;
        pos = cameraControl.positionInScreanX;
        if (eventSphere.inTurn == 0 || eventSphere.inTurn == 2 || eventSphere.inTurn == 4 )
        {
            angle = transform.eulerAngles.z;
        }
        else
        {
            angle = transform.eulerAngles.y;
        }

        //cameraObj.transform.eulerAngles = new Vector3(0f,0f, transform.eulerAngles.z*Time.deltaTime*20f);

        if (!stopMove)
        {
            //cameraObj.transform.eulerAngles = transform.eulerAngles;
            //Debug.Log("Camera change angle from angle of ball. Angle: " + cameraObj.transform.eulerAngles.ToString());
            GameObject.Find("TextVector").GetComponent<Text>().text = "Angle: " + cameraObj.transform.eulerAngles.ToString();
        }
        

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

        if (timer < 45)
        {
            timer++;
        }
        else
        {
            this.GetComponent<Animator>().applyRootMotion = true;
            
            //0 - вліво
            //1 - вниз
            //2 - вперед
            //3 - вверх
            //4 - вправо
            if (!stopMove && !ChangeAll)
            {
                //VALUE ANGLE BALL
                if (eventSphere.inTurn == 0)
                {
                    axis = new Vector3(1, 0, 0);
                }//вибір позиції для виконання поворота
                else if (eventSphere.inTurn == 4)
                {
                    axis = new Vector3(1, 0, 0);
                }//вибір позиції для виконання поворота
                else if (eventSphere.inTurn == 1)
                {
                    axis = new Vector3(0, 1, 0);
                    
                }//вибір позиції для виконання поворота
                else if (eventSphere.inTurn == 3)
                {
                    axis = new Vector3(0, 1, 0);
                }//вибір позиції для виконання поворота
                else if (eventSphere.inTurn == 2)
                {
                    axis = new Vector3(0, 0, 1);
                }//вибір позиції для виконання поворота

                //CHANGE EulerANGLE BALL
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
                
                //Debug.Log("Поворот " + eventSphere.inTurn + ";  point" + point + "; axis" + axis + "; angleWay.z" + angleWay);
            }//ПРИЗНАЧЕННЯ КУТА ДЛЯ М'ЯЧА ПРИ ПОВОРОТАХ

            //MOVE SPHERE
            if (!stopMove)
            {
                //MOVE SPHERE
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

            //ROTATE CAMERA
            if (!stopMove)
            {
                if (turnStay == "left")
                {
                    cameraObj.transform.eulerAngles = leftAngleC;
                }//left
                else if (turnStay == "down")
                {
                    cameraObj.transform.eulerAngles = downAngleC;
                }//down
                else if (turnStay == "right")
                {
                    cameraObj.transform.eulerAngles = rightAngleC;
                }//right
                else if (turnStay == "up")
                {
                    cameraObj.transform.eulerAngles = upAngleC;
                }//up
                else if (turnStay == "back")
                {
                    cameraObj.transform.eulerAngles = backAngleC;
                }//back
                else if (turnStay == "forward")
                {
                    cameraObj.transform.eulerAngles = forwardAngleC;
                }//forward
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
                    changeJump(angle); //create point
                    jump = false;
                }
            }
            //cameraObj.transform.eulerAngles = transform.eulerAngles;

        }//CLICK
        else if (Input.GetMouseButton(0))
        {
            press = true;

            if (-0.1 > pos)//left rotate
            {
                if (eventSphere.inTurn == 0 || eventSphere.inTurn == 1)
                {
                    this.transform.RotateAround(point, axis, -190 * Time.deltaTime);
                    //cameraObj.transform.RotateAround(point, axis, -190 * Time.deltaTime);
                }//LEFT and DOWN
                else
                {
                    this.transform.RotateAround(point, axis, 190 * Time.deltaTime);
                    //cameraObj.transform.RotateAround(point, axis, 190 * Time.deltaTime);
                }//RIGHT and UP and FORWARD

            }//left rotate
            else if (0.1 < pos)//right rotate
            {

                if (eventSphere.inTurn == 0 || eventSphere.inTurn == 1)
                {
                    this.transform.RotateAround(point, axis, 190 * Time.deltaTime);
                    //cameraObj.transform.RotateAround(point, axis, 190 * Time.deltaTime);
                }//LEFT and DOWN
                else
                {
                    this.transform.RotateAround(point, axis, -190 * Time.deltaTime);
                    //cameraObj.transform.RotateAround(point, axis, -190 * Time.deltaTime);
                }//RIGHT and UP and FORWARD

            }//right rotate
            else if (0.1 > pos && -0.1 < pos) //pressed in center screen
            {

                if (eventSphere.inTurn == 0)
                {

                }
                else if (eventSphere.inTurn == 4)
                {

                }
                else if (eventSphere.inTurn == 1)
                {

                }
                else if (eventSphere.inTurn == 3)
                {

                }
                else if (eventSphere.inTurn == 2)
                {

                }
                if (eventSphere.inTurn == 2)
                {

                }
                /*
                if (angleWay != 0 && angleWay != 90 && angleWay != 180)
                {
                    exactlyStay = false;
                    changeRoad = exactlyStay;
                }
                if (!exactlyStay)
                {
                    if (angleWay > 0 && angleWay < 90)
                    {
                        if (angleWay >= 45)
                        {
                            transform.RotateAround(start - start, new Vector3(0, 0, 1), (90 - angleWay) * Time.deltaTime * 1.5f);
                            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1.563f, 0f, transform.position.z), Time.deltaTime * 5f);
                        }
                        else
                        {
                            transform.RotateAround(start - start, new Vector3(0, 0, 1), -angleWay * Time.deltaTime * 1.5f);
                            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 1.563f, transform.position.z), Time.deltaTime * 5f);

                        }
                    }
                    else if (angleWay > 90 && angleWay < 180)
                    {
                        if (angleWay >= 135)
                        {
                            transform.RotateAround(start - start, new Vector3(0, 0, 1), (180 - angleWay) * Time.deltaTime * 1.5f);
                            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, -1.563f, transform.position.z), Time.deltaTime * 5f);
                        }
                        else
                        {
                            transform.RotateAround(start - start, new Vector3(0, 0, 1), -angleWay * Time.deltaTime * 1.5f);
                            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1.563f, 0f, transform.position.z), Time.deltaTime * 5f);
                        }
                    }
                    else if (angleWay > 180 && angleWay < 270)
                    {
                        if (angleWay >= 225)
                        {
                            transform.RotateAround(start - start, new Vector3(0, 0, 1), (270 - angleWay) * Time.deltaTime * 1.5f);
                            transform.position = Vector3.MoveTowards(transform.position, new Vector3(1.563f, 0f, transform.position.z), Time.deltaTime * 5f);
                        }
                        else
                        {
                            transform.RotateAround(start - start, new Vector3(0, 0, 1), -angleWay * Time.deltaTime * 1.5f);
                            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, -1.563f, transform.position.z), Time.deltaTime * 5f);
                        }
                    }
                    else if (angleWay > 270 && angleWay < 360)
                    {
                        if (angleWay >= 315)
                        {
                            transform.RotateAround(start - start, new Vector3(0, 0, 1), (360 - angleWay) * Time.deltaTime * 1.5f);
                            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 1.563f, transform.position.z), Time.deltaTime * 5f);
                        }
                        else
                        {
                            transform.RotateAround(start - start, new Vector3(0, 0, 1), -angleWay * Time.deltaTime * 1.5f);
                            transform.position = Vector3.MoveTowards(transform.position, new Vector3(1.563f, 0f, transform.position.z), Time.deltaTime * 5f);
                        }
                    }

                    exactlyStay = true;
                    changeRoad = exactlyStay;
                }//центруємо мапу ріно
                */
            }//pressed in CENTER screen
            ChangeAll = true;//з'явились зміни
            //GameObject.Find("TextAngleSelf").GetComponent<Text>().text = "AngleSelf: " + transform.eulerAngles.y + ";";

        }//ROTATION
        else
        {
            
            press = false;
            Vector3 center = new Vector3(0f, 0f, 0f);

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
                        //transform.RotateAround(point, axis, (90 - angle) * Time.deltaTime * spdRotate);
                    //cameraObj.transform.RotateAround(point, axis, (90 - angle) * Time.deltaTime * spdRotate);
                    transform.position = Vector3.MoveTowards(transform.position, center + leftStay, Time.deltaTime * spdToward);
                    readyStay = center + leftStay;
                }//left
                else if (turnStay == "down")
                {
                        //transform.RotateAround(point, axis, (180 - angle) * Time.deltaTime * spdRotate);
                    //cameraObj.transform.RotateAround(point, axis, (180 - angle) * Time.deltaTime * spdRotate);
                    transform.position = Vector3.MoveTowards(transform.position, center + downStay, Time.deltaTime * spdToward);
                    readyStay = center + downStay;
                }//down
                else if (turnStay == "right")
                {
                        //transform.RotateAround(point, axis, (270 - angle) * Time.deltaTime * spdRotate);
                    //cameraObj.transform.RotateAround(point, axis, (270 - angle) * Time.deltaTime * spdRotate);
                    transform.position = Vector3.MoveTowards(transform.position, center + rightStay, Time.deltaTime * spdToward);
                    readyStay = center + rightStay;
                }//right
                else if (turnStay == "up")
                {
                    if (angle > 315)
                    {
                            //transform.RotateAround(point, axis, (360 - angle) * Time.deltaTime * spdRotate);
                        //cameraObj.transform.RotateAround(point, axis, (360 - angle) * Time.deltaTime * spdRotate);
                    }
                    if (angle <= 45)
                    {
                            //transform.RotateAround(point, axis, -angle * Time.deltaTime * spdRotate);
                        //cameraObj.transform.RotateAround(point, axis, -angle * Time.deltaTime * spdRotate);
                    }
                    transform.position = Vector3.MoveTowards(transform.position, center + upStay, Time.deltaTime * spdToward);

                    readyStay = center + upStay;
                }//up
                else if (turnStay == "back")
                {
                    transform.position = Vector3.MoveTowards(transform.position, center + backStay, Time.deltaTime * spdToward);
                    readyStay = center + backStay;
                }//up
                else if (turnStay == "forward")
                {
                    
                    transform.position = Vector3.MoveTowards(transform.position, center + forwardStay, Time.deltaTime * spdToward);
                    readyStay = center + forwardStay;
                }//up

                stayCube.transform.position = readyStay;
                //Debug.Log(countX + "Вирівнюємо.");
                //countX++;
            }//ПРИЗЕМЛЕННЯ М'ЯЧА
            
            //show info about all turn
            if (infoTurn)
            {
                Debug.Log(countX + "Angle: " + angle + "; Pos: " + transform.position + "; ");
                countX++;
            }

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

        }//гравець не взаємодіє з екраном
        GameObject.Find("TextAngle").GetComponent<Text>().text = "Angle: " + transform.rotation.eulerAngles + ";";
        //GameObject.Find("TextVector").GetComponent<Text>().text = "Vector: (" + transform.eulerAngles.x + "/" + transform.eulerAngles.y + "/" + transform.eulerAngles.z + ");";
        //GameObject.Find("TextVector").GetComponent<Text>().text = "Vector: " + transform.rotation + ";";
        
        //set angle for camera
        if ( !stopMove )
        {
            cameraObj.transform.eulerAngles = transform.eulerAngles;
        }
        
    }

    Vector3 upJump = new Vector3(0f, 0f, 0f);
    Vector3 downJump = new Vector3(0f, 0f, 0f);
    Vector3 leftJump = new Vector3(0f, 0f, 0f);
    Vector3 rightJump = new Vector3(0f, 0f, 0f);
    Vector3 backJump = new Vector3(0f, 0f, 0f);
    Vector3 forwardJump = new Vector3(0f, 0f, 0f);
    float jumpStep = 1f;

    public void changeJump(float angle)
    {
        GetComponent<Animator>().applyRootMotion = true;
        
        if (eventSphere.inTurn == 0)
        {
            angle = transform.eulerAngles.z;
        }
        else if (eventSphere.inTurn == 4)
        {
            angle = transform.eulerAngles.z;
        }
        else if (eventSphere.inTurn == 1)
        {
            angle = transform.eulerAngles.y;
        }
        else if (eventSphere.inTurn == 3)
        {
            angle = transform.eulerAngles.y;
        }
        else if (eventSphere.inTurn == 2)
        {
            angle = transform.eulerAngles.z;
        }

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

        point = GetComponent<eventSphere>().center.transform.position;

        //GameObject.Find("TextAngle").GetComponent<Text>().text = "Angle: " + angle.ToString() + ";";

    }// changeJump().


    public void StaySphere(GameObject obj)
    {
        if (eventSphere.inTurn == 0)
        {
            angle = obj.transform.eulerAngles.x;
        }
        else if (eventSphere.inTurn == 4)
        {
            angle = obj.transform.eulerAngles.x;
        }
        else if (eventSphere.inTurn == 1)
        {
            angle = obj.transform.eulerAngles.y;
        }
        else if (eventSphere.inTurn == 3)
        {
            angle = obj.transform.eulerAngles.y;
        }
        else if (eventSphere.inTurn == 2)
        {
            angle = obj.transform.eulerAngles.z;
        }

        if (exactlyStay)
        {
            if (angle > 0 && angle < 90)
            {
                if (angle >= 45)
                {
                    //print("left");
                }
                else
                {
                    //print("up");
                }
            }
            else if (angle > 90 && angle < 180)
            {
                if (angle >= 135)
                {
                    //print("down");
                }
                else
                {
                    //print("left");
                }
            }
            else if (angle > 180 && angle < 270)
            {
                if (angle >= 225)
                {
                    //print("right");
                }
                else
                {
                    //print("down");
                }
            }
            else if (angle > 270 && angle < 360)
            {
                if (angle >= 315)
                {
                    //print("up");
                }
                else
                {
                    //print("right");
                }
            }
        }
    }
    public void changeAngle()
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public static void GoStart(GameObject obj, GameObject cam)
    {
        Vector3 posObj = new Vector3(0f, 1.563f, 0f);
        Vector3 angleObj = new Vector3(0f, 0f, 0f);
        Vector3 posCam = new Vector3(0f, 4.563f, -10);
        Vector3 angleCam = new Vector3(0f, 0f, 0f);
        obj.gameObject.transform.position = posObj;
        obj.gameObject.transform.eulerAngles = angleObj;
        cam.gameObject.transform.position = posCam;
        cam.gameObject.transform.eulerAngles = angleCam;
        eventSphere.inTurn = 2;
        moveRoad.stopMove = false;
        uiScriptMainMenu.onceMenu = 0;
    }

    public static void GoMenu(GameObject cam)
    {
        GoStart(GameObject.Find("Sphere"), GameObject.Find("Main Camera"));
        moveRoad.stopMove = true;
        Vector3 posCam = new Vector3(0f, 17f, -40);
        Vector3 angleCam = new Vector3(10f, 180f, 0f);
        cam.gameObject.transform.position = posCam;
        cam.gameObject.transform.eulerAngles = angleCam;
        uiScriptMainMenu.onceMenu = 0;
    }
}
