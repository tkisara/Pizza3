using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Manager : MonoBehaviour
{
    [SerializeField] GameObject[] Prefabs; // 生成するプレファブの配列
    [SerializeField] float _startTime; // 最初のタイマー用の変数
    [SerializeField] int _tmin; //Timeランダム値の最小値
    [SerializeField] int _tmax; //Timeランダム値の最大値
    [SerializeField] int _rmin; //Radiusランダム値の最小値
    [SerializeField] int _rmax; //Radiusランダム値の最大値
    private int _number; // ランダムに選ばれたプレファブのインデックス
    private float _posX; // ランダムに代入するX軸の位置
    private float _posZ; // ランダムに代入するZ軸の位置
    private float _time; //時間を入れる変数

    // Start is called before the first frame update
    void Start()
    {
        _time = Random.Range(_tmin,_tmax);
        Debug.Log(_time);
    }
    
    // Update is called once per frame
    void Update()
    {
        _startTime -= Time.deltaTime;  // タイマーを減少させる
        if (_startTime <= 0.0f)
        {
            _time -= Time.deltaTime; // タイマーを減少させる
        }
        if (_time <= 0.0f) // タイマーが0以下になったら
        {
            ItemFall();
        }

    }
    void ItemFall()
    {
        _number = Random.Range(0, Prefabs.Length); // プレファブ配列からランダムにインデックスを選ぶ
        _posX = Random.Range(_rmin, _rmax);
        _posZ = Random.Range(_rmin, _rmax);
        Instantiate(Prefabs[_number], new Vector3(_posX, 50, _posZ), Quaternion.identity); // 選ばれたプレファブを生成
        _time = Random.Range(_rmin, _rmax);
    }
}
