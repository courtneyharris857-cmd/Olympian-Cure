using UnityEngine;

public class CastSpell : MonoBehaviour
{
    public float spellSpeed;
    public float spellRate, spellDamage;

    public Transform spellSpawnTransform;
    public GameObject spellPrefab;

    private float timer;


    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime / spellRate;
        }
        if (Input.GetButtonDown("Fire2") && timer <= 0)
        {
            castSpell();
        }

    }
    void castSpell()
    {
        GameObject spell = Instantiate(spellPrefab, spellSpawnTransform.position, Quaternion.identity);
        spell.GetComponent<Rigidbody>().AddForce(spellSpawnTransform.forward * spellSpeed, ForceMode.Impulse);
        spell.GetComponent<Spell>().damage = spellDamage;

        timer = 1;
    }
}

