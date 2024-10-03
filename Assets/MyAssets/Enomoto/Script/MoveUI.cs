using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MoveUI : MonoBehaviour
{
    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        this.transform.DOShakePosition(2f, 10f, 30, 1, false, false).SetLoops(-1, LoopType.Restart);

    }

    // Update is called once per frame
    void Update()
    {


    }


}
