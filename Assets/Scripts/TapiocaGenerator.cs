using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapiocaGenerator : MonoBehaviour
{
    public GameObject tapioca;
    public GameObject GameManager;

    GameScript script;

    public float coroutineFlag = 0;

    void Start()
    {
        script = GameManager.GetComponent<GameScript>();
    }

    void Update()
    {
        if (script.countDown <= 0.0f)
        {
            if (coroutineFlag == 0 && script.timer > 0.0f)
            {
                StartCoroutine("Generator");
                coroutineFlag = 1;
            }
            else if (script.timer <= 0.0f)
            {
                StopCoroutine("Generator");
            }
        }
    }

    IEnumerator Generator()
    {
        while (true)
        {
            int rand = Random.Range(-9, 10);
            script.timer -= Time.deltaTime;
            Instantiate(tapioca, new Vector3(rand, 7, 0), tapioca.gameObject.transform.rotation);

            yield return new WaitForSeconds(0.09f);
            yield return null;
        }
    }
}