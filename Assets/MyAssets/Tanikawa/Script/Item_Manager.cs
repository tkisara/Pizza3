using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Manager : MonoBehaviour
{
    [SerializeField] GameObject[] Prefabs; // 生成するプレファブの配列
    [SerializeField] float _sTartTime; // 最初のタイマー用の変数
    [SerializeField] int _tMin; //Timeランダム値の最小値
    [SerializeField] int _tMax; //Timeランダム値の最大値
    [SerializeField] int _rMin; //Radiusランダム値の最小値
    [SerializeField] int _rMax; //Radiusランダム値の最大値
    private int _nMmber; // ランダムに選ばれたプレファブのインデックス
    private float _pOsX; // ランダムに代入するX軸の位置
    private float _pOsZ; // ランダムに代入するZ軸の位置
    private float _tIme; //時間を入れる変数

    // Start is called before the first frame update
    void Start()
    {
        _tIme = Random.Range(_tMin,_tMax);
        Debug.Log(_tIme);
    }
    
    // Update is called once per frame
    void Update()
    {
        _sTartTime -= Time.deltaTime;  // タイマーを減少させる
        if (_sTartTime <= 0.0f)
        {
            _tIme -= Time.deltaTime; // タイマーを減少させる
        }
        if (_tIme <= 0.0f) // タイマーが0以下になったら
        {
            ItemFall();
        }

    }
    void ItemFall()
    {
        _nMmber = Random.Range(0, Prefabs.Length); // プレファブ配列からランダムにインデックスを選ぶ
        _pOsX = Random.Range(_rMin, _rMax);
        _pOsZ = Random.Range(_rMin, _rMax);
        Instantiate(Prefabs[_nMmber], new Vector3(_pOsX, 50, _pOsZ), Quaternion.identity); // 選ばれたプレファブを生成
        _tIme = Random.Range(_tMin, _tMax);
    }
}
