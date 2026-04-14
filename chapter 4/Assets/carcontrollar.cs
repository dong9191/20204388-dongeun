using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class carcontrollar : MonoBehaviour
{
    float speed = 0;
    Vector2 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
;   }

    // 
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 

        {
            this.startPos = Input.mousePosition;

        }
        else if (Input.GetMouseButtonUp(0))
        { 
        Vector2 endPos = Input.mousePosition;
            float swipelength = endPos.x - startPos.x;

            this.speed = swipelength / 500.0f;

            GetComponent<AudioSource>().Play();
        }
        transform.Translate(this.speed,0,0);  // 이동
        this.speed *= 0.98f;

    }
}
