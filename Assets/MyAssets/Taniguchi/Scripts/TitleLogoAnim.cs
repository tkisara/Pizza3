using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleLogoAnim : MonoBehaviour
{
    [SerializeField] private Image _titleText;
    [SerializeField] private Transform _titlepos;
    private float _textPosY;
    // Start is called before the first frame update
    void Start()
    {
        _titlepos = _titleText.gameObject.transform;
        _textPosY = _titlepos.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        _titlepos.position = new Vector3(_titlepos.position.x, _textPosY + Mathf.PingPong(Time.time / 3, 0.3f), _titlepos.position.z);
    }
}
