using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class general : MonoBehaviour
{
    public GameObject cube;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("You pressed E");
            if (Input.GetKey(KeyCode.W))
            {
                cube.transform.Translate(0, 1, 0);
            }
        }
    }
}
