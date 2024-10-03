using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private GameObject _Vcam0;
    [SerializeField] private GameObject _Text;
    [SerializeField] private GameObject _Vcam1;
    int nm = 0;
    bool Flag = false;
    public Image fadePanel;             // フェード用のUIパネル（Image）
    public float fadeDuration = 2.0f;   // フェードの完了にかかる時間

    // Start is called before the first frame update
    void Start()
    {
        Color panelColor = fadePanel.color;
        panelColor.a = 0f;
        fadePanel.color = panelColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Flag)
        {
            Flag = false; // To ensure FadeOutAndLoadScene is called only once
            StartCoroutine(FadeOutAndLoadScene());
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("GamePad_Start"))
        {
            
                    Flag = true;
                   
            }
        }

       

    IEnumerator FadeOutAndLoadScene()
    {
        Color panelColor = fadePanel.color;
        float startAlpha = panelColor.a;
        float rate = 1.0f / fadeDuration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            panelColor.a = Mathf.Lerp(startAlpha, 1.0f, progress);
            fadePanel.color = panelColor;
            progress += rate * Time.deltaTime;

            yield return null;
        }

        panelColor.a = 1.0f;
        fadePanel.color = panelColor;

        SceneManager.LoadScene("MainGame");
    }
}
