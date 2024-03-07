using UnityEngine;
using UnityEngineSceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObjekt pauseMenu;

    public void Pause()
    {
        PauseMenu.SetActive(true);
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
    }

    public void Home()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
