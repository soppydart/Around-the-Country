using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Usernames : MonoBehaviour
{
    public static string[] playerNames = new string[4];
    [SerializeField] TMP_InputField[] namesEntered;
    [SerializeField] GameObject[] UsernamePrompts;
    int index = 0;
    [SerializeField] TextMeshProUGUI[] usernames;
    public void Ok()
    {
        playerNames[index] = namesEntered[index].text.ToString();
        index++;
    }
    void Update()
    {
        if (index < 4)
            usernames[index].text = "Player number " + (index + 1) + " enter your username";
    }
    public void Finish()
    {
        SceneManager.LoadScene("StartingCompanies");
    }
    // void EnterUsernames()
    // {
    //     for (int i = 0; i < 4; i++)
    //     {

    //     }
    // } StartingCompanies.startingCompanies[Usernames.playerNames[i]];
}
