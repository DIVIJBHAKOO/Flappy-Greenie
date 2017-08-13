using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    public int myScore;
    public Text myScoreGUI;

    public Transform bottomObstacle, topObstacle;

    void Start()
    {
        myScore = 0;

        myScoreGUI = GameObject.Find("Text").GetComponent<Text>();
        InvokeRepeating("ObstacleSpawner", .5f, 1.2f);
    }

    public void GmAddScore()
    {
        this.myScore++;
        myScoreGUI.text = myScore.ToString();
    }



    void ObstacleSpawner()
    {
        int rand = Random.Range(0, 2);
        float topObstacleMinY = 2f,
        topObstacleMaxY = 6.5f,
        bottomObstacleMinY = -6.5f,
        bottomObstacleMaxY = -2f;

        switch (rand)
        {
            case 0:
                Instantiate(
                    bottomObstacle,
                new Vector2(
                    9f,
                    Random.Range(bottomObstacleMinY, bottomObstacleMaxY)
                    ),
                Quaternion.identity);
                break;
            case 1:
                Instantiate(topObstacle,
                new Vector2(
                    9f,
                    Random.Range(topObstacleMinY, topObstacleMaxY)
                    ),
                Quaternion.identity);
                break;
        }

    }

}