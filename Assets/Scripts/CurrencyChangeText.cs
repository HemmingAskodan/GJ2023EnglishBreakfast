using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyChangeText : MonoBehaviour
{
    public Text text;
    private float bornTime;
    public float shownTime;
    public float fadeTime;
    public float upSpeed;

    void Awake()
    {
        bornTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * upSpeed * Time.deltaTime);
        if (Time.time < (bornTime + shownTime))
        {
            Color c = text.color;
            text.color = new Color(c.r, c.g, c.b, c.a - (Time.deltaTime / fadeTime));
        }
    }

    public void SetValue(float amount)
    {
        if (amount >= 0)
        {
            text.color = new Color(0, 130f / 255f, 0);
            text.text = "+" + amount.ToString("n2") + " $";
        }
        else
        {
            text.color = new Color(200f / 255f, 0, 0);
            text.text = amount.ToString("n2") + " $";
        }
    }
}
