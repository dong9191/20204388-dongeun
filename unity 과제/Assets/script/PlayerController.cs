using UnityEngine; // 

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 6.0f;

    private Vector3 startPosition;
    private Rigidbody rb; // 
    private bool isGrounded;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>(); // 
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(h, 0, v).normalized;
        transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);

        if (moveDir != Vector3.zero) transform.forward = moveDir;

        // 스페이스바 점프
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
  
    private void OnCollisionEnter(Collision collision)
    {
        // 1. 오브젝트 이름으로 바닥 체크
        if (collision.gameObject.name.ToLower().Contains("ground"))
        {
            isGrounded = true;
        }

        // 2. 오브젝트 이름으로 돌 충돌 체크
        if (collision.gameObject.name.ToLower().Contains("stone"))
        {
            ResetToStart();
        }

     
        if (collision.gameObject.GetComponent<Obstacle>() != null)
        {
            Debug.Log("💥 방해물에 부딪혔습니다! 처음으로 돌아갑니다.");
            ResetToStart();
        }
    } 


    
    private void OnTriggerEnter(Collider other)
    {
        // 🏁 골인 지점(Finish 태그) 감지
        if (other.CompareTag("Finish"))
        {
            Debug.Log("🎉 축하합니다! 🎉");
            
            // 화면 전환 및 엔딩 연출 실행
            FindFirstObjectByType<GameManager>().GameClear();
        }
    }
    private void ResetToStart()
    {
        Debug.Log("돌 충돌 감지! 리스폰합니다.");
        transform.position = startPosition;
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}