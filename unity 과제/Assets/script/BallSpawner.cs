using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Header("공 오브젝트 설정")]
    public GameObject ballPrefab;   // 하늘에서 복제되어 떨어질 공 원본(프리팹)

    [Header("스폰 속도 및 주기")]
    public float spawnRate = 0.5f;  // 💡 몇 초마다 공을 떨어뜨릴지 (0.5초마다 마구 쏟아짐)

    [Header("스폰 범위 설정 (미로 크기에 맞게 조절)")]
    public float spawnRangeX = 15f; // 가로(X축) 생성 범위
    public float spawnRangeZ = 15f; // 세로(Z축) 생성 범위

 
    [Header("🔥 공이 떨어지는 가속도")]
    public float dropSpeed = 50f;   // 유니티 인스펙터 창에서 이 숫자를 조절해 보세요!

    void Start()
    {
        // 게임이 시작되면 spawnRate 초마다 SpawnBall 함수를 무한 반복 실행합니다.
        InvokeRepeating("SpawnBall", 0f, spawnRate);
    }

    void SpawnBall()
    {
        if (ballPrefab == null) return;

        // 이 스포너 매니저의 위치를 중심으로 랜덤한 X, Z 좌표를 계산합니다.
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        float randomZ = Random.Range(-spawnRangeZ, spawnRangeZ);

        // 하늘 위(Y축은 고정)에서 무작위 위치 설정
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

    // 유니티 에디터 화면(Scene)에서 공이 떨어지는 범위를 하늘색 박스로 보여주는 편리한 기능
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnRangeX * 2, 1f, spawnRangeZ * 2));
    }
}