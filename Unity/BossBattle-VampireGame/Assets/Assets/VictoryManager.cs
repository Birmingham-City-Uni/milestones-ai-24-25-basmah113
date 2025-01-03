using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
	public void GoToMainMenu()
	{
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
