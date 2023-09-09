using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanSlot : MonoBehaviour
{
    public GameObject foodItem;

    // Start is called before the first frame update
    void Start()
    {
        float a = Time.deltaTime;
    }



    // Update is called once per frame
    void Update()
    {
        if(foodItem != null)
        {
            Food food = foodItem.GetComponent<Food>();
            if(food != null)
            {
                float timeFried = Time.deltaTime;
                // food.fryFood(timeFried);
            }
            else
            {
                Debug.LogError("The food in the pan doesn't have a food component");
            }
        }
    }
}
