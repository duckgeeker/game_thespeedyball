using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createWay : MonoBehaviour
{
    private int count;
    public int firstRotate;
    public GameObject cube;
    public GameObject rotate;
    public GameObject coin;
    public GameObject deadBlock;
    public GameObject crystal;
    public GameObject folderForTurn;
    public GameObject folderForCube;
    public int firstTurn = 4;

    GameObject[] obj;

    // Start is called before the first frame update
    void Start()
    {
        folderForTurn.transform.parent = transform;
        folderForCube.transform.parent = transform;

        count = 500;
        cubeSize = cube.GetComponent<BoxCollider>().size;
        obj = new GameObject[count];
        
        for (int i = 0; i < count; i++)
        {
            way(i);
        }
        Destroy(cube);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 cubeSize;
    Vector3 spawnWay = new Vector3(0f, 0f, 0f);
    int randomRoad = 2;
    int pastRand = 2;
    int getRand;
    int specialTurn = 1;

    public void way(int i)
    {
        float oneC = cubeSize.z * 2; // one cube

        obj[i] = Instantiate(cube) as GameObject;
        obj[i].name = "cube_" + i;

        if (i < firstRotate)
        {
            obj[i].transform.position = spawnWay + new Vector3(0f, 0f, oneC * i);
        }
        else if ( i == 0 )
        {
            obj[i].transform.position = spawnWay;
        }
        else if ( i >= firstRotate)
        {

            if (randomRoad == 4)//вправо
            {
                obj[i].transform.position = obj[i - 1].transform.position + new Vector3(oneC, 0f, 0f);
            }
            else if (randomRoad == 0)//вліво
            {
                obj[i].transform.position = obj[i - 1].transform.position + new Vector3(-oneC, 0f, 0f);
            }
            else if (randomRoad == 3)//вверх
            {
                obj[i].transform.position = obj[i - 1].transform.position + new Vector3(0f, oneC, 0f);
            }
            else if (randomRoad == 1)//вниз
            {
                obj[i].transform.position = obj[i - 1].transform.position + new Vector3(0f, -oneC, 0f);
            }
            else if (randomRoad == 2)//вперед
            {
                obj[i].transform.position = obj[i - 1].transform.position + new Vector3(0f, 0f, oneC);
            }

            if (i % 10 == 0)//поворот кожні 5 ітерацій
            {
                if (pastRand == 0)
                {
                    randomRoad = Random.Range(0, 4);
                }
                else if (pastRand == 1)
                {
                    randomRoad = 2;
                }
                else if (pastRand == 3)
                {
                    randomRoad = 2;
                }
                else if (pastRand == 4)
                {
                    randomRoad = Random.Range(1, 5);
                }
                else if (pastRand == 2)
                {
                    randomRoad = Random.Range(0, 5);
                }

                if ( specialTurn == 1 )
                {
                    randomRoad = firstTurn;
                    specialTurn = 0;
                }
                if (randomRoad != pastRand)//створює елемент повороту лише на поворотах
                    {
                        switch (randomRoad)
                        {
                            case 0:
                                turnWay(obj[i].transform.position, randomRoad, pastRand);
                                break;
                            case 1:
                                turnWay(obj[i].transform.position, randomRoad, pastRand);
                                break;
                            case 2:
                                turnWay(obj[i].transform.position, randomRoad, pastRand);
                                break;
                            case 3:
                                turnWay(obj[i].transform.position, randomRoad, pastRand);
                                break;
                            case 4:
                                turnWay(obj[i].transform.position, randomRoad, pastRand);
                                break;
                        }
                    }

                pastRand = randomRoad;
            }
            //dropItem(obj[i - 1].transform.position, randomRoad);
        }

        
        obj[i].transform.parent = folderForCube.transform;
        
    }

    GameObject turnObj;
    int turnNum = 0;
    void turnWay(Vector3 pos, int sideT, int sideTP)
    {
        turnObj = Instantiate(rotate) as GameObject;
        turnObj.transform.parent = folderForTurn.transform;
        turnObj.GetComponent<rotateRM>().turnNum = sideT;
        turnObj.GetComponent<rotateRM>().pastTurnNum = sideTP;
        turnObj.transform.position = pos;
        turnObj.GetComponent<rotateRM>().num = turnNum;
        turnNum++;

        if ((sideTP == 0 || sideTP == 4) && sideT == 2)
        {
            turnObj.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 90);
        }
        if ((sideTP == 0 || sideTP == 4) && (sideT == 1 || sideT == 3))
        {
            turnObj.GetComponent<Transform>().rotation = Quaternion.Euler(0, 90, 0);
        }
        if ((sideTP == 3 || sideTP == 1) && sideT == 2)
        {
            turnObj.GetComponent<Transform>().rotation = Quaternion.Euler(90, 0, 0);
        }
        if ((sideTP == 3 || sideTP == 1) && (sideT == 4 || sideT == 0))
        {
            turnObj.GetComponent<Transform>().rotation = Quaternion.Euler(0, 90, 0);
        }
        if (sideTP == 2 && (sideT == 3 || sideT == 1))
        {
            turnObj.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
        }
        if (sideTP == 2 && (sideT == 4 || sideT == 0))
        {
            turnObj.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    GameObject item;
    Vector3 pos1;
    void dropItem(Vector3 pos, int sideT)
    {
        
        //TO CHOOSE DROP ITEM
        int randomItem = Random.Range(0, 100);
        if ( randomItem <= 49 )
        {
            item = Instantiate(coin) as GameObject;
            //item.transform.parent = folderForTurn.transform;
        }
        else if ( randomItem == 50 )
        {
            item = Instantiate(coin) as GameObject;
            //item = Instantiate(deadBlock) as GameObject;
            //item.transform.parent = folderForTurn.transform;
        }
        else
        {
            item = Instantiate(coin) as GameObject;
            //item = Instantiate(crystal) as GameObject;
            //item.transform.parent = folderForTurn.transform;
        }
        
        if (sideT == 2)
        {
            item.transform.rotation = Quaternion.Euler(0, 0, 0);
            pos1 = new Vector3(0f,2f,0f);
        }
        else if (sideT == 1 || sideT == 3)
        {
            item.transform.rotation = Quaternion.Euler(0, 90, 0);
            pos1 = new Vector3(0f, 2f, 0f);
        }
        else if (sideT == 0 || sideT == 4)
        {
            item.transform.rotation = Quaternion.Euler(90, 0, 0);
            pos1 = new Vector3(0f, 0f, -2f);
        }
        item.transform.position = pos1 + pos;
        item.transform.parent = folderForTurn.transform;
    }

}
