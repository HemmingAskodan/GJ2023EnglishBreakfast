using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    float foodTime;

    string cookingStatus;

    void Awake()
    { }

    // Start is called before the first frame update
    void Start()
    {

    }

    // The status of the food changes
    public void FryingFood()
    {
        if (foodTime <= 59)
        {
            baconStatus = "undercooked";
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
