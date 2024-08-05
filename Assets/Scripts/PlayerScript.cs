using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float slideSpeed = 4.0f;

    public GameObject GameManager;
    public GameObject Straw;

    GameScript script;

    private Rigidbody _rigidbody;

    void Start()
    {
        script = GameManager.GetComponent<GameScript>();
        _rigidbody = Straw.GetComponent<Rigidbody>();
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
    void FixedUpdate()
    {
        if (script.startFlag == 0 && script.fixFlag == 0)
        {
            Transform mugTransform = this.transform;
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

            script.fixFlag = 1;
        }
    }
}
