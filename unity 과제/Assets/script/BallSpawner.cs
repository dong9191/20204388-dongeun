using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Header("공 오브젝트 설정")]
    public GameObject ballPrefab;   

    [Header("스폰 속도 및 주기")]
    public float spawnRate = 0.5f;  

    [Header("스폰 범위 설정 (미로 크기에 맞게 조절)")]
    public float spawnRangeX = 15f; 
    public float spawnRangeZ = 15f; 

 
    [Header(" 공이 떨어지는 가속도")]
    public float dropSpeed = 50f;   

    void Start()
    {
       
        InvokeRepeating("SpawnBall", 0f, spawnRate);
    }

    void SpawnBall()
    {
        if (ballPrefab == null) return;

       
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        float randomZ = Random.Range(-spawnRangeZ, spawnRangeZ);

       
        Vector3 spawnPos = new Vector3(
            transform.position.x + randomX,
            transform.position.y,
            transform.position.z + randomZ
        );

        GameObject clonedBall = Instantiate(ballPrefab, spawnPos, Quaternion.identity);

        Rigidbody ballRb = clonedBall.GetComponent<Rigidbody>();
        if (ballRb != null)
        {
            ballRb.linearVelocity = Vector3.down * dropSpeed;
        }
    }

   
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnRangeX * 2, 1f, spawnRangeZ * 2));
    }
}