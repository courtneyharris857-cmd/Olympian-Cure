using UnityEngine;

public class pickupscript : MonoBehaviour
{
//Defining variables (pickup settings basically)
    [SerializeField] Transform holdArea;
    private GameObject heldObj;
    private Rigidbody heldObjRB;
    //The pickup physics
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObj == null)
            {
                //player looking pickupable obj slay
                RaycastHit hit;
                
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    if (hit.collider.tag == "pickup")
                    {
                        PickupObject(hit.transform.gameObject);
                    }
                    
                }
            }
            else
            {
                //drop
                DropObject();
            }
        }
        if (heldObj != null)
        {
            //move
            MoveObject();
        }

    }
    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f) //checkign distance between obj and the hold area
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position); //work out how far it needs to move
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }
    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            //picked up obj logic
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.linearDamping = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation; //stop obj from rotating weird when picked up

            heldObjRB.transform.parent = holdArea; //parenting the obj to the place it will be held in
            heldObj = pickObj;

        }
    }
    void DropObject()
    {
        
        //held/dropping obj logic
        heldObjRB.useGravity = true;
        heldObjRB.linearDamping = 1;
        heldObjRB.constraints = RigidbodyConstraints.None; 

        heldObjRB.transform.parent = null; //unparenting the obj (orphan obj fr he should be batman)
        heldObj = null;

        
    }
}
