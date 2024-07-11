using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Information : MonoBehaviour
{
    //エフェクトの発生、SEの発生、Itemの削除
    public GameObject effectPrefab;
    public AudioClip sound;

    // Start is called before the first frame update
    // （ポイント）先頭に「public」をつけること。
    public void ItemBase(GameObject target)
    {
        GameObject effect = Instantiate(effectPrefab, target.transform.position, Quaternion.identity);
        Destroy(effect, 1.0f);
        AudioSource.PlayClipAtPoint(sound, transform.position);

        //（ポイント）
        // アイテムは破壊ではなく非アクティブ状態にする。
        // パワーアップアイテムとの関係から。
        this.gameObject.SetActive(false);

        // ミサイルを破壊する。
        Destroy(target.gameObject);
    }
}
