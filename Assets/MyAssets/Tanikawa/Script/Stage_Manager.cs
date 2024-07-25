using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Stage_Manager : MonoBehaviour
{
    //ステージを時間経過で落とす

    [SerializeField] GameObject[] _pizzaPrefabs; // 生成するプレファブの配列
    public float[] _time; //時間を入れる変数
    public float _speed = 0.5f; //速度を変数として扱う

    float deltaTime = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //時間を進める
        deltaTime += Time.deltaTime;

        for(int i = 0; i < _pizzaPrefabs.Length; i++)
        {
            if (deltaTime >= _time[i])
            {
                StageDown(i);
            }
        }
       
        
    }
    //時間経過したらstage1をy軸方向に落とす関数を作る
    private void StageDown(int i)
    {
        if (_pizzaPrefabs[i] == null) return;
        _pizzaPrefabs[i].transform.position += new Vector3(0, -_speed, 0) * Time.deltaTime;

        //一定落ちたらdelete
        if (_pizzaPrefabs[i].transform.position.y < -10)
        {
            Destroy(_pizzaPrefabs[i]);
        }
    }
}