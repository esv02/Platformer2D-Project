using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 
    public GameObject startMainMenu;
    public GameObject levelSelect;
    public void StartGame(string sceneMain)
    {
        SceneManager.LoadScene(sceneMain);
    }

    public void GoToLevelSelect()
    {
        startMainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
