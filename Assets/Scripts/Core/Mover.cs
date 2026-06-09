using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    public Transform tf;
    public AudioSource Source;
    public AudioClip ShotSound;
    private SpriteRenderer theRenderer; 
    private GameManager gameManager;


    public float MovementSpeed = 5.0f;
    public float MinXBound = -5.0f;
    public float MaxXBound = 5.0f;
    public float MinYBound = -5.0f;
    public float MaxYBound = 5.0f;
    public float FastSpeed = 2.0f;
    public float SlowSpeed = 0.5f;
    public Color spriteColor;

   
    protected virtual void Start()
    {
        tf = GetComponent<Transform>();
        theRenderer = GetComponent<SpriteRenderer>();
        gameManager = GameObject.FindFirstObjectByType<GameManager>();

        spriteColor.a = 1.0f;
    }

    public virtual void RandomPosition()
    {
        float randomX = Random.Range(MinXBound, MaxXBound);
        float randomY = Random.Range(MinYBound, MaxYBound);

        tf.position = new Vector3(randomX, randomY, 0.0f);

        spriteColor.r = Random.Range(0.0f, 1.0f);
        spriteColor.g = Random.Range(0.0f, 1.0f);
        spriteColor.b = Random.Range(0.0f, 1.0f);

        if (theRenderer != null)
        {
            theRenderer.color = spriteColor;
        }
    }

    public virtual void MovePawn(int verticalDirection, int horizontalDirection, bool SpeedIncrease, bool SpeedDecrease)
    {
        if (SpeedDecrease)
        {
            tf.position = tf.position + new Vector3(
                horizontalDirection * Time.deltaTime * MovementSpeed * SlowSpeed,
                verticalDirection * Time.deltaTime * MovementSpeed * SlowSpeed,
                0.0f);
        }
        else if (SpeedIncrease)
        {
            tf.position = tf.position + new Vector3(
                horizontalDirection * Time.deltaTime * MovementSpeed * FastSpeed,
                verticalDirection * Time.deltaTime * MovementSpeed * FastSpeed,
                0.0f);
        }
        else 
        {
            tf.position = tf.position + new Vector3(
                horizontalDirection * Time.deltaTime * MovementSpeed,
                verticalDirection * Time.deltaTime * MovementSpeed,
                0.0f);
        }
    }

    public virtual void ShiftPawn(int verticalDirection, int horizontalDirection)
    {
        tf.position = tf.position + new Vector3(
            horizontalDirection,
            verticalDirection,
            0.0f
        );
    }

    public virtual void MakeShot(int verticalDirection, int horizontalDirection)
    {
        if (tf == null){ Debug.Log("No transform found!");}
        if (gameManager == null){ Debug.Log("No gameManager found!");}
        if (Source)
        {
            Source.PlayOneShot(ShotSound, 1.0f);
        }
        StartCoroutine(gameManager.Shoot(new Vector3(verticalDirection, horizontalDirection, 0.0f), tf.position));
    }
}
