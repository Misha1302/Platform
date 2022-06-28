using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int menuSceneIndex;
    [SerializeField] private int shopSceneIndex = 1;
    [SerializeField] private int playSceneIndex = 2;

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        try
        {
            //SceneManager.sceneLoaded += FindObjectOfType<SkinChanger>().OnSceneLoaded;
        }
        catch
        {
            // ignored
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(menuSceneIndex);
    }

    public void LoadShop()
    {
        SceneManager.LoadScene(shopSceneIndex);
    }

    public void LoadPlay()
    {
        SceneManager.LoadScene(playSceneIndex);
    }
}