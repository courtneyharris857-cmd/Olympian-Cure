using UnityEngine;


public class button : MonoBehaviour
{
    public GameObject door;

    




    void OnTriggerStay(Collider other)
    {
        door.SetActive(false);
    }
    void OnTriggerExit(Collider other)
    {
        door.SetActive(true);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
