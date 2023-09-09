using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlate : MonoBehaviour
{
    List<Food> foodList = new List<Food>();

    public bool AddFoodItem(GameObject gameObject)
    {
        Food food = gameObject.GetComponent<Food>();
        if (food == null)
        {
            return false;
        }

        foodList.Add(food);
        return true;
    }

    public void ClearPlate()
    {
        foreach (Food food in foodList)
        {
            Destroy(food.gameObject);
        }
        foodList.Clear();
    }
}
