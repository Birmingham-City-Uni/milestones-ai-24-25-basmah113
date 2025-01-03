using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
	public void RestartGame()
	{
		SceneManager.LoadScene("BossBattle"); 
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
