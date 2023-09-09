using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System;

public class BreakfastOrder : MonoBehaviour
{
    public float willingWaitTimeSeconds = 60;
    List<string> listOrder = new List<string>();
    public string[] orderVariation = { "Egg", "Bacon", "Baked beans", "Sausage" };
    int[] orderVariationAmounts;

    void Awake()
    {
        CreateOrder();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateOrder()
    {

        int orderAmount = UnityEngine.Random.Range(1, 5);

        for (int i = 0; i < orderAmount; i++)
        {
            listOrder.Add(orderVariation[UnityEngine.Random.Range(0, orderVariation.Length)]);
        }

        // listOrder.Sort((x, y) => { return Array.IndexOf(orderVariation, x) > Array.IndexOf(orderVariation, y) ? 1 : -1; });

        orderVariationAmounts = new int[orderVariation.Length];
        for (int i = 0; i < listOrder.Count; i++)
        {
            orderVariationAmounts[Array.IndexOf(orderVariation, listOrder[i])] += 1;
        }
    }
}
