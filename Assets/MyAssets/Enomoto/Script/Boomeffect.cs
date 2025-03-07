using UnityEngine;
using static UnityEngine.ParticleSystem;

public class TriggerEffect : MonoBehaviour
{
    // エフェクトのプレハブ（事前に作成したパーティクルシステムなどをアサイン）
  
   [SerializeField]
   [Tooltip("発生させるエフェクト(パーティクル)")]
   private ParticleSystem effectBoom;
   [SerializeField]
   [Tooltip("発生させるエフェクト(パーティクル)")]
   private ParticleSystem effectEx;
   [SerializeField]
   [Tooltip("発生させるSE")]
   private AudioSource newaudio;

    // トリガーに入ったときに呼ばれるメソッド
    /// <summary>
	/// 衝突した時
	/// </summary>
	/// <param name="collision"></param>
    private void OnCollisionEnter(Collision other)
    {
        // タグが "Player" の場合のみエフェクトを発生させる
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("当たった");

            effectBoom.Play();
            effectEx.Play();
            newaudio.Play();

            /*// パーティクルシステムのインスタンスを生成する。
            ParticleSystem newParticle0 = Instantiate(effectBoom);
            ParticleSystem newParticle1 = Instantiate(effectEx);
            // パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
            newParticle0.transform.position = this.transform.position;
            newParticle1.transform.position = this.transform.position;
            // パーティクルを発生させる。
            newParticle0.Play(); 
            newParticle1.Play();
            // インスタンス化したパーティクルシステムのGameObjectを5秒後に削除する。(任意)
            // ※第一引数をnewParticleだけにするとコンポーネントしか削除されない。
            Destroy(newParticle0.gameObject, 5.0f);
            Destroy(newParticle1.gameObject, 5.0f);*/
        }
    }
}
