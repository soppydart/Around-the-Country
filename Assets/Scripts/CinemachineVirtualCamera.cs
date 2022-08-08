using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinemachineVirtualCamera : MonoBehaviour
{
    [SerializeField] Transform[] lookAtTarget;
    [SerializeField] Transform diceObject;
    Dice dice;
    GameController gameController;
    Cinemachine.CinemachineVirtualCamera virtualCam;
    void Awake()
    {
        virtualCam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }
    void Start()
    {
        dice = FindObjectOfType<Dice>();
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        //if (dice.whosTurn > 0)

        if ((gameController.playerIsMoving || (gameController.isAnyPromptActive && !gameController.CompaniesAllottmentCanvas.activeInHierarchy)) && !gameController.CompanyBuyersCanvas.activeInHierarchy)
        {
            if (dice.whosTurn > 0)
            {
                virtualCam.LookAt = gameController.Players[dice.whosTurn - 1].transform;
                virtualCam.Follow = gameController.Players[dice.whosTurn - 1].transform;
            }
            else
            {
                virtualCam.LookAt = gameController.Players[3].transform;
                virtualCam.Follow = gameController.Players[3].transform;
            }
        }
        else
        {
            virtualCam.LookAt = diceObject;
            virtualCam.Follow = diceObject;
        }
    }
}
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinemachineVirtualCamera : MonoBehaviour
{
    [SerializeField] Transform[] lookAtTarget;
    Dice dice;
    GameController gameController;
    Cinemachine.CinemachineVirtualCamera virtualCam;
    void Awake()
    {
        virtualCam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }
    void Start()
    {
        dice = FindObjectOfType<Dice>();
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        if (gameController.playerIsMoving)
        {
            virtualCam.LookAt = lookAtTarget[dice.whosTurn].transform;
            virtualCam.Follow = lookAtTarget[dice.whosTurn].transform;
        }
    }
}

*/