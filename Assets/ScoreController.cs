using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    //Scoreを表示するテキスト
    public GameObject ScoreText;

    //得点の設定
    private int[] points = new int[] { 1, 3, 5, 10 };
    //SmallStar  = 1pt
    //SmallCloud = 3pt
    //LargeStar  = 5pt
    //LargeCloud = 10pt
    
    //スコアの計算
    private int score;


    // Use this for initialization
    void Start() {
        //シーン中のScoreTextオブジェクトを取得
        this.ScoreText = GameObject.Find("ScoreText");

        //スコアの初期化
        score = 0;
        this.ScoreText.GetComponent<Text>().text = "SCORE:" + score.ToString();
    }
    
    // Update is called once per frame
    void Update () {
		
	}


    
    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            score = score + points[0];   //小さい星に当たったら1点を加算
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            score = score + points[1];   //小さい雲に当たったら3点を加算
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            score = score + points[2];   //大きい星に当たったら5点を加算
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            score = score + points[3];   //大きい雲に当たったら10点を加算
        }

        //スコアの表示
        this.ScoreText.GetComponent<Text>().text = "SCORE:" + score.ToString();
    }
}
