using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{

    [SerializeField] private Spell spellToCast;
    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float currentMana;
    [SerializeField] private float manaRechargeRate = 2f;
    [SerializeField] private float timeBetweenCasts = 0.25f;
    private float currentCastTimer;


    [SerializeField] private Transform castPoint;
    private bool castingMagic = false;




    // Update is called once per frame
    void Update()
    {
        if (!castingMagic && Input.GetMouseButton(1)) //checking if mouse button held down whilst not casting a spell
        {
            castingMagic = true; //casts spell
            currentCastTimer = 0; //resets spell cooldown
            CastSpell(); //function
        }
        if (castingMagic)
        {
            currentCastTimer += Time.deltaTime; //adding cooldown between spells cast

            if (currentCastTimer > timeBetweenCasts) //if more time has passed than the cooldown then it will reset back to not casting and allow the user to cast aanother spell
            {
                castingMagic = false;
            }
        }


        void CastSpell()
        {
            Instantiate(spellToCast, castPoint.position, castPoint.rotation);
        }
    }
}
