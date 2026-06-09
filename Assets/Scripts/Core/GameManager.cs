using System.Collections; 
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Obstacle;
    public AudioSource Source;
    public TextMeshProUGUI PointsDisplay;
    public TextMeshProUGUI LivesDisplay;
    public AudioClip BreakClip;

    private GameObject Projectile;
    private Rigidbody2D Rigid;

    public int ObstacleCount = 0;
    public int Points = 0;
    public int Lives = 3;
    private bool DoingGame = false;

    private void Awake ()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        Projectile = GameObject.Find("Bullet");
        Projectile.SetActive(false);
        Obstacle = GameObject.Find("Obstacle");
        Obstacle.SetActive(false);
        for (int i = 0; i < 5; i++)
        {
            CloneAndMoveRandomly();
        }
        DoingGame = true;
        StartCoroutine(SpawnLoop());
    }

    void Update()
    {
        if (ObstacleCount == 0 && DoingGame)
        {
            WinGame();
            
        }
        if (GameObject.Find("Player") == null && DoingGame)
        {
            LoseGame();
        }
    }


    public virtual IEnumerator Shoot(Vector3 Direction, Vector3 Position)
    {
        if ( Projectile == null) { Debug.Log("No projectile.");}
        GameObject NewProjectile = Instantiate(Projectile, Position, Quaternion.identity);
        NewProjectile.SetActive(true);

        Rigid = NewProjectile.GetComponent<Rigidbody2D>();
        if (Direction.magnitude != 0)
        {
            Rigid.AddRelativeForce(Direction * 500.0f);
        }
        else
        {
            Rigid.AddRelativeForce(new Vector3(1.0f, 0.0f, 0.0f) * 500.0f);
        }
        
        yield return new WaitForSeconds(5.0f);
        Destroy(NewProjectile);
    }

    IEnumerator SpawnLoop()
    {
        while (DoingGame)
        {
            CloneAndMoveRandomly();
            yield return new WaitForSeconds(1.0f);
        }
    }

    public virtual void PlayBreak(Vector3 Position)
    {
        AudioSource.PlayClipAtPoint(BreakClip, Position);
    }
    public virtual void AddPoints()
    {
        Points += 1;
        PointsDisplay.text = "SCORE: " + Points.ToString();
        if (Points % 15 == 0)
        {
            AddLife();
        }
    }
    public virtual void RemoveLife()
    {
        Lives -= 1;
        LivesDisplay.text = "LIVES: " + Lives.ToString();
    }

    public virtual void AddLife()
    {
        Lives += 1;
        LivesDisplay.text = "LIVES: " + Lives.ToString();
    }

    void CloneAndMoveRandomly()
    {
        if (Obstacle == null) return; 
        
        float randomX = Random.Range(-7f, 7f);
        float randomY = Random.Range(-4f, 4f); 
        
        Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

        GameObject clonedObject = Instantiate(Obstacle, randomPosition, Quaternion.identity);
        clonedObject.SetActive(true);
        clonedObject.name = "GameObstacle";
        ObstacleCount += 1;
    }

    void WinGame()
    {
        Debug.Log("YOU WIN!");
        Source.Stop();
        DoingGame = false;
    }
    void LoseGame()
    {
        Debug.Log("YOU LOSE!");
        Source.Stop();
        DoingGame = false;
    }
}