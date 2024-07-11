using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Manager : MonoBehaviour
{
    [SerializeField] GameObject[] Prefabs; // 生成するプレファブの配列
    [SerializeField] float time; // タイマー用の変数
    [SerializeField] int Rmin; //ランダム値の最小値
    [SerializeField] int Rmax; //ランダム値の最大値
    private int number; // ランダムに選ばれたプレファブのインデックス
    private float posX; // ランダムに代入するX軸の位置
    private float posZ; // ランダムに代入するZ軸の位置

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime; // タイマーを減少させる
        if (time <= 0.0f) // タイマーが0以下になったら
        {
            time = 1.0f; // タイマーをリセット
            number = Random.Range(0, Prefabs.Length); // プレファブ配列からランダムにインデックスを選ぶ
            posX = Random.Range(Rmin,Rmax);
            posZ = Random.Range(Rmin,Rmax);
            Instantiate(Prefabs[number], new Vector3(posX, 50, posZ), Quaternion.identity); // 選ばれたプレファブを生成
        }
    }
}
