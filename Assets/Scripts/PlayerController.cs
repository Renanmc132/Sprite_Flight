using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("Player Variables")]
    public static bool playerDeath = false;
    private int playerLife = 4;
    private float waitTime = .2f;
    private float nextTime = 0;

    [Header("Sprites")]
    private int currentAnimation;
    private Animator _anim;
    private int baseShip = Animator.StringToHash("BaseShip");
    private int damage1Ship = Animator.StringToHash("1DamageShip");
    private int damage2Ship = Animator.StringToHash("2DamageShip");
    private int damage3Ship = Animator.StringToHash("3DamageShip");

    [Header("Movement")]
    private Rigidbody2D _rb;
    private float powerForce = 4f;
    private float maxSpeed = 5f;

    [Header("GameObjects")]
    public GameObject rocketFlame;
    public GameObject explosionEffect;
    public GameObject rocketEffect;
    public GameObject borders;

    void Awake()
    {
        _anim = GetComponent<Animator>();
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

        var animation = GetAnimation();

        if (animation == currentAnimation) return;
        _anim.CrossFade(animation, 0, 0);
        currentAnimation = animation;

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
        playerLife--;
        if(playerLife <= 0)
        {
            Destroy(gameObject);
            Destroy(borders);
            playerDeath = true;
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }
        
    }

    private int GetAnimation()
    {
        int currentSprite = baseShip;

        if (playerLife == 4) return currentSprite = baseShip;
        if (playerLife == 3) return currentSprite = damage1Ship;
        if (playerLife == 2) return currentSprite = damage2Ship;
        if (playerLife == 1) return currentSprite = damage3Ship;

        return currentSprite;
    }

}
