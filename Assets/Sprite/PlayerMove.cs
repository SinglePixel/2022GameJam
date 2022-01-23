using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;

    public float speed, jumpForce;
    private float horizontalMove;//��ȡ���̲���
    public Transform groundCheck;
    public Transform debuffCheck;
    public LayerMask ground;//��⣨���棩ͼ��
    public LayerMask debuff;//��⣨����Ч��ƽ̨��
    GameObject bottomLine;//�����������Ʒ
    public Transform BirthPoint;

    [Header("Dash����")]
    public float dashTime;//dashʱ��
    private float dashTimeLeft;//dashʣ��ʱ��
    private float lastDash = -10f;//�ϴ�dataʱ���
    public float dashCoolDown;//data��ȴʱ��
    public float dashSpeed;//dash�ٶ�


    public bool isGround, isJump, isDashing,isDebuff,isBuff;//������
    bool jumpPressed;
    int jumpCount;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        bottomLine = GameObject.Find("BottomLine");

    }


    void Update()
    {
        DebuffDer();
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (Time.time >= (lastDash + dashCoolDown))
            {
                //����ִ��dash
                ReadyToDash();
            }
        }
        
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);//������
        isDebuff = Physics2D.OverlapCircle(groundCheck.position, 0.5f, debuff);//��⸺��Ч��
        Dash();
        if (isDashing)
            return;

        GroundMovement();
        Jump();
        SwitchAnim();//���ƶ���
    }

    void GroundMovement()
    {
        if (Objectpool.instance.isFinish)
        {
       horizontalMove = Input.GetAxisRaw("Horizontal");//ֻ����-1��0��1
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
        }
        }
        if (transform.position.y <= bottomLine.transform.position.y)
        {
            transform.position = BirthPoint.position;
        }


    }

    void Jump()//��Ծ
    {
        if (isGround && Objectpool.instance.isFinish)
        {
            jumpCount = 2;//����Ծ����
            isJump = false;
        }
        if (jumpPressed && isGround)
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
        else if (jumpPressed && jumpCount > 0 && isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
    }
    //д������λ��

    void ReadyToDash()//����ִ��dash����
    {
        isDashing = true;

        dashTimeLeft = dashTime;

        lastDash = Time.time;

    }

    void Dash()//��̷���
    {
        if (isDashing&&Objectpool.instance.isFinish)
        {
            if (dashTimeLeft > 0)
            {
                if (rb.velocity.y > 0 && !isGround)
                {
                    rb.velocity = new Vector2(dashSpeed * horizontalMove, jumpForce);
                }
                rb.velocity = new Vector2(dashSpeed * horizontalMove, rb.velocity.y);
                dashTimeLeft -= Time.deltaTime;
                Objectpool.instance.GetFormPool();
            }
            if (dashTimeLeft <= 0)
            {
                isDashing = false;
                if (!isGround)
                {
                    rb.velocity = new Vector2(dashSpeed * horizontalMove, jumpForce);
                }
            }
        }

    }
    void SwitchAnim()//�����л�
    {
        anim.SetFloat("running", Mathf.Abs(rb.velocity.x));

       // if (isGround)
      //  {
           // anim.SetBool("falling", false);
        //}
        //else if (!isGround && rb.velocity.y > 0)
       // {
        //    anim.SetBool("jumping", true);
        //}
       // else if (rb.velocity.y < 0)
        //{
          //  anim.SetBool("jumping", false);
          //  anim.SetBool("falling", true);
       // }
    }
    //��ҳ�Debuff
    void DebuffDer()//ִ�з���
    {
        if (isDebuff)
        {
            speed = 2f;
            jumpForce = 8f;
            isDashing = false;
        }
        else
        {
            speed=10f;
            jumpForce = 13f;
            //isDashing = true;
        }
    }


}