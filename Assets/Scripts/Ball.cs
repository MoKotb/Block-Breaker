using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    Paddle paddle;
    [SerializeField]
    float xPush = 2f;
    [SerializeField]
    float yPush = 12f;
    [SerializeField]
    AudioClip[] ballSounds;
    [SerializeField]
    float randomFatcor = 0.2f;

    private Vector2 paddleToBallVector;
    private bool hasStarted = false;
    private AudioSource audioSource;
    private Rigidbody2D rigidbody2;

    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBall();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rigidbody2.velocity = new Vector2(xPush, yPush);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFatcor), Random.Range(0f, randomFatcor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0,ballSounds.Length)];
            audioSource.PlayOneShot(clip);
            rigidbody2.velocity += velocityTweak;
        }
    }
}