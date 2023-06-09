using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayManager : MonoBehaviour
{
    [SerializeField] BallController ballController;
    [SerializeField] CameraController camController;
    [SerializeField] GameObject goalWindow;
    [SerializeField] TMP_Text goalText;
    [SerializeField] TMP_Text shootCountText;

    bool isBallOutside;
    bool isBallTeleporting;
    bool isGoal;
    Vector3 lastBallPosition;

    public UnityEvent onBallGoal = new UnityEvent();

    private void OnEnable()
    {
        ballController.onBallShooted.AddListener(UpdateShootCount);
    }

    private void OnDisable()
    {
        ballController.onBallShooted.RemoveListener(UpdateShootCount);
    }

    private void Update()
    {
        if (ballController.ShootingMode)
        {
            lastBallPosition = ballController.transform.position;
        }

        var inputActive = Input.GetMouseButton(0)
            && ballController.IsMove() == false
            && ballController.ShootingMode == false
            && isBallOutside == false;

        camController.SetInputActive(inputActive);
    }

    public void OnBallGoalEnter()
    {
        isGoal = true;
        ballController.enabled = false;

        //window popup
        onBallGoal.Invoke();
        goalWindow.gameObject.SetActive(true);
        goalText.text = "Goal!!!\n" + "Shoot Count: " + ballController.ShootCount;
    }

    public void OnBallOutside()
    {
        if (isGoal)
        {
            return;
        }

        if (isBallTeleporting == false)
        {
            Invoke("TeleportBallLastPosition", 3);
        }
        ballController.enabled = false;
        isBallOutside = true;
        isBallTeleporting = true;
    }

    public void TeleportBallLastPosition()
    {
        TeleportBall(lastBallPosition);
    }

    public void TeleportBall(Vector3 targetPosition)
    {
        var rb = ballController.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        ballController.transform.position = lastBallPosition;
        rb.isKinematic = false;

        ballController.enabled = true;
        isBallOutside = false;
        isBallTeleporting = false;
    }

    public void UpdateShootCount(int shootCount)
    {
        shootCountText.text = shootCount.ToString();
    }

}
