using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateRM : MonoBehaviour
{
    public static int turn;
    public int num;
    public int turnNum;
    public int pastTurnNum;
    
    //0 - вліво
    //1 - вниз
    //2 - вперед
    //3 - вверх
    //4 - вправо
    void Start()
    {
        turn = turnNum;
        name = "rotateBox_" + num;
    }
}
