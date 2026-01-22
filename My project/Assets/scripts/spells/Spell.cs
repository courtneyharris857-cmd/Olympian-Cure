using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]


public class Spell : MonoBehaviour
{
    public SpellScriptableObject SpellToCast;
    public SpellScriptableObject SpellRadius;

    private SphereCollider myCollider;
    private Rigidbody myRigidbody;


    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = SpellToCast.SpellRadius;

        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;
        Destroy(this.gameObject, SpellToCast.Lifetime); //if it doesnt hit anything it will destroy itself anyways
    }

    // Update is called once per frame
    private void Update()
    {
        if (SpellToCast.Speed > 0)
        {
            transform.Translate(transform.forward * SpellToCast.Speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
