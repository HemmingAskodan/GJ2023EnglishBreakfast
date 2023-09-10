using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Bell : MonoBehaviour
{
    public FinalPlate finalPlate;
    public BreakfastOrderList breakfastOrderList;
    public void RingBell()
    {

        // Play sound *Ding*

        Food[] finalFoodPlate = finalPlate.GetFinalFoodPlate();
        BreakfastOrderObj[][] breakfastOrders = breakfastOrderList.GetBreakfastOrders();

        int indexOrder = indexOfBreakfastOrder(finalFoodPlate, breakfastOrders);

        if (indexOrder != -1)
        {
            float plateValue = finalPlate.CalculateValueOfPlate();
            breakfastOrderList.RemoveBreakfastOrder(indexOrder);

            // TODO: plateValue needs to be added to currency.
        }
    }

    int indexOfBreakfastOrder(Food[] foodPlate, BreakfastOrderObj[][] breakfastOrders)
    {
        for (int i = 0; i < breakfastOrders.Length; i++)
        {
            bool[] checkedFoods = new bool[breakfastOrders[i].Length]; // All start with false

            foreach (Food food in foodPlate)
            {
                for (int j = 0; j < breakfastOrders[i].Length; j++)
                {
                    if (!checkedFoods[j] && food.foodName == breakfastOrders[i][j].foodName)
                    {
                        checkedFoods[j] = true;
                        break;
                    }
                }
            }

            if (checkedFoods.All(x => true))
            {
                return i;
            }
        }

        return -1;
    }
}
