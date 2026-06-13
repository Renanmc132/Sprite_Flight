using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    

    [Header("Movement")]
    private Rigidbody2D _rb;
    private float powerForce = 4f;
    private float maxSpeed = 5f;
    private float waitTime = .2f;
    private float nextTime = 0;
    public static bool playerDeath = false;

    [Header("GameObjects")]
    public GameObject rocketFlame;
    public GameObject explosionEffect;
    public GameObject rocketEffect;
    public GameObject borders;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        playerDeath = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= nextTime)
            {
                GameObject _rocketEffect = Instantiate(rocketEffect, transform.position, transform.rotation);
                Destroy(_rocketEffect, 1f);

                nextTime = Time.time + waitTime;
            }
        }
    }

    void Update()
    {
        Move();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Destroy(borders);
        playerDeath = true;
        Instantiate(explosionEffect, transform.position, transform.rotation);
        
    }



}
