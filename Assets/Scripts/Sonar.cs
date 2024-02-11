using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音源を聞き取り、聞いているかのフラグを返す
/// </summary>
public class Sonar : MonoBehaviour
{
    /// <summary>
    /// 聞こえているかいないか
    /// </summary>
    [SerializeField]
    private bool isListen;

    /// <summary>
    /// 聞こえているかのアクセサ
    /// </summary>
    public bool GetIsListen
    {
        get { return isListen; }
    }

    private void OnTriggerStay(Collider other)
    {
        // 何かしらが侵入判定内にいた場合
        if (other != null)
        {


            // audioのコンポーネントがついている場合
            var audio = other.GetComponentInChildren<AudioSource>();
            if (audio != null)
            {
                // 音を再生中だったら
                if (audio.isPlaying)
                {
                    isListen = true;
                }
            }
            else
            {
                isListen = false;
            }
        }
    }





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
