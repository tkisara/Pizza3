using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Information : MonoBehaviour //プレイヤーの値を継承したい
{
    //エフェクトの発生、SEの発生、Itemの削除
    [SerializeField] GameObject _eFfectPrefab;
    [SerializeField] AudioClip _sOund;
   
    // Start is called before the first frame update
    // （ポイント）先頭に「public」をつけること。
    public void ItemBase(GameObject Player)
    {
        //プレイヤーの値を継承出来たら
        //アイテムのtagを確認する
        switch (gameObject.tag)
        {
            case "Item0": //Item0の時
                //プレイヤーの値を書き換える
                Debug.Log("Item0"); 
                break;  

            case "Item1":
                //プレイヤーの値を書き換える
                Debug.Log("Item1"); 
                break; 

            case "Item2":
                //プレイヤーの値を書き換える
                Debug.Log("Item2"); 
                break; 

            default:    
                break; //switch文から抜ける
        }

        //エフェクトのインスタンス生成
        GameObject effect0 = Instantiate(_eFfectPrefab, Player.transform.position, Quaternion.identity);
        // エフェクトをエネミーの子に設定する
        effect0.transform.SetParent(Player.transform);
        //エフェクトの削除
        Destroy(effect0, 1.5f);
      
        //SEの再生
        AudioSource.PlayClipAtPoint(_sOund, transform.position);

        // アイテムは破壊する。
        Destroy(this.gameObject);
    }
}
