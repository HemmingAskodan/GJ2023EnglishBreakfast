using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSlot : MonoBehaviour
{
    public GameObject foodItem;
    private Vector3 mouseWorldPosition => Camera.main.ScreenToWorldPoint(Input.mousePosition);
    public Currency currency;

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
                        currency.BuyItem(foodItem.GetComponent<Food>().buyFoodPrice);
                    }
                }

                PanSlot panSlot = collider2D.GetComponent<PanSlot>();
                if (panSlot != null)
                {
                    if (panSlot.isPanOccupied())
                    {
                        if (foodItem == null)
                        {
                            PickupFoodItem(panSlot.GiveFromPan());
                        }
                        else
                        {
                            // Swap items
                            // GameObject tempItem = foodItem;
                            // PickupFoodItem(panSlot.GiveFromPan());
                            // panSlot.PutOnPan(tempItem);
                        }
                    }
                    else
                    {
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

                FinalPlate finalPlate = collider2D.GetComponent<FinalPlate>();
                if (finalPlate != null)
                {
                    if (foodItem != null)
                    {
                        finalPlate.AddFoodItem(PlaceDownFoodItem());
                    }
                    else
                    {
                        // Not able to pickup from this plate.
                    }
                }

                Bell bell = collider2D.GetComponent<Bell>();
                if (bell != null)
                {
                    if (foodItem == null)
                    {
                        bell.RingBell();
                    }
                }

                TrashCan trashCan = collider2D.GetComponent<TrashCan>();
                if (trashCan != null)
                {
                    if (foodItem == null)
                    {
                        trashCan.ClearFinalPlate();
                    }
                    else
                    {
                        Destroy(PlaceDownFoodItem().gameObject);
                    }
                }
            }
        }
    }

    private bool PickupFoodItem(GameObject item)
    {
        if (foodItem == null)
        {
            foodItem = item;
            return true;
        }
        else
        {
            return false;
        }
    }

    private GameObject PlaceDownFoodItem()
    {
        GameObject foodToPlace = foodItem;
        foodItem = null;
        return foodToPlace;
    }
}
