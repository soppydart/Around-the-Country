using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Board : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI promptText;
    [SerializeField] GameObject promptObject;
    void Start()
    {

    }

    void Update()
    {

    }
    public void DisplayPrompt()
    {
        promptObject.gameObject.SetActive(true);
    }
}
