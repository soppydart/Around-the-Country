using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PurchasePrompt : MonoBehaviour
{
    [SerializeField] GameObject GamePromptCanvas;
    [SerializeField] GameObject purchasePrompt;
    [SerializeField] GameObject lossPrompt;
    [SerializeField] TextMeshProUGUI lossPromptText;
    GameController gameController;
    Finances finances;
    Player player;
    int playerIndex;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        finances = FindObjectOfType<Finances>();
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        playerIndex = FindObjectOfType<GameController>().playerIndex;
    }
    public void Yes()
    {
        int index = FindObjectOfType<GameController>().index;
        gameController.Players[playerIndex].GetComponent<Player>().money -= finances.prices[index];
        finances.ownedCard[index] = playerIndex;
        //gameController.ChangePlayerMoney(finances.prices[index]);
        //purchasePrompt.SetActive(false);
    }
    public void No()
    {
        int index = FindObjectOfType<GameController>().index;
        //gameController.ChangePlayerMoney(-finances.loss[index]);
        // Debug.Log(index);
        // Debug.Log(finances.loss[index]);
        gameController.Players[playerIndex].GetComponent<Player>().money -= finances.loss[index];
        lossPromptText.text = FindObjectOfType<Finances>().lossMessage[index];
    }
}
