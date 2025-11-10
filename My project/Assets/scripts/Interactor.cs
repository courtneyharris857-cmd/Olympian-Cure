using UnityEngine;



interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //checking every frame whether the player is pressing E
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray R = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(R, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                    Debug.Log("interacting");
                }
            }
        }
    }
}

//eeee i dont like this gonna try smth else