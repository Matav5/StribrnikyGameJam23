
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
    public void LoadLevel(int level, int part)
    {
        StartCoroutine(LoadLevelCoroutine(level,part));

    }
    private IEnumerator LoadLevelCoroutine(int level, int part)
    {
        if (UIManager.HasInstance() && UIManager.Instance.FadeAnimation != null)
        {
            UIManager.Instance.FadeAnimation.FadeOut();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene($"Level-{level}-{part}");
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
