using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanSlot : MonoBehaviour
{
    public GameObject foodItem;
    // Update is called once per frame
    void Update()
    {
        if (foodItem != null)
        {
            Food food = foodItem.GetComponent<Food>();
            if (food != null)
            {
                food.fryFood();
            }
            else
            {
                Debug.LogError("The food in the pan doesn't have a food component");
            }
        }
    }

    public bool isPanOccupied()
    {
        return foodItem != null;
    }

    public void PutOnPan(GameObject item)
    {
        foodItem = item;
    }

    public GameObject GiveFromPan()
    {
        GameObject givenFoodItem = foodItem;
        foodItem = null;
        return givenFoodItem;
    }
}
