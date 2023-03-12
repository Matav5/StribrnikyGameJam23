
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : SceneSingleton<SceneLoader>
{
    // Start is called before the first frame update

    private bool isLoading = false;

    public void Restart()
    {
        StartCoroutine(RestartCoroutine());
    }
    public void LoadLevel(string scene)
    {
        if(!isLoading)
            StartCoroutine(LoadLevelCoroutine(scene));

    }
    public void LoadLevel(int level, int part)
    {
        if(!isLoading)
            StartCoroutine(LoadLevelCoroutine($"Level-{level}-{part}"));

    }
    private IEnumerator LoadLevelCoroutine(string scene)
    {
        isLoading = true;
        if (UIManager.HasInstance() && UIManager.Instance.FadeAnimation != null)
        {
            UIManager.Instance.FadeAnimation.FadeOut();
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene(scene);
    }
    private IEnumerator RestartCoroutine()
    {
        isLoading = true;
        if (UIManager.HasInstance() && UIManager.Instance.FadeAnimation != null)
        {
            UIManager.Instance.FadeAnimation.FadeOut();
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
