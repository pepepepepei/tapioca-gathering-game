using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float slideSpeed = 4.0f;

    public GameObject GameManager;
    public GameObject Straw;

    GameScript script;

    void Start()
    {
        script = GameManager.GetComponent<GameScript>();
    }

    void Update()
    {
        float pos_x = transform.position.x;

        if (Input.GetKey(KeyCode.LeftArrow))
            if (pos_x > -8)
                transform.position += Vector3.left * slideSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
            if (pos_x < 8)
                transform.position += Vector3.right * slideSpeed * Time.deltaTime;

    }
}
