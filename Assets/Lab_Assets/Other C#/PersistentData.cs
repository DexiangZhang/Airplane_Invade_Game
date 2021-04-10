using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public int playerHeath;
    public int playerScore;


    public static PersistentData Instance;

    // Start is called before the first frame update
    void Start()
    {
        playerHeath = 10;
        playerScore = 0;
    }


    void Awake()
    {
        if (Instance == null)
        {

            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void SetHealth(int health)
    {
        playerHeath = health;
    }

    public void SetScore(int score)
    {
        playerScore = score;
    }

    public int GetHealth()
    {
        return playerHeath;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void IncreaseScore(int point)
    {
            playerScore += point;
  
    }

    public void DecreaseScore(int minusP)
    {
        if (playerScore >= minusP)
            playerScore -= minusP;
        else
            Debug.Log("You are already in 0 score!");
    }

}