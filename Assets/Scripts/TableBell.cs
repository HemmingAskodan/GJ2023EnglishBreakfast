using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBell : MonoBehaviour
{
    public FinalPlate finalPlate;
    public void RingBell()
    {

        // Play sound *Ding*

        Food[] finalFoodPlate = finalPlate.GetFinalFoodPlate();
    }
}
