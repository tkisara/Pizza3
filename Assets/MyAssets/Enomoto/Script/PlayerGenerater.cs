using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerater : MonoBehaviour
{
    public GameObject[] playerPrefab;  // 生成するプレイヤーのプレハブ
    public Transform[] spawnPoints;  // プレイヤーが生成されるスポーン地点

    void Start()
    {
        // SelectManager から PlayerNum を取得
        int playerNum = SelectManager.Instance.userSetting.PlayerNum;

        // PlayerNum の数だけプレイヤーを生成
        for (int i = 0; i < playerNum; i++)
        {
            if (i < spawnPoints.Length)  // スポーン地点が足りるか確認
            {
                Instantiate(playerPrefab[i], spawnPoints[i].position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("スポーン地点が足りません！");
            }
        }
        Debug.Log(playerNum);
    }
// Update is called once per frame
void Update()
    {
        
    }
}
