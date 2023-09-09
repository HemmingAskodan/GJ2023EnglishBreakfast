using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    float foodTime;
    float baconItem;

    float

    float beansItem;

    string cookingStatus;

    void Awake()
    { }

    // Start is called before the first frame update
    void Start()
    {

    }

    //Prices for buying food items
    public void FoodPrices(float buyEgg, float buyBacon, float buyBeans)
    {
        buyEgg = 10.0f;
        buyBacon = 8.5f;
        buyBeans = 12.0f;
    }

    public void CookTime()
    {

    }

    // The status of the food changes
    public void IsFoodFried()
    {
        if (foodTime <= 59)
        {
            cookingStatus = "undercooked";
        }
        else if (foodTime <= 60)
        {
            cookingStatus = "good";
        }
        else if (foodTime <= 120)
        {
            cookingStatus = "overcooked";

        }
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;
    }
}
