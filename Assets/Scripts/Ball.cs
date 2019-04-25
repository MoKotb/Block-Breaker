using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 12f;
    private Vector2 paddleToBallVector;
    private bool hasStarted = false;

    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    void Update()
    {
        if (!hasStarted) {
            LockBallToPaddle();
            LaunchBall();
        }
    }

    private void LockBallToPaddle() {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void LaunchBall() {
        if (Input.GetMouseButtonDown(0)) {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }
}
