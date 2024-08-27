GameManager

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseScore()
    {
        score++;
        Debug.Log("Score: " + score);

        if (score >= 50)
        {
            Debug.Log("You win!");
            // Add additional win logic here
        }
    }
}

