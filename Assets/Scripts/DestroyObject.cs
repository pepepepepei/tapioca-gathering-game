using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject GameManager;

    GameScript script;

    void Start()
    {
        script = GameManager.GetComponent<GameScript>();

    }
    void Update()
    {
        if (this.gameObject.transform.position.y <= -5.0f)
            Destroy(this.gameObject);

        if (script.startFlag == 0 && this.gameObject.transform.position.y <= -1)
            Destroy(this.gameObject);

    }
}
