using UnityEngine;

public class playercontrolar : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce = 600.0f;
    float wlakForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input .GetMouseButtonDown(0))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
            if (this.rigid2D.linearVelocity.x < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * this.wlakForce);
        }
    }
}
