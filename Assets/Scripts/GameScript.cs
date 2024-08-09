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
    [System.NonSerialized] public float startFlag = 0;
    [System.NonSerialized] public float tapiocaNum = 0;
    [System.NonSerialized] public float fixFlag = 0;

    public GameObject startButton;
    public GameObject retryButton;
    public GameObject Generator;
    public GameObject Straw;

    GameObject[] tapiocaObj;
    TapiocaGenerator script;

    void Start()
    {
        script = Generator.GetComponent<TapiocaGenerator>();
    }

    void Update()
    {
        if (startFlag == 1)
        {
            if (countDown > 0.0f)
            {
                countDown -= Time.deltaTime;
                timerLabel.text = countDown.ToString("f0");
                startButton.SetActive(false);
            }
            else if (timer > 0.0f)
            {
                timer -= Time.deltaTime;
                timerLabel.text = timer.ToString("f1");
            }
            else if (timer > -1.5f)
            {
                timer -= Time.deltaTime;
                timerLabel.text = "いっぱい取れたー！";
            }
            else if (timer > -1.5f)
            {

            }
            else if (timer <= -1.5f)
            {
                tapiocaObj = GameObject.FindGameObjectsWithTag("Tapioca");
                tapiocaNum = tapiocaObj.Length - 1;
                countLabel.text = "集めたタピオカ（個）：" + tapiocaNum;
                retryButton.SetActive(true);
            }
        }
    }

    public void StartButton()
    {
        startFlag = 1;
    }

    public void RetryButton()
    {
        startFlag = 0;
        countDown = 5.0f;
        timer = 20.0f;
        tapiocaNum = 0;
        fixFlag = 0;

        script.coroutineFlag = false;

        timerLabel.text = "空から降ってくるタピオカをコップで集めるゲーム";
        countLabel.text = "";

        startButton.SetActive(true);
        retryButton.SetActive(false);
    }
}
