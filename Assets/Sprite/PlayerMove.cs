using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;

    public float speed, jumpForce;
    private float horizontalMove;//获取键盘参数
    public Transform groundCheck;
    public Transform debuffCheck;
    public Transform buffCheck;
    public Transform xieshenCheck;
    public LayerMask ground;//检测（地面）图层
    public LayerMask debuff;//检测（负面效果平台）
    public LayerMask buff;//检测（负面效果平台）
    public LayerMask xieshneg;//检测邪神
    GameObject bottomLine;//检测返回出生点的位置
    public Transform BirthPoint;//出生点位置记录
    public Transform BirthPoint1;
    public Transform BirthPoint2;
    public Transform BirthPoint3;
    private bool Stage=true;//记录玩家到出生复活存档点
    private bool Stage1 = false;//记录玩家到出生复活存档点
    private bool Stage2 = false;//记录玩家到出生复活存档点
    private bool Stage3 = false;//记录玩家到到终点状态




    [Header("Dash参数")]
    private float dashTime;//dash时间
    private float dashTimeLeft;//dash剩余时间
    private float lastDash = -10f;//上次data时间点
    public float dashCoolDown;//data冷却时间
    public float dashSpeed;//dash速度


    public bool isGround, isJump, isDashing,isDebuff,isBuff,isxieshn;//检测参数
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
        Youxishengli();//游戏结束检测
        xieshengff();
        DebuffDer();
        BuffDer();
        BirthPointFi();
        BirthPointBox();
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (Time.time >= (lastDash + dashCoolDown))
            {
                //可以执行dash
                ReadyToDash();
            }
        }
        
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);//检测地面
        isDebuff = Physics2D.OverlapCircle(debuffCheck.position, 0.5f, debuff);//检测负面效果
        isBuff = Physics2D.OverlapCircle(buffCheck.position, 0.5f, buff);//检测正面效果
        isxieshn = Physics2D.OverlapCircle(xieshenCheck.position, 0.5f, xieshneg);
        Dash();
        if (isDashing)
            return;

        GroundMovement();
        Jump();
        SwitchAnim();//控制动画
    }

    void GroundMovement()
    {
        if (Objectpool.instance.isFinish)
        {
       horizontalMove = Input.GetAxisRaw("Horizontal");//只返回-1，0，1
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
        }
        }
//


    }

    void Jump()//跳跃
    {
        if (isGround && Objectpool.instance.isFinish)
        {
            jumpCount = 2;//可跳跃数量
            isJump = false;
        }
        if (jumpPressed && isGround)
        {

            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
            dashTime = 0.2f;
        }
        else if (jumpPressed && jumpCount > 0 && isJump)
        {
            

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
            dashTime = 0.2f;
        }
    }
    //写动画的位置

    void ReadyToDash()//可以执行dash方法
    {
        isDashing = true;

        dashTimeLeft = dashTime;

        lastDash = Time.time;

    }

    void Dash()//冲刺方法
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
    void SwitchAnim()//动画切换
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
    //玩家吃Debuff
    void DebuffDer()//执行方法
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
    void BuffDer()
    {
        if (isBuff)
        {
            dashTime = 0.9f;
        }

    }




    //玩家回去出生地方法
    void BirthPointFi()
    {
        if (transform.position.y <= bottomLine.transform.position.y&& Stage)
        {
            transform.position = BirthPoint.position;
        }
        if (transform.position.y <= bottomLine.transform.position.y && Stage1)
        {
            transform.position = BirthPoint1.position;
        }
        if (transform.position.y <= bottomLine.transform.position.y && Stage2)
        {
            transform.position = BirthPoint2.position;
        }
        if (transform.position.y <= bottomLine.transform.position.y && Stage3)
        {
            transform.position = BirthPoint3.position;
        }
    }
    //出生地存档碰撞检测
    void BirthPointBox(){
        if (transform.position.x >= BirthPoint1.transform.position.x)
        {
            Stage = false;
            Stage1 = true;
            
        }
        if (transform.position.x >= BirthPoint2.transform.position.x)
        {
            Stage = false;
            Stage1 = false;
            
            Stage2 = true;
        }
        if (transform.position.x >= BirthPoint3.transform.position.x)
        {
            Stage1 = false;
            Stage = false;
            Stage2 = false;
            Stage3 = true;
            Objectpool.instance.issli = true;
        }
    }

    void xieshengff()//检测邪神
    {
        if (isxieshn)
        {
            Objectpool.instance.isFinish = false;
        }
    }


    void Youxishengli()//游戏结束
    {
        if (Objectpool.instance.issli == true)
        {
        SceneManager.LoadScene(4);
        }
        
    }



}