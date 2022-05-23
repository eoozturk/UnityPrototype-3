using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 2.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject startScreen;


    private int score;
    public bool isGameActive;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget(float spawnRate)
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void StartGame(int difficult)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= difficult;
        scoreText.gameObject.SetActive(true);
        StartCoroutine(SpawnTarget(spawnRate));
        UpdateScore(0);
        startScreen.gameObject.SetActive(false);

    }

    // Target sınıfından ulaşabilmek için public erişim belirteci kullandık
    public void UpdateScore(int x)
    {
        score += x;
        scoreText.text = "Score: " + score;
    }


    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
