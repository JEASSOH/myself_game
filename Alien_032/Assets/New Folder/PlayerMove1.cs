using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove1 : MonoBehaviour
{
    Rigidbody rigid;
    public float moveSpeed = 5f; // �̵� �ӵ� ����
    public float rotationSpeed = 360f; // ȸ�� �ӵ� ����
    CharacterController characterController;
    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        // �¿� ����Ű�� ���� ����Ű�� �������� �Ǻ�
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp( // �޼ҵ带 ������ �÷��̾��� ���� ��ȯ
            transform.forward,
            direction,
            rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
            );
            
            transform.LookAt(transform.position + forward);
        }
        Jump();

        // Move()�� �̿��� �̵�, �浹 ó��, �ӵ� �� ��� ����
        characterController.Move(direction * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector3.up * 8, ForceMode.Impulse);
        }

    }
}
