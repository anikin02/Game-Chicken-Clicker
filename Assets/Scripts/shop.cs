using UnityEngine;

public class shop : MonoBehaviour
{
    public bool isOpened = false;

    private void Start()
    {
        GetComponent<Canvas>().enabled = isOpened;
    }

    public void showHideShop()
    {
	    isOpened = !isOpened;
	    GetComponent<Canvas>().enabled = isOpened;
    }
}
