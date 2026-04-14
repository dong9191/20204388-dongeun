using UnityEngine;
using TMPro;
public class gamedirector : MonoBehaviour
{
    GameObject car;
        GameObject flag;
    GameObject distance;
    void Start()
    {
        this.car = GameObject.Find("car_0");
        this.flag = GameObject.Find("flag_0");
        this.distance = GameObject.Find("distance");

    }

    // Update is called once per frame
    void Update()
    {
        float length = this.flag.transform.position.x - this.car.transform.position.x;
        this.distance.GetComponent<TextMeshProUGUI>().text = "distance:" + length.ToString("F2") + "M";
    }
}
