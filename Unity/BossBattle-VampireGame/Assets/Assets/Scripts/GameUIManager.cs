using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
	public GameObject gameOverPanel;
	public GameObject victoryPanel;

	public AudioSource bossBattleAudioSource; 
	public AudioSource mainMenuAudioSource;  

	private AudioSource gameOverAudioSource;
	private AudioSource victoryAudioSource;

	void Start()
	{
		if (gameOverPanel != null)
			gameOverAudioSource = gameOverPanel.GetComponent<AudioSource>();

		if (victoryPanel != null)
			victoryAudioSource = victoryPanel.GetComponent<AudioSource>();

		if (gameOverPanel != null) gameOverPanel.SetActive(false);
		if (victoryPanel != null) victoryPanel.SetActive(false);

		if (mainMenuAudioSource != null && SceneManager.GetActiveScene().name == "MainMenu")
		{
			mainMenuAudioSource.Play();
		}
	}

	public void ShowGameOver()
	{
		if (gameOverPanel != null)
		{
			gameOverPanel.SetActive(true);

			if (bossBattleAudioSource != null && bossBattleAudioSource.isPlaying)
				bossBattleAudioSource.Stop();

			if (gameOverAudioSource != null)
				gameOverAudioSource.Play();

			Time.timeScale = 0;
		}
	}

	public void ShowVictory()
	{
		if (victoryPanel != null)
		{
			victoryPanel.SetActive(true);

			if (bossBattleAudioSource != null && bossBattleAudioSource.isPlaying)
				bossBattleAudioSource.Stop();

			if (victoryAudioSource != null)
				victoryAudioSource.Play();

			Time.timeScale = 0;
		}
	}

	public void RestartGame()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void MainMenu()
	{
		Time.timeScale = 1;

		if (bossBattleAudioSource != null && bossBattleAudioSource.isPlaying)
			bossBattleAudioSource.Stop();

		SceneManager.LoadScene("MainMenu");
	}

	public void QuitGame()
	{
		Debug.Log("Quit Game");
		Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
	}
}
