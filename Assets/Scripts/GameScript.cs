using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public Text timerLabel;
    public Text countLabel;

    [System.NonSerialized] public float countDown = 5.0f;
    [System.NonSerialized] public float timer = 20.0f;
    [System.NonSerialized] public bool startFlag = false;
    [System.NonSerialized] public int tapiocaNum = 0;

    public GameObject startButton;
    public GameObject retryButton;
    public GameObject Generator;
    public GameObject Mug;
    public GameObject Straw;

    GameObject[] tapiocaObj;
    TapiocaGenerator generatorScript;
    private Rigidbody _rigidbody;

    void Start()
    {
        generatorScript = Generator.GetComponent<TapiocaGenerator>();
        _rigidbody = Straw.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 開始ボタンが押されていなければ
        if (!startFlag)
        {
            // なにもしない
            return;
        }
        // カウントダウン中ならば
        if (countDown > 0.0f)
        {
            countDown -= Time.deltaTime;
            timerLabel.text = countDown.ToString("f0");
            startButton.SetActive(false);
            return;
        }
        // ゲーム中ならば
        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
            timerLabel.text = timer.ToString("f1");
        }
        // ゲームが終了ならば
        else if (timer > -1.5f)
        {
            timer -= Time.deltaTime;
            timerLabel.text = "いっぱい取れたー！";
        }
        // ゲーム終了から１.5秒後
        else
        {
            // リザルトを表示
            tapiocaObj = GameObject.FindGameObjectsWithTag("Tapioca");
            tapiocaNum = tapiocaObj.Length - 1;
            countLabel.text = "集めたタピオカ（個）：" + tapiocaNum;
            retryButton.SetActive(true);
        }
    }


    public void StartButton()
    {
        startFlag = true;
    }

    public void RetryButton()
    {
        startFlag = false;
        countDown = 5.0f;
        timer = 20.0f;
        tapiocaNum = 0;

        generatorScript.coroutineFlag = false;

        timerLabel.text = "空から降ってくるタピオカをコップで集めるゲーム";
        countLabel.text = "";

        startButton.SetActive(true);
        retryButton.SetActive(false);

        Transform mugTransform = Mug.transform;
        Vector3 mugPos = mugTransform.position;
        mugPos.x = -8;
        mugPos.y = -4;
        mugPos.z = 0;
        mugTransform.position = mugPos;

        Transform strawTransform = Straw.transform;
        Vector3 strawPos = strawTransform.position;
        strawPos.x = -7.8f;
        strawPos.y = -1.5f;
        strawPos.z = 0;
        strawTransform.position = strawPos;

        Vector3 strawAngle = strawTransform.eulerAngles;
        strawAngle.x = 0;
        strawAngle.y = 0;
        strawAngle.z = -28;
        strawTransform.eulerAngles = strawAngle;

        _rigidbody.velocity = Vector3.zero;
    }
}
