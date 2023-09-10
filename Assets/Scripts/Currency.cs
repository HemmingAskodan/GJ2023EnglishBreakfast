using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public Text currencyText;
    public float playerMoney = 200.0f; // Initial money amount, 200 dollars
    public float itemCost; // The price for each raw item

    // Method to buy an item
    public bool BuyItem(float itemCost)
    {
        if (playerMoney >= itemCost)
        {
            playerMoney -= itemCost; // Deduct the item cost
            PrintAmount();
            return true; // Purchase successful
        }
        else
        {
            return false; // Not enough money to buy the item
        }
    }

    public void AddMoney(float amount)
    {
        playerMoney += itemCost;
        PrintAmount();
    }

    void PrintAmount()
    {
        currencyText.text = playerMoney.ToString("n2") + " $";
    }

    // Method to get the current player money amount
    public float GetPlayerMoney()
    {
        return playerMoney;
    }
}
