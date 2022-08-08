using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] public Transform[] waypoints;
    [SerializeField] public float moveSpeed = 1f;
    [SerializeField] public int waypointIndex = 0;
    public bool moveAllowed = false;
    [SerializeField] TextMeshProUGUI playerMoney;
    public int money = 10000;
    public bool isInJail = false;
    public bool hasSoldCompany = false;

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;

    }
    void Update()
    {
        if (moveAllowed && !FindObjectOfType<GameController>().gameOver)
            Move();
        playerMoney.text = "Player: " + money.ToString();
    }

    void Move()
    {
        if (isInJail)
        {
            isInJail = false;
            return;
        }
        //Debug.Log("HIj " + waypointIndex);
        //if (!FindObjectOfType<GameController>().shittyBug)
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex % 24].transform.position, moveSpeed * Time.deltaTime);
        //else
        //   transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex - 24].transform.position, moveSpeed * Time.deltaTime);
        if (transform.position == waypoints[waypointIndex % 24].transform.position)
            waypointIndex++;
    }
}
