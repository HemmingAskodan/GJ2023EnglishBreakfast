using UnityEngine;

public class Currency : MonoBehaviour
{
    public float playerMoney = 200.0f; // Initial money amount, 200 dollars
    public float eggCost = 8.0f; // Cost of buying eggs, 8 dollars
    public float baconCost = 10.0f; // Cost of buying bacon, 10 dollars
    public float beansCost = 6.0f; // Cost of buying beans, 6 dollars

    // Method to buy an item
    public bool BuyItem(string itemName)
    {
        float itemCost = 0.0f;

        // Determine the cost based on the item name
        switch (itemName.ToLower())
        {
            case "egg":
                itemCost = eggCost;
                break;
            case "bacon":
                itemCost = baconCost;
                break;
            case "beans":
                itemCost = beansCost;
                break;
            default:
                return false; // Invalid item name
        }

        if (playerMoney >= itemCost)
        {
            playerMoney -= itemCost; // Deduct the item cost
            return true; // Purchase successful
        }
        else
        {
            return false; // Not enough money to buy the item
        }
    }


    // // Method to sell an item with a variable price between $5 and $12
    // public void SellItem()
    // {
    //     float itemSellPrice = Random.Range(5.0f, 12.0f); // Generate a random selling price
    //     playerMoney += itemSellPrice; // Add the selling price to the player's money
    // }

    // Method to get the current player money amount
    public float GetPlayerMoney()
    {
        return playerMoney;
    }
}
