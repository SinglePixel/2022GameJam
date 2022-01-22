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
    public LayerMask ground;

    [Header("Dash����")]
    public float dashTime;//dashʱ��
    private float dashTimeLeft;//dashʣ��ʱ��
    private float lastDash = -10f;//�ϴ�dataʱ���
    public float dashCoolDown;//data��ȴʱ��
    public float dashSpeed;//dash�ٶ�


    public bool isGround, isJump, isDashing;//������
    bool jumpPressed;
    int jumpCount;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();

    }


    void Update()
    {

        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
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
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
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
}