using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float currentFryTime = 10f;
    private float currentFryTime = 0f;

    public float foodItem;

    public string foodName;

    public float optimalSell = 10.0f;
    public float foodValue = 10.0f;
    public float optimalTimeSeconds = 10.0f;
    public float acceptedOffset = 2.0f;

    public float currentSellValue { get; private set; }


    void Awake()
    { }

    // Start is called before the first frame update
    void Start()
    {

    }

    //Prices for buying food items
    public void FoodPrices(float eggPrice, float baconPrice, float beansPrice)
    {
        eggPrice = 10.0f;
        baconPrice = 8.5f;
        beansPrice = 12.0f;

        if (cookingStatus == "undercooked")
        {
            eggPrice = eggPrice - 7;
            baconPrice = baconPrice - 7;
            beansPrice = beansPrice - 7;
        }
    }

    // public void SellPrices(float sellEgg, float sellBacon, float sellBeans)
    // {
    //     if 
    // }

    // public void CookTime()
    // {

    // }

    // The status of the food changes
    public void IsFoodFried()
    {
        if (currentFryTime <= (optimalTimeSeconds - acceptedOffset))
        {
            cookingStatus = "undercooked";
        }
        else if (currentFryTime >= (optimalTimeSeconds + acceptedOffset))
        {
            cookingStatus = "overcooked";
        }
        else if (currentFryTime <= ())
    }

    public void fryFood()
    {
        currentSellValue = optimalSell - optimalTimeSeconds * currentFryTime;
        currentFryTime += Time.deltaTime;
    }

    // //Calculates how much money you get for the good
    // public float calculateSellValue(float optimalSell, float acceptedOffset, float missingCookOffset)
    // {
    //     optimalSell = 10.0f;

    //     //Formula for the food's sell value. 8-10 seconds cooking is right.
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     float time = Time.deltaTime;
    // }
}
