using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakfastOrderList : MonoBehaviour
{
    public GameObject breakfastOrderGO;
    List<BreakfastOrder> breakfastOrders = new List<BreakfastOrder>();
    float timeUntilNextOrder;
    public float minimumTimeUntilNextOrder = 2;
    public float maximumTimeUntilNextOrder = 20;

    // Start is called before the first frame update
    void Start()
    {
        CreateBreakfastOrder();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeUntilNextOrder < Time.time)
        {
            CreateBreakfastOrder();
        }
    }

    void CreateBreakfastOrder()
    {
        GameObject breakfastOrderGO = Instantiate(this.breakfastOrderGO, gameObject.transform);

        BreakfastOrder breakfastOrder = breakfastOrderGO.GetComponent<BreakfastOrder>();
        if (breakfastOrder == null)
        {
            Debug.LogError("GameObject didn't have a BreakfastOrder component.");
            return;
        }

        breakfastOrders.Add(breakfastOrder);

        timeUntilNextOrder = Time.time + Random.Range(minimumTimeUntilNextOrder, maximumTimeUntilNextOrder);
    }
}
