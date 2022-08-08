using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePrompt : MonoBehaviour
{
    [SerializeField] GameObject Prompt;
    public void Ok()
    {
        Prompt.gameObject.SetActive(false);
    }
    public void DisplayPrompt()
    {
        GameObject.Find("Prompt").SetActive(true);
    }
}
