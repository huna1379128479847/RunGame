using DG.Tweening;
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
    public float moveDistance = 10.0f; // テキストが移動する距離（奥行き方向）

    private void Start()
    {
        if (textComponent != null)
        {
            // テキストを透明にする
            textComponent.alpha = 0;

            // フェードインアニメーションと移動を実行する
            Sequence sequence = DOTween.Sequence();
            sequence.Append(textComponent.DOFade(1.0f, fadeInDuration)); // フェードイン
            sequence.Join(textComponent.rectTransform.DOLocalMoveZ(moveDistance, fadeInDuration)); // 移動

            // 指定した時間待機後、次のシーンに遷移する
            sequence.AppendInterval(waitTimeBeforeSceneChange);
            sequence.AppendCallback(() => SceneManager.LoadScene(nextSceneName));
        }
    }
}
