using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public Text currencyText;
    public float playerMoney = 200.0f; // Initial money amount, 200 dollars
    public GameObject currencyWinText;

    // Method to buy an item
    public bool BuyItem(float itemCost)
    {
        if (playerMoney >= itemCost)
        {
            playerMoney -= itemCost; // Deduct the item cost
            AddWinLossText(-itemCost);
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
        playerMoney += amount;
        AddWinLossText(amount);
        PrintAmount();
    }

    private void AddWinLossText(float amount)
    {
        GameObject textGO = Instantiate(currencyWinText, transform.position + (Vector3.up * 50), Quaternion.identity, transform.parent);
        textGO.GetComponent<CurrencyChangeText>().SetValue(amount);
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
