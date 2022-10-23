using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Transform ballTransform;
    public float speed;
    public Vector2 rightMax;
    public Vector2 leftMax;
    public AudioSource outOfBounds;
    public GameObject[] heartSprites;

    public UnityEvent callback;
    
    private Vector2 startPos;
    private bool clicked;
    private int hearts;
    
    void Start()
    {
        outOfBounds = GetComponent<AudioSource>();
        hearts = 5;
        foreach (var heart in heartSprites)
        {
            heart.gameObject.SetActive(true);
        }
        rb2D.simulated = false;
        clicked = false;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!clicked)
        {
            ballTransform.Translate(Vector2.right * (speed * Time.deltaTime));
            if (ballTransform.position.x >= rightMax.x || ballTransform.position.x <= leftMax.x)
            {
                speed *= -1;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            clicked = true;
            rb2D.simulated = true;
        }

        if (transform.position.y <= -6)
        {
            outOfBounds.Play();
            ResetBall();
        }
    }

    public void ResetBall()
    {
        var ball = transform;
        ball.position = startPos;
        ball.rotation = Quaternion.identity;
        rb2D.velocity = Vector2.zero;
        rb2D.angularVelocity = 0f;
        clicked = false;
        rb2D.simulated = false;
        ManageHealth();
        if (hearts > 0)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
            callback?.Invoke();
        }
    }

    public void ManageHealth()
    {
        if (hearts > 0)
        {
            heartSprites[hearts-1].gameObject.SetActive(false);
            hearts--;
        }
        else
        {
            hearts = 0;
            heartSprites[hearts].gameObject.SetActive(false);
        }
    }
}
