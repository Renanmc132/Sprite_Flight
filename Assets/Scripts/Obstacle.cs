using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private float minSize = 0.5f;
    private float maxSize = 0.5f;
    private Rigidbody2D _rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float size = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(size, size, 1);

        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(Vector2.right * 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
