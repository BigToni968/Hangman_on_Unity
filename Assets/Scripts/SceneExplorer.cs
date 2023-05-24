using UnityEngine.SceneManagement;
using UnityEngine;

public interface ISceneExplorer
{
    public void Next();
    public void Back();
    public void Goto(int indexScene);
    public void Reload();
    public void CloseGame();
}

public class SceneExplorer : MonoBehaviour, ISceneExplorer
{
    public void Next() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    public void Back() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    public void Goto(int indexScene) => SceneManager.LoadScene(indexScene);
    public void Reload() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void CloseGame() => Application.Quit();
}