using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EbanutiyStore : MonoBehaviour
{
    public GameObject[] purchasedObjectList;
    public GameObject[] purchaseButtons;
    private void Awake()
    {
        CheckBuying();
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        CheckBuying();
    }
    private void CheckBuying()
    {
            if (PlayerPrefs.HasKey("Purchase1"))
            {
            purchaseButtons[0].SetActive(false);
            purchasedObjectList[0].SetActive(true);
            }
        if (PlayerPrefs.HasKey("Purchase2"))
        {
            purchaseButtons[1].SetActive(false);
            purchasedObjectList[1].SetActive(true);
        }
        if (PlayerPrefs.HasKey("Purchase3"))
        {
            purchaseButtons[2].SetActive(false);
            purchasedObjectList[2].SetActive(true);
        }
        if (PlayerPrefs.HasKey("Purchase4"))
        {
            purchaseButtons[3].SetActive(false);
            purchasedObjectList[3].SetActive(true);
        }
    }
    public void Purchase1()
    {
        if (PlayerPrefs.GetInt("money") > 100)
        {
            PlayerPrefs.SetString("Purchase1", "true");
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 100);
            PlayerPrefs.Save();
            CheckBuying();
            UIController.instance.ShowMoney(PlayerPrefs.GetInt("money").ToString());
        }
    }
    public void Purchase2()
    {
        if (PlayerPrefs.GetInt("money") > 100)
        {
            PlayerPrefs.SetString("Purchase2", "true");
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 100);
            PlayerPrefs.Save();
            CheckBuying();
            UIController.instance.ShowMoney(PlayerPrefs.GetInt("money").ToString());
        }
    }
    public void Purchase3()
    {
        if (PlayerPrefs.GetInt("money") > 100)
        {
            PlayerPrefs.SetString("Purchase3", "true");
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 100);
            PlayerPrefs.Save();
            CheckBuying();
            UIController.instance.ShowMoney(PlayerPrefs.GetInt("money").ToString());
        }
    }
    public void Purchase4()
    {
        if (PlayerPrefs.GetInt("money") > 100)
        {
            PlayerPrefs.SetString("Purchase4", "true");
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 100);
            PlayerPrefs.Save();
            CheckBuying();
            UIController.instance.ShowMoney(PlayerPrefs.GetInt("money").ToString());
        }
    }
}
