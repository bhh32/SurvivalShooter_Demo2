using UnityEngine;

// Modified From Tutorial Script
public class EnemyHealth : MonoBehaviour, IDamageable // Mod by me
{
    public delegate void HealthChange(int health, GameObject obj); // Mod by me
    public HealthChange OnDamage; // Mod by me

    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
    public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
    public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
    public AudioClip deathClip;                 // The sound to play when the enemy dies.


    Animator anim;                              // Reference to the animator.
    AudioSource enemyAudio;                     // Reference to the audio source.
    ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
    bool isDead;                                // Whether the enemy is dead.
    bool isSinking;                             // Whether the enemy has started sinking through the floor.

    // Mod by me
    public float Health
    {
        get { return currentHealth; }
        set { currentHealth = (int)value; }
    }

    // Mod by me
    public float armor;

    // Mod by me
    public float Armor
    {
        get { return armor; }
        set { armor = value; }
    }

    // Mod by me
    void OnDamageTaken(int damage, GameObject hitObj)
    {
        hitObj.name = hitObj.name.Replace("(Clone)", " ").TrimEnd();
        Debug.Log(string.Format("{0} has taken {1} amount of damage!", hitObj.name, damage));
    }

    void Awake ()
    {
        // Setting up the references.
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;

        // Mod by me
        OnDamage += OnDamageTaken;
    }


    void Update ()
    {
        // If the enemy should be sinking...
        if(isSinking)
        {
            // ... move the enemy down by the sinkSpeed per second.
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    // Mod by me
    public float ApplyDamage(float amount, float armor, Vector3 hitPoint)
    {
        float damageTaken = 0f;

        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return 0f;

        // Play the hurt sound effect.
        enemyAudio.Play();

        // Reduce the current health by the amount of damage sustained.
        if (Armor <= 0f)
        {
            Health -= amount;
            damageTaken = amount;
        }
        else if(Armor > 0f)
        {
            Armor -= amount;
            damageTaken = Mathf.Abs(Armor - amount);
        }

        // Set the position of the particle system to where the hit was sustained.
        hitParticles.transform.position = hitPoint;

        // And play the particles.
        hitParticles.Play();

        // If the current health is less than or equal to zero...
        if (Health <= 0)
        {
            // ... the enemy is dead.
            Death();
        }

        return damageTaken;
    }

    void Death ()
    {
        // The enemy is dead.
        isDead = true;

        // Turn the collider into a trigger so shots can pass through it.
        capsuleCollider.isTrigger = true;

        // Tell the animator that the enemy is dead.
        anim.SetTrigger ("Dead");

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        // Find and disable the Nav Mesh Agent.
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;

        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
        GetComponent <Rigidbody> ().isKinematic = true;

        // The enemy should no sink.
        isSinking = true;

        // Increase the score by the enemy's score value.
        ScoreManager.score += scoreValue;

        // After 2 seconds destory the enemy.
        Destroy (gameObject, 2f);
    }
}