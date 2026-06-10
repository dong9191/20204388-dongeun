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

   
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.ToLower().Contains("ground"))
        {
            isGrounded = true;
        }

       
        if (collision.gameObject.name.ToLower().Contains("stone"))
        {
            ResetToStart();
        }

     
        if (collision.gameObject.GetComponent<Obstacle>() != null)
        {
           
            ResetToStart();
        }
    } 


    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Finish"))
        {
        
              
            FindFirstObjectByType<GameManager>().GameClear();
        }
    }
    private void ResetToStart()
    {
       
        transform.position = startPosition;
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}