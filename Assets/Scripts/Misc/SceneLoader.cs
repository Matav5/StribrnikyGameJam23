
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : SceneSingleton<SceneLoader>
{
    // Start is called before the first frame update
   


    public void Restart()
    {
        StartCoroutine(RestartCoroutine());
    }
    public void LoadLevel(string scene)
    {
        StartCoroutine(LoadLevelCoroutine(scene));

    }
    public void LoadLevel(int level, int part)
    {
        StartCoroutine(LoadLevelCoroutine($"Level-{level}-{part}"));

    }
    private IEnumerator LoadLevelCoroutine(string scene)
    {
        if (UIManager.HasInstance() && UIManager.Instance.FadeAnimation != null)
        {
            UIManager.Instance.FadeAnimation.FadeOut();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(scene);
        }
    }
    private IEnumerator RestartCoroutine()
    {
        if (UIManager.HasInstance() && UIManager.Instance.FadeAnimation != null)
        {
            UIManager.Instance.FadeAnimation.FadeOut();
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
