using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Xml.Schema;

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

    public float CalculateValueOfPlate()
    {
        List<float> sellValues = new List<float>();
        for (int i = 0; i < foodList.Count; i++)
        {
            sellValues.Add(foodList[i].calculateSellValue());
        }

        float totalValue = sellValues.Aggregate((a, b) => a + b);

        if (sellValues.Any(x => x == 0))
        {
            totalValue = 0;
        }

        return totalValue;
    }

    public Food[] GetFinalFoodPlate()
    {
        return foodList.ToArray();
    }
}
