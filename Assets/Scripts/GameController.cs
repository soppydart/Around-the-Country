using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
public class GameController : MonoBehaviour
{
    [SerializeField] GameObject GamePromptCanvas;
    [SerializeField] GameObject lossPrompt;
    [SerializeField] TextMeshProUGUI lossPromptText;
    [SerializeField] GameObject purchasePrompt;
    [SerializeField] TextMeshProUGUI purchasePromptText;
    [SerializeField] GameObject mysteryPrompt;
    [SerializeField] TextMeshProUGUI mysteryPromptText;
    [SerializeField] GameObject rentPrompt;
    [SerializeField] TextMeshProUGUI rentPromptText;
    [SerializeField] GameObject jailPrompt;
    [SerializeField] TextMeshProUGUI jailPromptText;
    [SerializeField] public GameObject[] Players;
    [SerializeField] GameObject whoWinsText;
    [SerializeField] GameObject Jail;
    [SerializeField] GameObject StartingCompaniesCanvas;
    [SerializeField] GameObject StartingCompaniesPrompt;
    [SerializeField] TextMeshProUGUI[] StartingCompaniesText;
    [SerializeField] TextMeshProUGUI[] PlayerRevenueMoney;
    [SerializeField] public GameObject PauseMenuCanvas;
    [SerializeField] public GameObject CompanyBuyersCanvas;
    [SerializeField] public GameObject[] CompanyBuyersPrompts;
    [SerializeField] TextMeshProUGUI[] CompanyBuyersText;
    [SerializeField] GameObject PlayerTurnCanvas;
    [SerializeField] TextMeshProUGUI PlayerTurn;
    [SerializeField] Slider ProgressBar;
    [SerializeField] GameObject UsernameCanvas;
    [SerializeField] TextMeshProUGUI playerNumber;
    [SerializeField] TMP_InputField nameEntered;
    bool areUsernamesEntered = false;
    //This the array of usernames entered

    //This is the canvas for the starting companies
    [SerializeField] public GameObject CompaniesAllottmentCanvas;
    [SerializeField] TextMeshProUGUI playerName;
    public string[] usernames = new string[4];

    //This is for displaying the Player Scores
    [SerializeField] GameObject ScoreCanvas;
    [SerializeField] TextMeshProUGUI[] PlayerScores;
    //This is for the end game screen
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] TextMeshProUGUI winner;

    int round;
    public int currentPlayerIndex = 0;
    public bool isPaused = false;
    public int index = 0;
    public int playerIndex = 0;
    public int diceSideThrown = 0;
    [SerializeField] public int[] playerStartWaypoint;
    public bool gameOver = false;
    public bool isAnyPromptActive = false;
    public int TotalNumberOfTurns = 0;
    public int gameHasStarted = -1;
    Finances finances;
    Dice dice;
    //bool isRoundOverNow = false;
    int[] arr = { 3, 0, 2, 1 };
    int highestMoneyIndex = 0;

    //This is for the canvas that shows the current round number
    [SerializeField] GameObject RoundsCanvas;
    [SerializeField] TextMeshProUGUI RoundNumber;

    public bool playerIsMoving = false;
    void Start()
    {
        for (int i = 0; i < Players.Length; i++)
            Players[i].GetComponent<Player>().moveAllowed = false;
        whoWinsText.gameObject.SetActive(false);
        Players[0].GetComponent<Player>().moveAllowed = true;
        TotalNumberOfTurns = Players.Length * 10;
        round = 0;
        finances = FindObjectOfType<Finances>();
        dice = FindObjectOfType<Dice>();
        ProgressBar.value = 0;
        isAnyPromptActive = true;
    }
    bool flag = true;
    bool flagnew = true;
    void Update()
    {
        UpdateRoundNumber();
        if (playerIsMoving)
            GetComponent<AudioSource>().Play();
        for (int i = 0; i < 4; i++)
        {
            if (Players[i].GetComponent<Player>().money > Players[highestMoneyIndex].GetComponent<Player>().money)
                highestMoneyIndex = i;
        }
        DisplayScores();
        if (usernamesEntered <= 3)
            playerNumber.text = "Player " + (usernamesEntered + 1) + " enter your username";
        else
        {
            UsernameCanvas.gameObject.SetActive(false);
            CompaniesAllottmentCanvas.SetActive(true);
            areUsernamesEntered = true;
        }
        if (companiesAlotted <= 3)
        {
            playerName.text = usernames[companiesAlotted] + " select your company";
        }
        else
        {
            CompaniesAllottmentCanvas.gameObject.SetActive(false);
            if (flag)
            {
                isAnyPromptActive = false;
                flag = false;
                GameObject.Find("A Melancholic Existence").SetActive(false);

            }
            Sort();
            if (flagnew)
            {
                PlayerTurn.text = usernames[0] + "'s Turn";
                flagnew = false;
            }
            PlayerTurnCanvas.gameObject.SetActive(true);
            ScoreCanvas.gameObject.SetActive(true);
            RoundsCanvas.gameObject.SetActive(true);
        }
        for (int i = 0; i < Players.Length; i++)
        {
            if (Players[i].GetComponent<Player>().waypointIndex > playerStartWaypoint[i] + diceSideThrown)
            {
                Players[i].GetComponent<Player>().moveAllowed = false;
                if (Players[i].GetComponent<Player>().waypointIndex != 24)
                    playerStartWaypoint[i] = Players[i].GetComponent<Player>().waypointIndex % 24 - 1;
                else
                    playerStartWaypoint[i] = 23;

                if (playerStartWaypoint[i] < 10)
                    Players[i].GetComponent<Player>().waypointIndex %= 24;
                InteractWithBoard(i);
                if (Players[(i + 1) % 4].GetComponent<Player>().isInJail)
                {
                    Players[(i + 1) % 4].GetComponent<Player>().isInJail = false;
                    GamePromptCanvas.gameObject.SetActive(true);
                    jailPrompt.gameObject.SetActive(true);
                    jailPromptText.text = usernames[dice.whosTurn] + " got out of Jail.";
                    dice.whosTurn = (dice.whosTurn + 1) % 4;
                    TotalNumberOfTurns--;
                }
            }
        }
        PauseGame();
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2f);
        GameOverCanvas.gameObject.SetActive(true);
        winner.text = usernames[highestMoneyIndex] + " has won the game!!";
    }
    int roundNumber = 1;
    void UpdateRoundNumber()
    {
        RoundNumber.text = "Round " + roundNumber.ToString();
    }
    public void IncreaseRoundNumber()
    {
        if (roundNumber < 10)
            roundNumber++;
    }
    public void MovePlayer(int PlayerToMove)
    {
        playerIndex = PlayerToMove;
        if (!Players[PlayerToMove].GetComponent<Player>().isInJail)
            Players[PlayerToMove].GetComponent<Player>().moveAllowed = true;
        else
            Players[PlayerToMove].GetComponent<Player>().isInJail = false;
    }
    void InteractWithBoard(int i)
    {
        index = playerStartWaypoint[i];
        if (Players[i].transform.position == Players[i].GetComponent<Player>().waypoints[playerStartWaypoint[i]].transform.position)
        {
            currentPlayerIndex = i;
            if (index % 6 != 0)
            {
                gameHasStarted++;
                isAnyPromptActive = true;
                if (index == 16)
                {
                    GamePromptCanvas.gameObject.SetActive(true);
                    lossPrompt.gameObject.SetActive(true);
                    lossPromptText.text = FindObjectOfType<Finances>().lossMessage[index];
                    Players[i].GetComponent<Player>().money -= finances.loss[index];
                }
                else if (index == 3 || index == 9 || index == 14 || index == 21)
                {
                    GamePromptCanvas.gameObject.SetActive(true);
                    mysteryPrompt.gameObject.SetActive(true);
                    int randomNumber = UnityEngine.Random.Range(0, 5);
                    mysteryPromptText.text = FindObjectOfType<Finances>().mysteryCards[randomNumber];
                    Players[i].GetComponent<Player>().money -= finances.mysteryLoss[randomNumber];
                }
                else if (index == 11)
                {
                    Players[i].GetComponent<Player>().isInJail = true;
                    GamePromptCanvas.gameObject.SetActive(true);
                    lossPrompt.gameObject.SetActive(true);
                    lossPromptText.text = FindObjectOfType<Finances>().lossMessage[index];
                    Players[i].GetComponent<Player>().money -= finances.loss[index];
                    Players[i].GetComponent<Player>().moveAllowed = false;
                }
                else if (finances.ownedCard[index] == -1)
                {
                    GamePromptCanvas.gameObject.SetActive(true);
                    purchasePrompt.gameObject.SetActive(true);
                    purchasePromptText.text = "You have arrived at " + finances.cardNames[index] +
                    ". Would you like to purchase it for Rs. " + finances.prices[index] + "?";
                }
                else
                {
                    if (finances.ownedCard[index] != i)
                    {
                        GamePromptCanvas.gameObject.SetActive(true);
                        rentPrompt.gameObject.SetActive(true);
                        rentPromptText.text = "You landed on a purchased property. You must pay Rs. " + ((int)(finances.prices[index] * 0.1)).
                        ToString() + " to " + usernames[finances.ownedCard[index]];
                        Players[finances.ownedCard[index]].GetComponent<Player>().money += (int)(finances.prices[index] * 0.1);
                    }
                    else
                    {
                        GamePromptCanvas.gameObject.SetActive(true);
                        rentPrompt.gameObject.SetActive(true);
                        rentPromptText.text = "You landed on a property you had purchased previously. ";
                    }
                }
            }
            else
            if (gameHasStarted != -1)
                RoundOverPromptAllowed();
            playerIsMoving = false;
        }
    }
    void ShowStartingCompaniesScore(int i)
    {
        PlayerTurn.text = usernames[dice.whosTurn] + "'s turn";
        if (i == 0)
        {
            round++;
            isAnyPromptActive = true;
            StartingCompaniesCanvas.SetActive(true);
            StartingCompaniesPrompt.SetActive(true);
            for (int j = 0; j < Players.Length; j++)
            {
                if (!Players[j].GetComponent<Player>().hasSoldCompany)
                {
                    string prefix = (finances.startingCompaniesIncome[j, round - 1] > 0) ? "+" : "-";
                    PlayerRevenueMoney[j].text = usernames[j] + " : " + prefix + "Rs. " + (Mathf.Abs((int)(finances.startingCompaniesIncome[j, round - 1] * finances.startingCompaniesTotalValue[j] / 100.0))).ToString();
                    Players[j].GetComponent<Player>().money += (int)(finances.startingCompaniesIncome[j, round - 1] * finances.startingCompaniesTotalValue[j] / 100.0);
                    finances.startingCompaniesTotalValue[j] += finances.startingCompaniesIncome[j, round - 1] * finances.startingCompaniesTotalValue[j] / 100.0;
                    StartingCompaniesText[j].text = finances.startingCompanies[j] + " : " + prefix + finances.startingCompaniesIncome[j, round - 1].ToString() + "%";
                }
                else
                {
                    PlayerRevenueMoney[j].text = "Company Sold!";
                    StartingCompaniesText[j].text = finances.startingCompanies[j];
                }
            }
        }
    }
    public void RoundOverPromptAllowed()
    {
        PlayerTurn.text = usernames[currentPlayerIndex] + "'s turn";
        ProgressBar.value = 40 - TotalNumberOfTurns;
        isAnyPromptActive = false;
        ShowStartingCompaniesScore(dice.whosTurn);
    }
    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            PauseMenuCanvas.gameObject.SetActive(isPaused);
        }
    }
    public int CompanyBuyerIndex = 0;
    void CompanyBuyers()
    {
        isAnyPromptActive = true;
        CompanyBuyersCanvas.gameObject.SetActive(true);
        for (int i = 0; i < Players.Length; i++)
        {
            CompanyBuyersText[i].text = usernames[i] + ", " + finances.CompanyBuyerName[i] + " wants to buy your company for Rs. " +
            finances.CompanyBuyerPrices[i] + ". Would you like to sell your company?";
        }
    }
    public void ClosePrompt()
    {
        isAnyPromptActive = false;
    }
    public void BuyingCompany()
    {
        if (round == 3)
            CompanyBuyers();
    }
    //This is to show the End Screen
    public void EndScreen()
    {
        if (TotalNumberOfTurns == 0)
        {
            gameOver = true;
            StartCoroutine("EndGame");
        }
    }
    int usernamesEntered = 0;
    public void UsernameSubmit()
    {
        usernames[usernamesEntered] = nameEntered.text.ToString();
        usernamesEntered++;
        nameEntered.text = "";
    }
    public void UsernameClear()
    {
        nameEntered.text = "";
    }

    //This is the portion for allotting companies to the players
    public int[] AlottedCompaniesIndex = new int[4];
    int companiesAlotted = 0;
    public void Coaching()
    {
        Players[companiesAlotted].GetComponent<Player>().money -= 4500;
        AlottedCompaniesIndex[companiesAlotted++] = 0;
        GameObject.Find("Coaching").GetComponent<Button>().interactable = false;
    }
    public void FlourMill()
    {
        Players[companiesAlotted].GetComponent<Player>().money -= 3500;
        AlottedCompaniesIndex[companiesAlotted++] = 1;
        GameObject.Find("Flour Mill").GetComponent<Button>().interactable = false;
    }
    public void Scooba()
    {
        Players[companiesAlotted].GetComponent<Player>().money -= 4000;
        AlottedCompaniesIndex[companiesAlotted++] = 2;
        GameObject.Find("Scooba").GetComponent<Button>().interactable = false;
    }
    public void Recycle()
    {
        Players[companiesAlotted].GetComponent<Player>().money -= 5500;
        AlottedCompaniesIndex[companiesAlotted++] = 3;
        GameObject.Find("Recycle").GetComponent<Button>().interactable = false;
    }
    void Sort()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3 - i; j++)
            {
                if (AlottedCompaniesIndex[j] > AlottedCompaniesIndex[j + 1])
                {
                    int temp = AlottedCompaniesIndex[j + 1];
                    AlottedCompaniesIndex[j + 1] = AlottedCompaniesIndex[j];
                    AlottedCompaniesIndex[j] = temp;
                    string temp2 = usernames[j + 1];
                    usernames[j + 1] = usernames[j];
                    usernames[j] = temp2;
                }
            }
        }
    }

    //This will display the scores on the screen
    void DisplayScores()
    {
        if (areUsernamesEntered)
        {
            PlayerScores[0].text = usernames[0] + " : " + Players[0].GetComponent<Player>().money.ToString();
            PlayerScores[1].text = usernames[1] + " : " + Players[1].GetComponent<Player>().money.ToString();
            PlayerScores[2].text = usernames[2] + " : " + Players[2].GetComponent<Player>().money.ToString();
            PlayerScores[3].text = usernames[3] + " : " + Players[3].GetComponent<Player>().money.ToString();
        }
    }

    //Functions for the Game Over screen
    public void Restart()
    {
        GameOverCanvas.gameObject.SetActive(false);
        SceneManager.LoadScene("Scene1");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}