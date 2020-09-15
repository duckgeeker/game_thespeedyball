using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cameraControl : MonoBehaviour
{

    private Vector3 cameraPosition;
    private Vector2 startPos;
    private Camera cam;
    public GameObject obj;
    private float angleObj;
    public GameObject light;
    private float posX;
    private float posY;
    private float speed = 100f;

    public static float positionInScreanX;
    public static float positionInScreanY;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        //transform.position = new Vector3(0f, 8f, -15f);
            //transform.rotation = Quaternion.Euler(15f, 0f, 0f);
        //transform.RotateAround(obj.transform.position, new Vector3(0, 1, 0), -50f);
        positionInScreanX = 0;
        positionInScreanY = 0;
    }
    string oldTurn = "";
    // Update is called once per frame
    float naklonX, naklonY, naklonZ;

    Vector3 offset = new Vector3(0f, 0f, 0f);
    float offsetUp = 10f;
    float offsetBehind = -15f;
    bool stpmove = false;

    [Header("Menu controler")]
    public float rayLength = 100;
    public LayerMask LayerMask;
    void Update()
    {
        //MENU CONTROLER
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLength, LayerMask))
            {
                moveMainCubeMenu.ClickButton = hit.collider.name;
                uiScriptMainMenu.pickButton = hit.collider.name;
                Debug.Log(hit.collider.name);
            }
        }

        stpmove = moveRoad.stopMove;
        light.GetComponent<Transform>().transform.position = transform.position;
        light.GetComponent<Transform>().transform.rotation = transform.rotation;

        Vector3 angle = transform.position;
        Vector3 underObj = obj.transform.position + new Vector3(0f, -1.1f, 0f);
        Vector3 posObj = obj.transform.position;

        if (eventSphere.inTurn == 0 || eventSphere.inTurn == 2 || eventSphere.inTurn == 4)
        {
            angleObj = obj.transform.eulerAngles.z;
        }
        else
        {
            angleObj = obj.transform.eulerAngles.y;
        }

        //УТВОРЕННЯ ВІДСТАНІ ВІД М'ЯЧА ДО КАМЕРИ
        if (eventSphere.inTurn == 0)
        {
            offsetBehind = 15f;
            //offsetUP
            if (angleObj > 45 && angleObj <= 135)
            {
                offsetUp = -5f;
                offset = new Vector3(offsetBehind, 0f, offsetUp);
            }//left
            else if (angleObj > 135 && angleObj <= 225)
            {
                offsetUp = -5f;
                offset = new Vector3(offsetBehind, offsetUp, 0f);
            }//down
            else if (angleObj > 225 && angleObj <= 315)
            {
                offsetUp = 5f;
                offset = new Vector3(offsetBehind, 0f, offsetUp);
            }//right
            else if (angleObj <= 45 || angleObj > 315)
            {
                offsetUp = 5f;
                offset = new Vector3(offsetBehind, offsetUp, 0f);
            }//up
        }
        else if (eventSphere.inTurn == 4)
        {
            offsetBehind = -15f;
            //offsetUP
            if (angleObj > 45 && angleObj <= 135)
            {
                offsetUp = 5f;
                offset = new Vector3(offsetBehind, 0f, offsetUp);
            }//left
            else if (angleObj > 135 && angleObj <= 225)
            {
                offsetUp = -5f;
                offset = new Vector3(offsetBehind, offsetUp, 0f);
            }//down
            else if (angleObj > 225 && angleObj <= 315)
            {
                offsetUp = -5f;
                offset = new Vector3(offsetBehind, 0f, offsetUp);
            }//right
            else if (angleObj <= 45 || angleObj > 315)
            {
                offsetUp = 5f;
                offset = new Vector3(offsetBehind, offsetUp, 0f);
            }//up
        }
        else if (eventSphere.inTurn == 1)
        {
            offsetBehind = 15f;
            //offsetUP
            if (angleObj > 45 && angleObj <= 135)
            {
                offsetUp = 5f;
                offset = new Vector3(offsetUp, offsetBehind, 0f);
            }//left
            else if (angleObj > 135 && angleObj <= 225)
            {
                offsetUp = -5f;
                offset = new Vector3(0f, offsetBehind, offsetUp);
            }//down
            else if (angleObj > 225 && angleObj <= 315)
            {
                offsetUp = -5f;
                offset = new Vector3(offsetUp, offsetBehind, 0f);
            }//right
            else if (angleObj <= 45 || angleObj > 315)
            {
                offsetUp = 5f;
                offset = new Vector3(0f, offsetBehind, offsetUp);
            }//up
        }
        else if (eventSphere.inTurn == 3)
        {
            offsetBehind = -15f;
            //offsetUP
            if (angleObj > 45 && angleObj <= 135)
            {
                offsetUp = -5f;
                offset = new Vector3(offsetUp, offsetBehind, 0f);
            }//left
            else if (angleObj > 135 && angleObj <= 225)
            {
                offsetUp = 5f;
                offset = new Vector3(0f, offsetBehind, offsetUp);
            }//down
            else if (angleObj > 225 && angleObj <= 315)
            {
                offsetUp = 5f;
                offset = new Vector3(offsetUp, offsetBehind, 0f);
            }//right
            else if (angleObj <= 45 || angleObj > 315)
            {
                offsetUp = -5f;
                offset = new Vector3(0f, offsetBehind, offsetUp);
            }//up
            
        }
        else if (eventSphere.inTurn == 2)
        {
            offsetBehind = -15f;
            //offsetUP
            if (angleObj > 45 && angleObj <= 135)
            {
                offsetUp = -5f;
                offset = new Vector3(offsetUp, 0f, offsetBehind);
            }//left
            else if (angleObj > 135 && angleObj <= 225)
            {
                offsetUp = -5f;
                offset = new Vector3(0f, offsetUp, offsetBehind);
            }//down
            else if (angleObj > 225 && angleObj <= 315)
            {
                offsetUp = 5f;
                offset = new Vector3(offsetUp, 0f, offsetBehind);
            }//right
            else if (angleObj <= 45 || angleObj > 315)
            {
                offsetUp = 5f;
                offset = new Vector3(0f, offsetUp, offsetBehind);
            }//up
            
        }

        if ( !stpmove)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, obj.transform.position + offset, Time.deltaTime * 15f);
        }
        

        if (Input.GetMouseButtonDown(0))
        {
            startPos = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            posX = Mathf.Clamp(cam.ScreenToViewportPoint(Input.mousePosition).x - startPos.x, -2f, 2f);
            posY = Mathf.Clamp(cam.ScreenToViewportPoint(Input.mousePosition).y - startPos.y, -2f, 2f);
        }
        positionInScreanX = posX;
        positionInScreanY = posY;
    }

    
}
