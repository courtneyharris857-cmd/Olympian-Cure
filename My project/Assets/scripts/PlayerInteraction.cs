using UnityEngine;


public class PlayerInteraction : MonoBehaviour
{
    //how far a player has to be to be able to interact with an object
    public float playerReach = 3f;
    Interactable currentInteractable;
    public GameObject place1;


    // Update is called once per frame
    void Update()
    {
        //reading for an input every frame
        CheckInteraction();

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
           
        }
    }

    //checking every frame
    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        //basically shoots a line forward from the camera acting as where the player is looking

        if (Physics.Raycast(ray, out hit, playerReach))
        //Limiting the interaction 'hit' to the player's reach
        {
            if (hit.collider.tag == "Interactable")
                //checking if the object is interactable
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();
                //getting a reference to the interactable object

                if (currentInteractable && newInteractable != currentInteractable)
                //checking whether the current interactable is the new interactable and disabling the outline of the previous if not.
                {
                    currentInteractable.DisableOutline();
                }



                if (newInteractable.enabled)
                //checking if the interactable object is enabled
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else
                //if the object isnt enabled
                {
                    DisableCurrentInteractable();
                }
            }
            else
            //if the object isnt interactable
            {
                DisableCurrentInteractable();
            }
        }
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    //Interactable object function
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
        HUDcontroller.instance.EnableInteractionText(currentInteractable.message);
    }

    void DisableCurrentInteractable()
    //for disabling the interactable
    {
        HUDcontroller.instance.DisableInteractionText();
        currentInteractable.DisableOutline();
        currentInteractable = null;
    }
}
