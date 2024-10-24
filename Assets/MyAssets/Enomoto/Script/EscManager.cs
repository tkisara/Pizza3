using UnityEngine;

public class SingletonDontDestroy : MonoBehaviour
{
    private static SingletonDontDestroy instance;

    void Awake()
    {
        // すでにインスタンスが存在する場合、これを破棄
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // インスタンスを設定し、オブジェクトを破棄しない
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Updateメソッドを必要に応じて追加
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
