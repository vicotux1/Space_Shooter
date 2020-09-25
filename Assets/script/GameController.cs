using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait,startWait,waveWait;
    [Header("Text UI")]
    public Text score,highScore,restart,gameOver;

    [SerializeField]private bool boolgameOver= false,boolrestart= false;
    private int int_score;
void Awake(){
    highScore.text="High: "+(PlayerPrefs.GetInt("HighScore", int_score).ToString());
}
    void Start(){
        restart.text = "";
        //score.text="";
        gameOver.text = "";
        int_score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetButton("Fire2"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                if (int_score> PlayerPrefs.GetInt("HighScore", 0)){
                PlayerPrefs.SetInt("HighScore", int_score);
                highScore.text="High: "+(PlayerPrefs.GetInt("HighScore", int_score).ToString());
            }
                
                restart.text = "Press 'B' Button for Restart";
                boolrestart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        int_score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        score.text = "Score: " + int_score;
    }

    public void GameOver(){
        
        gameOver.text = "Game Over!";
        boolgameOver = true;
    }
}