using UnityEngine;
using UnityEngine.SceneManagement;
public class playercontrolar : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce = 600.0f;
    float wlakForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    public Sprite[] walkSprites;
    public Sprite jumpSprite;
    float time = 0;
    int idx = 0;
    SpriteRenderer spriteRenderer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && this.rigid2D.linearVelocityY == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
        if (this.rigid2D.linearVelocity.x < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * this.wlakForce);
        }
        if (this.rigid2D.linearVelocityY != 0)
        {
            this.spriteRenderer.sprite = this.jumpSprite;
        }
        else
        {
            this.time += Time.deltaTime;
            if (this.time > 0.1f)
            {
                this.time = 0;
                this.spriteRenderer.sprite = this.walkSprites[this.idx];
                this.idx = 1 - this.idx;
            }
        }
        if (transform.transform.position.y < -10) ;
        {
            SceneManager.LoadScene("gameScene");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("골");
        SceneManager.LoadScene("ClearScene");
    }
}
