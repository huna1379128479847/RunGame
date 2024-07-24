using System;
using UnityEngine;
namespace HighElixir
{
    // ジェネリックなシングルトンクラス
    public abstract class SingletonBehavior<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance = null; // シングルトンインスタンスを保持する静的変数

        // インスタンスプロパティ
        public static T instance
        {
            get
            {
                // インスタンスがまだ作成されていない場合
                if (_instance == null)
                {
                    Type t = typeof(T);

                    // シーン内で既存のオブジェクトを探してインスタンスを取得
                    _instance = (T)FindObjectOfType(t);
                    if (_instance == null)
                    {
                        // インスタンスが見つからない場合のデバッグメッセージ
                        Debug.Log("no game objects : " + t);
                    }
                }
                return _instance;
            }
        }

        // Awakeはオブジェクトがロードされたときに呼び出されるメソッド
        virtual protected void Awake()
        {
            CheckInstance(); // シングルトンインスタンスの確認
        }

        // OnDestroyはオブジェクトが破棄されるときに呼び出されるメソッド
        virtual protected void OnDestroy()
        {
            // このインスタンスがシングルトンインスタンスである場合、インスタンスをnullに設定
            if (instance == this)
            {
                _instance = null;
            }
        }

        // シングルトンインスタンスの確認と設定を行うメソッド
        protected bool CheckInstance()
        {
            // インスタンスがまだ設定されていない場合
            if (_instance == null)
            {
                _instance = this as T;
                return true;
            }
            // このインスタンスが既存のインスタンスである場合
            else if (instance == this)
            {
                return true;
            }
            // それ以外の場合、このオブジェクトを破棄
            Destroy(this);
            return false;
        }
    }
}