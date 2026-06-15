using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    int nextSpawnScore = 100;
    public GameObject obstaclePrefab;

    void Start()
    {
        
    }

    private void RandomSpawn()
    {
        if (UIFunction.score >= nextSpawnScore)
        {
            Vector2 randPos = new Vector2(
                Random.Range(0, 11),
                Random.Range(0, 6)
            );

            nextSpawnScore += 100;
            Instantiate(obstaclePrefab, randPos, Quaternion.identity);

        }
    }

    private void Update()
    {
        RandomSpawn();
    }
}
