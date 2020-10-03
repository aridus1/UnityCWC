using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public List<GameObject> targets;
	//not public GameObject[] targets2; list being used over an array;
	
	private float spawnRate = 1.0f;

	private int score;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;
	public Button restartButton;
	public GameObject titleScreen;

	public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {

	}

	public void StartGame(int difficulty)
	{
		titleScreen.gameObject.SetActive(false);

		isGameActive = true;

		spawnRate /= difficulty;
		StartCoroutine(SpawnTarget());
		score = 0;
		UpdateScore(0);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	IEnumerator SpawnTarget()
	{
		while (isGameActive)
		{
			yield return new WaitForSeconds(spawnRate);
			int index = Random.Range(0, targets.Count);
			Instantiate(targets[index]);

			//UpdateScore(5);
		}
	}

	public void UpdateScore(int scoreToAdd)
	{
		score += scoreToAdd;
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.gameObject.SetActive(true);
		isGameActive = false;
		restartButton.gameObject.SetActive(true);
	}

	public void GameRestart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
