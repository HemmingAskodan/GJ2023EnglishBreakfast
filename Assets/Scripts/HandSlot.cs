using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSlot : MonoBehaviour
{
    public GameObject foodItem;
    private Vector3 mouseWorldPosition => Camera.main.ScreenToWorldPoint(Input.mousePosition);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Process of the food item following the cursor.
        if (foodItem != null)
        {
            Vector3 foodPosition = mouseWorldPosition;
            foodPosition.z = 0;
            foodItem.transform.position = foodPosition;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            foreach (Collider2D collider2D in Physics2D.OverlapPointAll(mouseWorldPosition))
            {
                FoodPantry foodPantry = collider2D.GetComponent<FoodPantry>();
                if (foodPantry != null)
                {
                    if (foodItem == null) // Hand is empty
                    {
                        GameObject newFoodItem = Instantiate(foodPantry.foodItem);
                        PickupFoodItem(newFoodItem);
                    }
                }

                PanSlot panSlot = collider2D.GetComponent<PanSlot>();
                if (panSlot != null)
                {
                    print("Inside Pan slot..");
                    if (panSlot.isPanOccupied())
                    {
                        print("occupied");
                        if (foodItem == null)
                        {
                            print("taking food");
                            PickupFoodItem(panSlot.GiveFromPan());
                        }
                        else
                        {
                            // Swap items
                            GameObject tempItem = foodItem;
                            PickupFoodItem(panSlot.GiveFromPan());
                            panSlot.PutOnPan(tempItem);
                        }
                    }
                    else
                    {
                        print("not occupied");
                        print(foodItem);
                        if (foodItem == null)
                        {
                            // Nothing to do
                        }
                        else
                        {
                            panSlot.PutOnPan(PlaceDownFoodItem());
                        }
                    }
                }
            }
        }
    }

    public void PickupFoodItem(GameObject item)
    {
        foodItem = item;
    }

    GameObject PlaceDownFoodItem()
    {
        GameObject foodToPlace = foodItem;
        foodItem = null;
        return foodToPlace;
    }
}
