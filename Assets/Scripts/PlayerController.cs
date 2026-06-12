using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private float elapsedTime = 0f;
    private float score = 0f;
    private float scoreMultiplier = 10f;

    private Rigidbody2D _rb;
    private float powerForce = 4f;
    private float maxSpeed = 5f;

    public UIDocument uiDocument;
    private Label scoreText;
    public GameObject rocketFlame;
    public GameObject explosionEffect;


    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
    }




    void Update()
    {
        Score();
        Move();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Instantiate(explosionEffect,transform.position,transform.rotation);
    }

    private void Move()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);

            Vector2 direction = (mousePos - transform.position).normalized;
            transform.up = direction;

            _rb.AddForce(powerForce * direction);
        }

        if (_rb.linearVelocity.magnitude > maxSpeed)
        {
            _rb.linearVelocity = _rb.linearVelocity.normalized * maxSpeed;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            rocketFlame.SetActive(true);
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            rocketFlame.SetActive(false);
        }
    }

    private void Score()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        scoreText.text = "Score: " + score;
    }

}
