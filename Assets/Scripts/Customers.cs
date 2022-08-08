using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour
{
    GameController gameController;
    Player player;
    Finances finances;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        player = FindObjectOfType<Player>();
        finances = FindObjectOfType<Finances>();
    }
    public void Yes()
    {
        gameController.Players[gameController.CompanyBuyerIndex].GetComponent<Player>().hasSoldCompany = true;
        gameController.Players[gameController.CompanyBuyerIndex].GetComponent<Player>().money +=
        finances.CompanyBuyerPrices[gameController.CompanyBuyerIndex];
        gameController.CompanyBuyerIndex++;
    }
    public void No()
    {
        gameController.CompanyBuyerIndex++;
    }
}
