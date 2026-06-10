using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private float minSize = 0.5f;
    private float maxSize = 2f;
    private Rigidbody2D _rb;

    private float minSpeed = 50f;
    private float maxSpeed = 150f;

    public float maxSpinSpeed = 10f;


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

    // Update is called once per frame
    void Update()
    {
        
    }
}
