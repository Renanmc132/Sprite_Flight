using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UIElements;

public class Obstacle : MonoBehaviour
{

    private float minSize = 0.5f;
    private float maxSize = 2f;
    private Rigidbody2D _rb;

    private float minSpeed = 50f;
    private float maxSpeed = 150f;

    private float updateMinSpeed = 150f;
    private float updateMaxSpeed = 300f;

    public float maxSpinSpeed = 10f;
    public GameObject collisionEffect;

    [Header("Sprites")]
    private int randomSprite;
    private int currentAnimation;
    private Animator _anim;
    private int asteroid1 = Animator.StringToHash("Asteroid1");
    private int asteroid2 = Animator.StringToHash("Asteroid2");
    private int asteroid3 = Animator.StringToHash("Asteroid3");
    private int asteroid4 = Animator.StringToHash("Asteroid4");

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 1);

        randomSprite = Random.Range(0, 4);

        float randomSpeed = Random.Range(minSpeed, maxSpeed) / randomSize;
        Vector2 randomDirection = Random.insideUnitCircle;

        float randomTorque = Random.Range(-maxSpinSpeed, maxSpinSpeed);
        _rb.AddTorque(randomTorque);

        _rb.AddForce(randomDirection * randomSpeed);
    }

    private void Update()
    {
        var animation = GetAnimation();

        if (animation == currentAnimation) return;
        _anim.CrossFade(animation, 0, 0);
        currentAnimation = animation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Border")
        {
            Vector2 randomDirection = Random.insideUnitCircle;
            float randomSpeed = Random.Range(updateMinSpeed, updateMaxSpeed);
            _rb.AddForce(randomDirection * randomSpeed);
        }

        Vector2 contactPoint = collision.GetContact(0).point;
        GameObject bounceEffect = Instantiate(collisionEffect, contactPoint, transform.rotation);
        Destroy(bounceEffect, 1f);
    }

    private int GetAnimation()
    {
        int currentSprite = asteroid1;

        if (randomSprite == 0) return asteroid1;
        if (randomSprite == 1) return asteroid2;
        if (randomSprite == 2) return asteroid3;
        if (randomSprite == 3) return asteroid4;

        return currentSprite;
    }




}
