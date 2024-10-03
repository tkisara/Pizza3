using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MoveUISTART : MonoBehaviour
{
    RectTransform rect;
    private bool isDefaultScale;
    // Start is called before the first frame update
    void Start()
    {
        if (isDefaultScale)
        {
            this.transform.DOScale(new Vector3(16, 13, 13), 0.2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InCirc);
            isDefaultScale = false;
        }
        else if (!isDefaultScale)
        {
            this.transform.DOScale(new Vector3(18, 15, 15), 0.2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InCirc);
            isDefaultScale = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
      /* if(isDefaultScale)
        {
            this.transform.DOScale(new Vector3(16, 13, 13), 0.2f);
            isDefaultScale = false;
        }
       else if(!isDefaultScale)
        {
            this.transform.DOScale(new Vector3(19, 16, 16), 0.2f);
            isDefaultScale = true;
        }*/
        
    }
}
