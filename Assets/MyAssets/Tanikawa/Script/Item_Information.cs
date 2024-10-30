using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Information : MonoBehaviour //プレイヤーの値を継承したい
{
    //エフェクトの発生、SEの発生、Itemの削除
    [SerializeField] GameObject _effectPrefab;
    [SerializeField] AudioClip _sound;

    //プレイヤーの変更値→攻撃力、スピード、身体増幅
    //public static float _addForce;
    //public static float _speed;
    //public static float _body;

    public float _time;

    private void Start()
    {
    }
    // Start is called before the first frame update
    // （ポイント）先頭に「public」をつけること。
    public void ItemBase(GameObject Player)
    {
        var p = Player.GetComponent<PlayerMovementStateMachine>();
        Debug.Log(p.ToString());

        //プレイヤーの値を継承出来たら
        //アイテムのtagを確認する
        switch (gameObject.tag)
        {
            case "Item0": //Item0の時
                //プレイヤーの値を書き換える
                p.StartBufImpulse();
                Debug.Log("Item0"); 
                break;  

            case "Item1":
                //プレイヤーの値を書き換える
                p.StartBufSpeed();
                Debug.Log("Item1"); 
                break; 

            case "Item2":
                //プレイヤーの値を書き換える
                p.StartBufDouble();
                Debug.Log("Item2"); 
                break; 

            default:
                break; //switch文から抜ける
        }

        //エフェクトのインスタンス生成
        GameObject effect0 = Instantiate(_effectPrefab, Player.transform.position, Quaternion.identity);
        // エフェクトをエネミーの子に設定する
        effect0.transform.SetParent(Player.transform);
        //エフェクトの削除
        Destroy(effect0, 1.5f);
      
        //SEの再生
        AudioSource.PlayClipAtPoint(_sound, transform.position);

        // アイテムは破壊する。
        Destroy(this.gameObject);
    }
    private void Update()
    {
        _time += Time.deltaTime;
    }
}
