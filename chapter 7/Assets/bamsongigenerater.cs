using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bamsongi = Instantiate(bamsongiPrefab);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bamsongi.GetComponent<BamsongiController>().Shoot(ray.direction * 2000);
        }
    }
}