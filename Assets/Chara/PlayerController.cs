using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    private Animator myAnimator;

    //�ړ�������R���|�[�l���g������
    private Rigidbody2D myRigidbody;

    //�ړ��ʁi�萔�j
    private float VELOCITY = 2.5f;

    //�W�����v�ʁi�萔�j
    private float JUMPPOWER = 4.0f;

    //�n��
    private bool isGround = false;
    //���n�ł��郌�C���[
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        //�A�j���[�^�R���|�[�l���g���擾
        this.myAnimator = GetComponent<Animator>();

        //Rigidbody�R���|�[�l���g���擾
        this.myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //�W�����v
            if (Input.GetKey(KeyCode.Space) && isGround)
            {
                //���ړ��{�W�����v
                this.myRigidbody.velocity = new Vector2(-VELOCITY, JUMPPOWER);
            }
            else
            {
                myAnimator.SetBool("Run", true);

                //���ړ�
                this.myRigidbody.velocity = new Vector2(-VELOCITY, this.myRigidbody.velocity.y);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //�W�����v
            if (Input.GetKey(KeyCode.Space) && isGround)
            {
                //�E�ړ��{�W�����v
                this.myRigidbody.velocity = new Vector2(VELOCITY, JUMPPOWER);
            }
            else
            {
                myAnimator.SetBool("Run", true);

                //�E�ړ�
                this.myRigidbody.velocity = new Vector2(VELOCITY, this.myRigidbody.velocity.y);
            }
        }
        else
        {
            myAnimator.SetBool("Run", false);

            //�W�����v
            if (Input.GetKey(KeyCode.Space) && isGround)
            {
                //�����W�����v
                this.myRigidbody.velocity = new Vector2(0.0f, JUMPPOWER);
            }
        }

        //Debug.Log("velocity: " + this.myRigidbody.velocity.y);
        //Debug.Log("Ground: " + isGround); 

        this.myAnimator.SetFloat("Jump", this.myRigidbody.velocity.y);
        this.myAnimator.SetBool("Ground", isGround);

        //�R���C�_�[��OFF/ON�̃T���v��
        //this.GetComponent<BoxCollider2D>().enabled = false;
        //this.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void FixedUpdate()
    {
        //�n�㔻��
        isGround = Physics2D.Linecast(transform.position, transform.position - (transform.up * 0.1f), groundLayer);
    }
}
