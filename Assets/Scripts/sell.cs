using System;
using static UnityEngine.Debug;
using UnityEngine;
using UnityEngine.UI;

public class sell : MonoBehaviour
{   
    public GameObject Chicken;
    
    public int CountMoney = 1;
    public int CountEggs = 10;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Selling);
    }

    // Method for selling eggs.
    private void Selling()
    {
        if (Chicken.GetComponent<chicken>().Egg >= CountEggs)
        {   
            Chicken.GetComponent<chicken>().Money += CountMoney;
            Chicken.GetComponent<chicken>().Egg -= CountEggs;
        }
    }
}
