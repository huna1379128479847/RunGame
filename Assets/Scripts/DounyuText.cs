using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DounyuText : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // テキストコンポーネント
    public float fadeInDuration = 3.0f; // フェードインの継続時間
    public float waitTimeBeforeSceneChange = 3.0f; // シーン遷移前の待機時間
    public string nextSceneName = "NextScene"; // 遷移したいシーンの名前
    public float moveDistance = 10.0f; // テキストが移動する距離（奥行き方向）

    private void Start()
    {
        if (textComponent != null)
        {
            // テキストを透明にする
            textComponent.alpha = 0;

            // フェードインアニメーションと移動を実行する
            Sequence sequence = DOTween.Sequence(); // 新しいシーケンスを作成
            sequence.Append(textComponent.DOFade(1.0f, fadeInDuration)); // フェードインアニメーションを追加
            sequence.Join(textComponent.rectTransform.DOLocalMoveZ(moveDistance, fadeInDuration)); // 移動アニメーションを追加

            // 指定した時間待機後、次のシーンに遷移する
            sequence.AppendInterval(waitTimeBeforeSceneChange); // 待機時間を追加
            sequence.AppendCallback(() => SceneManager.LoadScene(nextSceneName)); // シーン遷移コールバックを追加
        }
    }
}
