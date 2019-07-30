using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //はじいた時の傾き
    private float flickAngle = -20;

    //fingerIdの初期化
    int ID = 0;



    // Use this for initialization
    void Start () {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();
        
        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }
	
	// Update is called once per frame
	void Update () {

        //発展課題
        //Debug.Log(Input.touchCount);

        //触れている指の本数分繰り返す
        for (int i= 0; i < Input.touchCount; i++)
        {
            //触れている指を1本ずつ取得する
            Touch touch = Input.GetTouch(i);        

            //touchを使って処理をする
            if(touch.phase == TouchPhase.Began)
            {
                //touch.fingerId→fingerIdを取得できる。
                //Debug.Log(touch.fingerId);
                
                //左側をタップした時、左フリッパーを動かす
                //Screen.Widthで画面の横幅が取得できる
                if (touch.position.x <= Screen.width * 0.5 && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                    //Debug.Log("左を押した瞬間");

                    //タップしたfingerIdの記憶
                    ID = touch.fingerId;
                }
                //右側をタップした時、右フリッパーを動かす
                if (touch.position.x > Screen.width * 0.5 && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                    //Debug.Log("右を押した瞬間");

                    //タップしたfingerIdの記憶
                    ID = touch.fingerId;
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                //touch.fingerId→fingerIdを取得できる。
                Debug.Log(touch.fingerId);

                //タップした指が離された時フリッパーを元に戻す
                if (touch.fingerId == ID && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
                if (touch.fingerId == ID && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
                //Debug.Log("離した瞬間");
            }
        }



        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        


        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
