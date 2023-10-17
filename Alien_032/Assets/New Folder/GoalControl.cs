

// GoalControl.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GoalControl : MonoBehaviour
{
    // �浹�ߴ°�(true), �浹���� �ʾҴ°�(false)�� ��Ÿ����.
    private bool is_collided = false;

    public float GOAL_MIN = 5.0f; // �ּڰ�
    public float GOAL_MAX = 10.0f; // �ִ�

    void Start()
    {
        // GOAL_MIN~GOAL_MAX ������ ������ ���� �����´�.
        float rnd = Random.Range(GOAL_MIN, GOAL_MAX);
        // Goal�� X��ġ�� ������ ������
        this.transform.position = new Vector3(rnd, -1.0f, 0.0f);
    }
    // �ٸ� GameObject�� �浹�ϴ� ���� ��� ȣ��
    void OnCollisionStay(Collision other)
    {
        this.is_collided = true;
    }
    void OnGUI()
    {
        if (is_collided)
        { // �浹������
          // ȭ�鿡 '����'�̶�� ǥ��
            GUI.Label(new Rect(Screen.width / 2, 80, 100, 40), "����");
        }
    }
}