using UnityEngine;

public class Death : MonoBehaviour
{     
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindFirstObjectByType<GameManager>();
    }

    public virtual void Die()
    {
        if (gameObject.name == "GameObstacle")
        {
            gameManager.ObstacleCount -= 1;
            gameManager.AddPoints();
        }
        gameManager.PlayBreak(GetComponent<Transform>().position);
        Destroy(gameObject);
    }
}