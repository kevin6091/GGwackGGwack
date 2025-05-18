using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Timeline;

public class OriController : ActorController
{
    float _accTime = 0.0f;
    float _accTime2 = 0.0f;
    bool _isCoroutineRunning = false;

    Vector3 _SmallScale;
    Vector3 _LargeScale;

    public override void Init()
    {
        base.Init();

        _SmallScale = transform.localScale;
        _LargeScale = 1.5f * transform.localScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        _accTime2 += Time.deltaTime;
        if (_accTime2 > 4.0f)
        {
            _accTime2 = 0.0f;
            StartCoroutine("OriRoutine");
        }
    }

    IEnumerator OriRoutine()
    {

        while (true) 
        {
            _accTime += Time.deltaTime;
            
            // 0 ~ 1 * 180µµ * (µµ -> ¶ó)

            float radian = ((_accTime) / 2.0f) * Mathf.Deg2Rad * 180.0f;
            if (_accTime >= 2.0f) 
                break;

            transform.localScale = Vector3.Lerp(_SmallScale, _LargeScale, Mathf.Sin(radian));

            yield return null;
        }

        _accTime = 0.0f;
        float accTime = 0.0f;

        while (true)
        {
            accTime += Time.deltaTime;

            transform.position += (Vector3.up * Time.deltaTime * 0.5f);

            if (accTime >= 2.0f)
                break;

            yield return null;
        }

        yield break;
    }
}
