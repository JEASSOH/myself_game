using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;


    Vector3 moveVec;

    Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

     

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        moveVec = new Vector3(hAxis, 0, 0);

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVec = Vector3.left;

            transform.localScale = new Vector3(-1, 1, 1);
            //X�� �������� -1�� �־� �¿����
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVec = Vector3.right;

            transform.localScale = new Vector3(1, 1, 1);
            //X�� �������� 1�� �־� �ٽ� ����ġ 
        }

        moveVec = new Vector3(hAxis,0, 0);
        transform.position += moveVec * speed * Time.deltaTime;
        anim.SetBool("isRun", moveVec != Vector3.zero);
    }
}

