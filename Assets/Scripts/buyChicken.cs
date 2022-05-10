using UnityEngine;
using UnityEngine.UI;

public class buyChicken : MonoBehaviour
{
    public GameObject Chicken;

    public Sprite MySprite;

    public int CountEgg = 1;
    public int Cost = 1;
    public int Lvl = 0;
    
    public bool canBuy = true;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Buying);
    }

    private void Buying()
    {
        if ((canBuy) && (Chicken.GetComponent<chicken>().Money >= Cost))
        {
            Chicken.GetComponent<chicken>().Money -= Cost;
            Chicken.GetComponent<SpriteRenderer>().sprite = MySprite;
            Chicken.GetComponent<chicken>().CountEgg = CountEgg;
            Chicken.GetComponent<chicken>().Lvl = Lvl;

            canBuy = false;
        }
    }
}
