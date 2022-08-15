using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinemachineVirtualCamera : MonoBehaviour
{
    [SerializeField] Transform[] lookAtTarget;
    [SerializeField] Transform diceObject;
    [SerializeField] Animator myAnimator;
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
        FollowCamera();

        if ((gameController.playerIsMoving || (gameController.isAnyPromptActive && !gameController.CompaniesAllottmentCanvas.activeInHierarchy)) && !gameController.CompanyBuyersCanvas.activeInHierarchy)
            myAnimator.SetBool("isMoving", true);
        else
            myAnimator.SetBool("isMoving", false);
    }
    void FollowCamera()
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
}