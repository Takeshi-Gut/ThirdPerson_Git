using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 弾を生成し、前方に発射するクラス
/// </summary>
public class BulletShooter : MonoBehaviour
{
    // public修飾子でgameObject型のBulletという変数を作成してください。
    public GameObject Bullet;

    // public修飾子でvoid型のShootというメソッドを作成してください。
    public void Shoot()
    {
        // BulletをInstantiateします。Instantiateメソッドの第一引数にBulletを設定します。
        // InstantiateしたGameObjectを左辺のbulletに代入する
        var bullet = Instantiate(Bullet);

        // 左辺にBulletの変数instantiateBulletを作成し、
        // 上のbulletからBulletのコンポーネントを取得してください。
        Bullet instantiateBullet = bullet.GetComponent<Bullet>();

        // instantiateBulletのbulletInitializeを呼び出します。
        instantiateBullet.BulletInitialize(this.transform);

    }

    private void Update()
    {
        // もし、BulletがNullじゃなく、かつ、キーボードでzキーが押されたら、
        if (Bullet != null && Keyboard.current.zKey.wasPressedThisFrame)
        {
            // Shootメソッドを呼ぶ。
            Shoot();
        }
    }
}
