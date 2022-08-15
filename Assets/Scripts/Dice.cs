using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class Dice : MonoBehaviour
{
    [SerializeField] Sprite[] diceSides;
    [SerializeField] float diceRollTime = 1f;
    [SerializeField] GameObject jailPrompt;
    [SerializeField] TextMeshProUGUI jailPromptText;
    [SerializeField] GameObject GamePromptCanvas;
    public int whosTurn = 0;
    SpriteRenderer spriteRenderer;
    public bool rollAllowed = true;
    GameController gameController;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameController = FindObjectOfType<GameController>();
    }
    void OnMouseDown()
    {
        if (rollAllowed && !gameController.isAnyPromptActive && !gameController.isPaused && !gameController.playerIsMoving && !gameController.gameOver)
            StartCoroutine("RollDice");
    }
    IEnumerator RollDice()
    {

        rollAllowed = false;
        System.Random rd = new System.Random();
        int randomDiceSide = 0;
        for (int i = 0; i < 20; i++)
        {
            randomDiceSide = rd.Next(0, 6);
            spriteRenderer.sprite = diceSides[randomDiceSide];
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(diceRollTime / 20.0f);
        }
        gameController.diceSideThrown = randomDiceSide + 1;
        gameController.Players[whosTurn].GetComponent<Player>().diceSide = randomDiceSide + 1;
        gameController.MovePlayer(whosTurn);
        gameController.playerIsMoving = true;
        whosTurn = (whosTurn + 1) % 4;
        FindObjectOfType<GameController>().TotalNumberOfTurns--;
        rollAllowed = true;
    }
}
