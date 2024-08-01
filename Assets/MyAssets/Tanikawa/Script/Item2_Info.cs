using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2_Info : Item_Information
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        //触れたら何を起こすか
        string tag = other.gameObject.tag;
        if (tag.Contains("Player"))
        {
            // （重要ポイント）ItemクラスのItemBaseメソッドを呼び出す。
            // エフェクト、効果音等はこれで発生します。
            base.ItemBase(other.gameObject);
        }

    }
    private void Update()
    {
        if (gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
