using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct BreakfastOrderObj
{
    public string foodName;
    public float foodAmount;
}
public class BreakfastOrder : MonoBehaviour
{
    private float orderStarted;
    private float willingWaitTimeSeconds = 40f;
    public float penaltyOnTimeOut = 5f;
    public Image barImage;
    List<string> listOrder = new List<string>();
    public string[] orderVariation = { "Egg", "Bacon", "Baked beans", "Sausage" };
    public Sprite[] orderVariationImages = { };
    BreakfastOrderObj[] orderVariationObjs;
    public Transform FoodImagesTransform;
    public GameObject UIImage;

    void Awake()
    {
        CreateOrder();
    }

    // Update is called once per frame
    void Update()
    {
        barImage.fillAmount = 1 - ((Time.time - orderStarted) / willingWaitTimeSeconds);

        if (orderStarted + willingWaitTimeSeconds < Time.time)
        {
            OrderTimesOut();
        }
    }

    void CreateOrder()
    {
        orderStarted = Time.time;
        int orderAmount = UnityEngine.Random.Range(1, 5);

        for (int i = 0; i < orderAmount; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, orderVariation.Length);
            listOrder.Add(orderVariation[randomIndex]);
            GameObject uIImage = Instantiate(UIImage, FoodImagesTransform);
            Image image = uIImage.GetComponentInChildren<Image>();
            image.sprite = orderVariationImages[randomIndex];
        }

        // listOrder.Sort((x, y) => { return Array.IndexOf(orderVariation, x) > Array.IndexOf(orderVariation, y) ? 1 : -1; });

        orderVariationObjs = new BreakfastOrderObj[orderVariation.Length];
        for (int i = 0; i < orderVariation.Length; i++)
        {
            orderVariationObjs[i].foodName = orderVariation[i];
        }
        for (int i = 0; i < listOrder.Count; i++)
        {
            orderVariationObjs[Array.IndexOf(orderVariation, listOrder[i])].foodAmount += 1;
        }
    }

    void OrderTimesOut()
    {
        // TODO: Set a penalty to the currency with parameter: penaltyOnTimeOut

        Destroy(this.gameObject);
    }

    public BreakfastOrderObj[] GetBreakfastOrder()
    {
        return orderVariationObjs;
    }
}
