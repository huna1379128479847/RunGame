using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DounyuText : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float fadeInDuration = 3.0f;
    public float waitTimeBeforeSceneChange = 3.0f;
    public string nextSceneName = "NextScene"; // 遷移したいシーンの名前

    private void Start()
    {
        if (textComponent != null)
        {
            StartCoroutine(FadeInAndChangeScene());
        }
    }

    private IEnumerator FadeInAndChangeScene()
    {
        textComponent.alpha = 0;
        float elapsedTime = 0;

        // テキストをフェードイン
        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            textComponent.alpha = Mathf.Clamp01(elapsedTime / fadeInDuration);
            yield return null;
        }

        // 指定した時間待機
        yield return new WaitForSeconds(waitTimeBeforeSceneChange);

        // 次のシーンに移動
        SceneManager.LoadScene(nextSceneName);
    }
}
