using UnityEngine;
using UnityEngine.UI;

public class chicken : MonoBehaviour
{   
    public int Egg = 0;
    public int Money = 0;
    public int CountEgg = 1;
    public int Lvl = 1;
    public bool ChickenEnabled = true;
    public AudioSource Cluck;
    
    public Text EggUI;
    public Text MoneyUI;

    public Sprite SpriteForLvlTwo;
    public Sprite SpriteForLvlThree;
    public Sprite SpriteForLvlFour;
    public Sprite SpriteForLvlFive;

    private void Start()
    {   
        switch(Lvl)
        {
            case 2:
                GetComponent<SpriteRenderer>().sprite = SpriteForLvlTwo;
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = SpriteForLvlThree;
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = SpriteForLvlFour;
                break;
            case 5:
                GetComponent<SpriteRenderer>().sprite = SpriteForLvlFive;
                break;

        } 
    }

    private void Update()
    {
        ShowEggMoney();
    }

    private void OnMouseDown()
    {   
        if (ChickenEnabled)
        {
            AddEgg();
        }
    }

    private void ShowEggMoney()
    {
        if (Egg>1000)
        {
            if (Egg>1000000)
            {
                EggUI.text = (Egg/1000000).ToString() + "M";
            }
            else
            {
                EggUI.text = (Egg/1000).ToString() + "K";
            }
        }
        else
        {
            EggUI.text = Egg.ToString();
        }

        if (Money>1000)
        {
            if (Money>1000000)
            {
                MoneyUI.text = (Money/1000000).ToString() + "M";
            }
            else
            {
                MoneyUI.text = (Money/1000).ToString() + "K";
            }
        }
        else
        {
            MoneyUI.text = Money.ToString();
        }
    }

    public void AddEgg()
    {
            GetComponent<Animator>().SetTrigger("toch");

            if (!Cluck.isPlaying)
            {
                Cluck.Play();
            }

            Egg += CountEgg;
    }
}
