using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����𕷂����A�����Ă��邩�̃t���O��Ԃ�
/// </summary>
public class Sonar : MonoBehaviour
{
    /// <summary>
    /// �������Ă��邩���Ȃ���
    /// </summary>
    [SerializeField]
    private bool isListen;

    /// <summary>
    /// �������Ă��邩�̃A�N�Z�T
    /// </summary>
    public bool GetIsListen
    {
        get { return isListen; }
    }

    private void OnTriggerStay(Collider other)
    {
        // �������炪�N��������ɂ����ꍇ
        if (other != null)
        {


            // audio�̃R���|�[�l���g�����Ă���ꍇ
            var audio = other.GetComponentInChildren<AudioSource>();
            if (audio != null)
            {
                // �����Đ�����������
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
