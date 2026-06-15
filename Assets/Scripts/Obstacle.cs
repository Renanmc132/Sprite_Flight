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


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 1);


        float randomSpeed = Random.Range(minSpeed, maxSpeed) / randomSize;
        Vector2 randomDirection = Random.insideUnitCircle;

        float randomTorque = Random.Range(-maxSpinSpeed, maxSpinSpeed);
        _rb.AddTorque(randomTorque);

        _rb.AddForce(randomDirection * randomSpeed);
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
        GameObject bounceEffect = Instantiate(collisionEffect, transform.position, transform.rotation);
        Destroy(bounceEffect, 1f);
    }

    




}
