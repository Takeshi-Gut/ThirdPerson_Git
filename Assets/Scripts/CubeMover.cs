using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ©g‚ÌˆÊ’uî•ñ‚ğæ“¾
        Transform myTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {

        //X•ûŒü‚ÉˆÚ“®‚·‚é(‰E•ûŒü)
        //transform.Translate(1.0f * Time.deltaTime, 0, 0);
        transform.position += new Vector3(1.0f , 0,0) * Time.deltaTime;

    }
}
