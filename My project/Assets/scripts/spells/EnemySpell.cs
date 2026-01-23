using UnityEngine;

public class EnemySpell : MonoBehaviour
{
    public float damage;
    public float lifeTime = 3;

    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime < 2)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider Player)
    {
        if (Player.GetComponent<PlayerHealth>() != null)
        {
            Player.GetComponent<PlayerHealth>().playerHealth -= damage;
        }
    }
}
