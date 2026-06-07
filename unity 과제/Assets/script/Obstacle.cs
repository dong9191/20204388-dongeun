using UnityEngine;

public enum ObstacleType { PingPong, Rotate }

public class Obstacle : MonoBehaviour
{
    [Header("--- 장애물 타입 설정 ---")]
    public ObstacleType type; 

    [Header("--- 이동/회전 속도 ---")]
    public float speed = 3f;

    [Header("--- 좌우/위아래 이동 거리 (PingPong용) ---")]
    public float moveDistance = 3f;

    private Vector3 startPosition;

    void Start()
    {
        
        startPosition = transform.position;
    }

    void Update()
    {
        if (type == ObstacleType.PingPong)
        {
            float movement = Mathf.PingPong(Time.time * speed, moveDistance);

           
            transform.position = new Vector3(startPosition.x + movement, transform.position.y, transform.position.z);
        }
        else if (type == ObstacleType.Rotate)
        {
            
            transform.Rotate(Vector3.up * speed * Time.deltaTime * 50f);
        }
    }
}