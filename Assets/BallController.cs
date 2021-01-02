using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    //スコアを表示するテキスト
    private GameObject scoreText;
    //スコア
    private int score = 0;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
        this.scoreText.GetComponent<Text>().text = "Score: " + score;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var point = 0;
        if(collision.gameObject.tag == "SmallStarTag")
        {
            point = 10;
        }
        if(collision.gameObject.tag == "LargeStarTag")
        {
            point = 20;
        }
        if(collision.gameObject.tag == "SmallCloudTag")
        {
            point = 1;
        }
        if(collision.gameObject.tag == "LargeCloudTag")
        {
            point = 2;
        }
        score += point;
    }




}
