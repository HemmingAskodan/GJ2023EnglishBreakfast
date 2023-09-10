using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public FinalPlate finalPlate;
    public void ClearFinalPlate()
    {
        finalPlate.ClearPlate();
    }
}