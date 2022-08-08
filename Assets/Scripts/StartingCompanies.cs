using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartingCompanies : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerName;
    [SerializeField] GameObject Prompts;
    //GameController gameController;
    int playerIndex = 0;
    [SerializeField] public static int[] startingCompanies = new int[4];
    // void Awake()
    // {
    //     DontDestroyOnLoad(GameObject.Find("Starting Companies Menu"));
    // }
    void Start()
    {
        //gameController = FindObjectOfType<GameController>();
    }
    void Update()
    {
        //  playerName.text = "Player " + (playerIndex + 1) + " select you company.";
        if (playerIndex == 4)
        {
            Prompts.gameObject.SetActive(false);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3 - i; j++)
                {
                    if (startingCompanies[j] > startingCompanies[j + 1])
                    {
                        string temp = Usernames.playerNames[j];
                        Usernames.playerNames[j] = Usernames.playerNames[j + 1];
                        Usernames.playerNames[j + 1] = temp;


                    }
                }
            }
            SceneManager.LoadScene("Scene1");
        }
        else
        {
            //playerName.text = Usernames.playerNames[playerIndex] + " select your company.";
        }
    }
    public void Coaching()
    {
        startingCompanies[playerIndex] = 0;
        GameObject.Find("Coaching").GetComponent<Button>().interactable = false;
        playerIndex++;
    }
    public void FlourMill()
    {
        startingCompanies[playerIndex] = 1;
        GameObject.Find("Flour Mill").GetComponent<Button>().interactable = false;
        playerIndex++;
    }
    public void Scooba()
    {
        startingCompanies[playerIndex] = 2;
        GameObject.Find("Scooba").GetComponent<Button>().interactable = false;
        playerIndex++;
    }
    public void Recycle()
    {
        startingCompanies[playerIndex] = 3;
        GameObject.Find("Recycle").GetComponent<Button>().interactable = false;
        playerIndex++;
    }
}
