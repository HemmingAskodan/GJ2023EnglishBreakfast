using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Animator animator;
    
    private float currentFryTime = 0f;

    // public float foodItem;

    public string foodName;

    // public string cookingFeedback { get; private set; }

    public float optimalSell = 10.0f; //optimal price of food is 10 dollars
    public float optimalTimeSeconds = 10.0f; //perfect cooking time is 10 seconds
    public float acceptedOffset = 2.0f; //it is acceptable if cooking time 2 seconds less or more
    public float missingCookOffset = 5.0f; //5 seconds less than perfect cooking time is unacceptable

    public float buyFoodPrice = 2.0f;
    private static readonly int FryTimeKey = Animator.StringToHash("fry-time");

    // public float currentSellValue { get; private set; }


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
        currentFryTime += Time.deltaTime;
        animator.SetFloat(FryTimeKey, currentFryTime);
    }

    // Calculates whether or not the food has been cooked for the right amount of time
    // After sending the food, the player receives a message with feedback
    public string GetCookingFeedback()
    {
        if (currentFryTime <= (optimalTimeSeconds - acceptedOffset - missingCookOffset))
        {
            return "unacceptable";
        }
        else if (currentFryTime < (optimalTimeSeconds - acceptedOffset))
        {
            return "undercooked";
        }
        else if (currentFryTime > (optimalTimeSeconds + acceptedOffset))
        {
            return "overcooked";
        }
        else if (currentFryTime >= (optimalTimeSeconds + acceptedOffset + missingCookOffset))
        {
            return "unacceptable";
        }
        else
        {
            return "perfect";
        }
    }


    // // Update is called once per frame
    // void Update()
    // {
    //     float time = Time.deltaTime;
    // }

    public float calculateSellValue()
    {
        if (currentFryTime >= optimalTimeSeconds - acceptedOffset && currentFryTime <= optimalTimeSeconds + acceptedOffset)
            return optimalSell;

        if (currentFryTime < optimalTimeSeconds - acceptedOffset)
        {
            float sell = optimalTimeSeconds - optimalTimeSeconds * ((optimalTimeSeconds - acceptedOffset - currentFryTime) / missingCookOffset);
            return Mathf.Max(0, sell);
        }

        if (currentFryTime > optimalTimeSeconds + acceptedOffset)
        {
            float sell = optimalTimeSeconds - optimalTimeSeconds * ((-(optimalTimeSeconds + acceptedOffset) + currentFryTime) / missingCookOffset);
            return Mathf.Max(0, sell);
        }

        return 0;
    }
}
