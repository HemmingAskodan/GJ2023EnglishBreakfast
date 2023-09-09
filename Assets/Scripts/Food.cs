using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float foodFryTime = 10f;
    private float currentFryTime = 0f;
    float baconItem;

    float sellEgg = 10;


    float beansItem;

    string cookingStatus;

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

    public void CookTime()
    {

    }

    // The status of the food changes
    public void IsFoodFried()
    {
        if (foodFryTime <= 59)
        {
            cookingStatus = "undercooked";
        }
        else if (foodFryTime <= 60)
        {
            cookingStatus = "good";
        }
        else if (foodFryTime <= 120)
        {
            cookingStatus = "overcooked";

        }
    }

    public void fryFood()
    {
        currentFryTime += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;
    }
}
