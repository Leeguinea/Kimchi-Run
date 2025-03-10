using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]

    public float JumpForce;

    [Header("References")]
    public Rigidbody2D PlayerRigidBody;

    public Animator PlayerAnimator;


    public BoxCollider2D PlayerCollider;

    private bool isGrounded = true; //땅에서 시작
    public bool isInvincible = false; //invincible: 무적의



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //플레이어가 점프할 때 받는 힘
            PlayerRigidBody.AddForceY(JumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            //점프 애니메이션
            PlayerAnimator.SetInteger("State", 1);
        }
    }


    public void KillPlayer()
    {
        PlayerCollider.enabled = false;
        PlayerAnimator.enabled = false;
        PlayerRigidBody.AddForceY(JumpForce, ForceMode2D.Impulse);
    }

    void Hit()
    {
        GameManager.Instance.Lives -= 1;
    }

    void Heal()
    {
        GameManager.Instance.Lives = Mathf.Min(3, GameManager.Instance.Lives + 1); //lives + 1의 값의 최대값이 3이 된다는 뜻.
    }

    void StartInvincible()
    {
        isInvincible = true;
        Invoke("StopInvincible", 5f); //지연
    }

    void StopInvincible()
    {
        isInvincible = false;
    }


    //유니티에서 제공하는 메소드 MonoBeviour.OnCollisionEnter2D(Collision2D)
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.name == "Platform")
        {
            //플랫폼에 닿을 때가 게임이 시작할 때, 착지할 때이기 때문에 착지할 때만
            //애니메이션이 실행될 수 있게 조건을 넣음.
            if(!isGrounded) 
            {
                PlayerAnimator.SetInteger("State", 2);
            }
            isGrounded = true;
            //땅에 착지할 때 애니메이션
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "enemy")
        {
            if(!isInvincible)
            {
                Destroy(collider.gameObject);
                Hit();
            }
           
        }
        else if(collider.gameObject.tag == "food")
        {
            Destroy(collider.gameObject);
            Heal();
        }
        else if(collider.gameObject.tag == "golden")
        {
            Destroy(collider.gameObject);
            StartInvincible();
        }
    }

}
