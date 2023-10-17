 // PlayerControl.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour
{

    bool isJump;
    private float power;
    public float POWERPLUS = 300.0f;
    private AudioSource audio;
    Animator anim;
    public AudioClip jumpSound;
    public AudioClip jumpSound2;

    // Start is called before the first frame update
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.jumpSound;
        this.audio.loop = false;
    }

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
       

        if (Input.GetKey(KeyCode.Space) && !isJump)
        { // ���� ��ư�� �����ִ� ����
            power += POWERPLUS * Time.deltaTime; // ���� ����
            this.audio.PlayOneShot(this.jumpSound);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        { // ���� ��ư�� ������
          // ������ ���� x�� y�� �ݿ��ؼ� ������ ���� ����!
            this.audio.Stop();
            this.audio.PlayOneShot(this.jumpSound2);
            this.audio.PlayOneShot(this.jumpSound2);
            this.audio.PlayOneShot(this.jumpSound2);
            this.audio.PlayOneShot(this.jumpSound2);
            this.audio.PlayOneShot(this.jumpSound2);
            
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, power, 0));
            
            power = 0.0f; // ���� 0����

        }


        

        // ���麸�� �Ʒ�(-5.0f)�� ��������
        if (this.transform.position.y < -5.0f)
        {
            SceneManager.LoadScene("Main"); // ���� �ٽ� �ε�
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);
            isJump = false;


        }
    }
}