using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHealth;
    [SerializeField] private float timer = 3;
    private float spellTime;
    public GameObject enemySpell;
    public Transform spellSpawn;
    public float enemySpeed;
    public float spellDamage = 5;
    public float spellRate;

    void ShootAtPlayer()
    {
        spellTime -= Time.deltaTime;
        if (spellTime > 0)
        {
            return;
        }
        
        GameObject enemyMagic = Instantiate(enemySpell, spellSpawn.position, Quaternion.identity);
        enemyMagic.GetComponent<Rigidbody>().AddForce(spellSpawn.forward * enemySpeed, ForceMode.Impulse);
        enemyMagic.GetComponent<EnemySpell>().damage = spellDamage;


    }
   


    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime / spellRate;
        }
        if (timer <= 0)
        {
            ShootAtPlayer();
            timer = 5;
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
