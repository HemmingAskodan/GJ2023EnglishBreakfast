using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Bell : MonoBehaviour
{
    public FinalPlate finalPlate;
    public BreakfastOrderList breakfastOrderList;
    public void RingBell()
    {

        // Play sound *Ding*

        Food[] finalFoodPlate = finalPlate.GetFinalFoodPlate();
        BreakfastOrderObj[][] breakfastOrders = breakfastOrderList.GetBreakfastOrders();

        int indexOrder = indexOfBreakfastOrder(finalFoodPlate.Select(x => x.foodName).ToArray(), breakfastOrders);

        print("Index found is:" + indexOrder);

        if (indexOrder != -1)
        {
            float plateValue = finalPlate.CalculateValueOfPlate();
            breakfastOrderList.RemoveBreakfastOrder(indexOrder);
            finalPlate.ClearPlate();
            // TODO: plateValue needs to be added to currency.
        }
    }

    int indexOfBreakfastOrder(string[] foodPlate, BreakfastOrderObj[][] breakfastOrders)
    {
        if (foodPlate.Length == 0)
            return -1;

        List<string> foodPlateSorted = foodPlate.ToList();
        foodPlateSorted = foodPlateSorted.OrderBy(q => q).ToList();
        string foodPlateString = foodPlateSorted.Aggregate((x, y) => x + y);

        for (int i = 0; i < breakfastOrders.Length; i++)
        {
            List<string> orderFoodStrings = new List<string>();
            for (int j = 0; j < breakfastOrders[i].Length; j++)
            {
                for (int k = 0; k < breakfastOrders[i][j].foodAmount; k++)
                {
                    orderFoodStrings.Add(breakfastOrders[i][j].foodName);
                }
            }
            List<string> listOrderSorted = orderFoodStrings;
            listOrderSorted = listOrderSorted.OrderBy(q => q).ToList();
            string breakfastOrderString = listOrderSorted.Aggregate((x, y) => x + y);

            print("if (" + breakfastOrderString + "==" + foodPlateString + ")");
            if (breakfastOrderString == foodPlateString)
            {
                return i;
            }
        }

        return -1;
    }
}
