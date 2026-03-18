using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float rotSpeed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;

        Debug.Log("게임 시작! 룰렛의 코드 확인");
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0))
    {
        this.rotSpeed = 10;

            Debug.Log("마우스 클릭 감지됨");
    }
    transform.Rotate(0,0,this.rotSpeed);
        }
}
