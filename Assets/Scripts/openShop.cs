using UnityEngine;

public class openShop : MonoBehaviour
{   
    public Canvas Shop;
    public GameObject Chicken;

    private void OnMouseDown()
    {
        Shop.GetComponent<shop>().showHideShop();
        Chicken.GetComponent<chicken>().ChickenEnabled = !Chicken.GetComponent<chicken>().ChickenEnabled;
    }
}
