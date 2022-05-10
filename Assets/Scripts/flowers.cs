using UnityEngine;
using UnityEngine.UI;

public class flowers : MonoBehaviour
{   
    public GameObject Chicken;
    public Sprite MySprite;
    public Text CostUI;
    public Text LvlUI;
    
    public int Cost = 500;
    public int Lvl = 0;
    public int CountAdd = 0;

    private void Start()
    {
        LvlUI.text = "lvl." + Lvl.ToString();
        CostUI.text = ConvertMoneyToString(Cost) + " " + "$";

        InvokeRepeating("AddToMoney", 0, 3);

        // Activation sprite at startup.
        if (Lvl != 0)
        {
            GetComponent<SpriteRenderer>().sprite = MySprite;
        }
    }

    private void OnMouseDown()
    {
        BuyingUpgrading();
    }
    
    private void BuyingUpgrading()
    {
        if (Chicken.GetComponent<chicken>().Money >= Cost)
        {
            Chicken.GetComponent<chicken>().Money -= Cost;

            if ( Lvl == 0)
            {
                Lvl++;
                GetComponent<SpriteRenderer>().sprite = MySprite;
                CountAdd = Cost / 500;
                Cost+=CountAdd;
            }
            else
            {
                Lvl++;
                CountAdd += Cost / 500;
                Cost+=CountAdd;
            }

            LvlUI.text = "lvl" + Lvl.ToString();
            CostUI.text = ConvertMoneyToString(Cost) + " " + "$";
        }
    }

    private void AddToMoney()
    {
        Chicken.GetComponent<chicken>().Money += CountAdd;
    }

    // Method that converts money into a string.
    // Example:
    // Money = 10000
    // String = "10K $"
    private string ConvertMoneyToString(int money)
    {
        if (money>1000)
        {
            if (money>1000000)
            {   
                if (money>1000000000)
                {
                    return (money/1000000000).ToString() + "B";
                }
                else
                {
                    return (money/1000000).ToString() + "M";
                }
            }
            else
            {
                return (money/1000).ToString() + "K";
            }
        }
        else
        {
            return money.ToString();
        }
    }
}
