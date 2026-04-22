using UnityEngine;

public class playercontroler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            transform.Translate(-3, 0, 0);
        }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Translate(3, 0, 0);
            }
        }
    }
    



