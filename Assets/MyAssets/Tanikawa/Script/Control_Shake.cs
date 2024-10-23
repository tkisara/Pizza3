using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Haptics;

public class Control_Shake : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision other)
    {
        //触れたら何を起こすか
        string tag = other.gameObject.tag;
        if (tag.Contains("Player"))
        {
            Debug.Log("衝突");
            StartCoroutine("Shake");
        }
    }
    private IEnumerator Shake()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null)
        {
            Debug.Log("ゲームパッド未接続");
            yield break;
        }

        Debug.Log("モーター振動");
        gamepad.SetMotorSpeeds(1.0f, 1.0f);
        yield return new WaitForSeconds(1.0f);

        Debug.Log("モーター停止");
        gamepad.SetMotorSpeeds(0.0f, 0.0f);
    }

}
