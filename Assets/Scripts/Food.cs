using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    private float currentFryTime = 0f;

    // public float foodItem;

    public string foodName;

    public string cookingFeedback { get; private set; }

    public float optimalSell = 10.0f;
    public float foodValue = 10.0f;
    private float optimalTimeSeconds = 10.0f;
    private float acceptedOffset = 2.0f;
    private float missingCookOffset = 5.0f;

    public float currentSellValue { get; private set; }


    void Awake()
    { }

    // Start is called before the first frame update
    void Start()
    {

    }

    // //Prices for buying food items
    // public void FoodPrices(float eggPrice, float baconPrice, float beansPrice)
    // {
    //     eggPrice = 10.0f;
    //     baconPrice = 8.5f;
    //     beansPrice = 12.0f;

    //     if (cookingStatus == "undercooked")
    //     {
    //         eggPrice = eggPrice - 7;
    //         baconPrice = baconPrice - 7;
    //         beansPrice = beansPrice - 7;
    //     }
    // }

    // public void SellPrices(float sellEgg, float sellBacon, float sellBeans)
    // {
    //     if 
    // }

    // public void CookTime()
    // {

    // }

    public void fryFood()
    //Calculates the value of the food, judging by how long it's on the pan
    {
        currentSellValue = optimalSell - optimalTimeSeconds * currentFryTime;
        currentFryTime += Time.deltaTime;
    }

    // Calculates if the food has been cooked for the right amount of time
    // After sending the food, the player receives a message with feedback
    public void IsFoodFried()
    {
        if (currentFryTime <= (optimalTimeSeconds - acceptedOffset - missingCookOffset))
        {
            cookingFeedback = "unacceptable";
        }
        else if (currentFryTime < (optimalTimeSeconds - acceptedOffset))
        {
            cookingFeedback = "undercooked";
        }
        else if (currentFryTime > (optimalTimeSeconds + acceptedOffset))
        {
            cookingFeedback = "overcooked";
        }
        else if (currentFryTime >= (optimalTimeSeconds + acceptedOffset + missingCookOffset))
        {
            cookingFeedback = "unacceptable";
        }
        else
        {
            cookingFeedback = "perfect";
        }
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
