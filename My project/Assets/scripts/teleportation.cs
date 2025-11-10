using System.Collections;
using UnityEngine;

public class teleportation : MonoBehaviour
{
    public GameObject Teleporter1;
    public GameObject Teleporter2;
    public bool cooldown;

    private void OnTriggerEnter(Collider collision)
    { 
        if(collision.gameObject == Teleporter1 && cooldown)
        {
            this.gameObject.transform.position = Teleporter2.transform.position;
            cooldown = true;
            StartCoroutine(timer());
        }
        else if (collision.gameObject == Teleporter2 && cooldown)
        {
            this.gameObject.transform.position = Teleporter1.transform.position;
            cooldown = true;
            StartCoroutine(timer());
        }
    }

    public IEnumerator timer()
    {
        yield return new WaitForSeconds(2);
        cooldown = false;
    }
}
