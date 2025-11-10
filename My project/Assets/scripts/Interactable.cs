using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    Outline outline;
    public string message;

    public UnityEvent OnInteraction;


    //interact function
    public void Interact()
    {
        OnInteraction.Invoke();
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //message when hovering
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    //more on outline and disabling/enabling it when hovering over an object
    public void DisableOutline()
    {
        outline.enabled = false;

    }
    public void EnableOutline()
    {
        outline.enabled = true;

    }







    // Update is called once per frame
    void Update()
    {
        
    }
}
