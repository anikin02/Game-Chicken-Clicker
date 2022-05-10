using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class saveGame : MonoBehaviour
{
    public GameObject Chicken;

    public GameObject FlowerOne;
    public GameObject FlowerTwo;
    public GameObject FlowerThree;

    public Image BuyOne;
    public Image BuyTwo;
    public Image BuyThree;
    public Image BuyFour;
 
    private Save save = new Save();
    private string path;
 
    private void Start()
    {
        path = Path.Combine(Application.persistentDataPath, "Save.json");

        if (File.Exists(path))
        {   
            save = JsonUtility.FromJson<Save>(File.ReadAllText(path));
            
            Chicken.GetComponent<chicken>().Egg = save.Eggs;
            Chicken.GetComponent<chicken>().Money = save.Money;
            Chicken.GetComponent<chicken>().CountEgg = save.CountEggs;
            Chicken.GetComponent<chicken>().Lvl = save.Sprite;

            BuyOne.GetComponent<buyChicken>().canBuy = save.CanBuyFirstChicken;
            BuyTwo.GetComponent<buyChicken>().canBuy = save.CanBuySecondChicken;
            BuyThree.GetComponent<buyChicken>().canBuy = save.CanBuyThirdChicken;
            BuyFour.GetComponent<buyChicken>().canBuy = save.CanBuyFourthChicken;
        
            FlowerOne.GetComponent<flowers>().Lvl = save.LvlFirstFlower;
            FlowerOne.GetComponent<flowers>().CountAdd = save.AddFirstFlower;
            FlowerOne.GetComponent<flowers>().Cost = save.CostFirstFlower;

            FlowerTwo.GetComponent<flowers>().Lvl = save.LvlSecondFlower;
            FlowerTwo.GetComponent<flowers>().CountAdd = save.AddSecondFlower;
            FlowerTwo.GetComponent<flowers>().Cost = save.CostSecondFlower;
        
            FlowerThree.GetComponent<flowers>().Lvl = save.LvlThridFlower;
            FlowerThree.GetComponent<flowers>().CountAdd = save.AddThridFlower;
            FlowerThree.GetComponent<flowers>().Cost = save.CostThridFlower;
        }
    }

    // Method for saving all parametrs.
    private void SaveAll()
    {
        save.Eggs = Chicken.GetComponent<chicken>().Egg;
        save.Money = Chicken.GetComponent<chicken>().Money;
        save.CountEggs = Chicken.GetComponent<chicken>().CountEgg;
        save.Sprite = Chicken.GetComponent<chicken>().Lvl;

        save.CanBuyFirstChicken = BuyOne.GetComponent<buyChicken>().canBuy;
        save.CanBuySecondChicken = BuyTwo.GetComponent<buyChicken>().canBuy;
        save.CanBuyThirdChicken = BuyThree.GetComponent<buyChicken>().canBuy;
        save.CanBuyFourthChicken = BuyFour.GetComponent<buyChicken>().canBuy;
        
        save.LvlFirstFlower = FlowerOne.GetComponent<flowers>().Lvl;
        save.AddFirstFlower = FlowerOne.GetComponent<flowers>().CountAdd;
        save.CostFirstFlower = FlowerOne.GetComponent<flowers>().Cost;

        save.LvlSecondFlower = FlowerTwo.GetComponent<flowers>().Lvl;
        save.AddSecondFlower = FlowerTwo.GetComponent<flowers>().CountAdd;
        save.CostSecondFlower = FlowerTwo.GetComponent<flowers>().Cost;
        
        save.LvlThridFlower = FlowerThree.GetComponent<flowers>().Lvl;
        save.AddThridFlower = FlowerThree.GetComponent<flowers>().CountAdd;
        save.CostThridFlower = FlowerThree.GetComponent<flowers>().Cost;
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {   
            SaveAll();
            File.WriteAllText(path, JsonUtility.ToJson(save));
        }   
    }
}

// Class of what we need to save.
[Serializable]
public class Save
{
    public int Eggs = 0;
    public int Money = 0;
    public int CountEggs = 1;
    public int Sprite = 0;

    public bool CanBuyFirstChicken = true;
    public bool CanBuySecondChicken = true;
    public bool CanBuyThirdChicken = true;
    public bool CanBuyFourthChicken = true;

    public int LvlFirstFlower = 0;
    public int CostFirstFlower = 500;
    public int AddFirstFlower = 0;

    public int LvlSecondFlower = 0;
    public int CostSecondFlower = 500000;
    public int AddSecondFlower = 0;

    public int LvlThridFlower = 0;
    public int CostThridFlower = 5000000;
    public int AddThridFlower = 0;
}