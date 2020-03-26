using System.Collections;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;
    //地面の位置
    private float groundLevel = -3.0f;
    //音を鳴らすための宣言
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //着地しているかどうかを調べる ※追加
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;




        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D Collision)
    //キューブが重なった時、音声を鳴らす
    {

        if (Collision.gameObject.tag == "Cube")
        {
            audioSource.Play();
        }

        //キューブが地面に接触した際、音を鳴らす 

        if (Collision.gameObject.tag == "Ground")
        {
            audioSource.Play();
        }



        //キューブがUnityちゃんと接触した場合、音を消す　※追加

        if (Collision.gameObject.tag == "Player")
        {

            audioSource.volume = 0;
        }



    }
}
