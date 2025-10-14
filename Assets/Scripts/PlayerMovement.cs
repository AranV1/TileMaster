using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;


    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator anim;
    CapsuleCollider2D capsuleCl;
    float gravityScaleAtStart;

    void Start()
    {
        capsuleCl = GetComponent<CapsuleCollider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gravityScaleAtStart = myRigidbody.gravityScale;
    }
    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!capsuleCl.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; } //sprawdza czy gracz stoi na ziemi
        if (value.isPressed)
        {
            myRigidbody.linearVelocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {
        myRigidbody.linearVelocity = new Vector2(moveInput.x * moveSpeed, myRigidbody.linearVelocity.y); //myRigidbody.linearVelocity.y oznacza ze w osi y obiekt dziala
                                                                                                         //zgodnie z fizyka (np grawitacja)
        anim.SetBool("isRunning", Mathf.Abs(myRigidbody.linearVelocity.x) > Mathf.Epsilon);

    }

    void FlipSprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(myRigidbody.linearVelocity.x) > Mathf.Epsilon; //Epsilon to bardzo mala liczba bliska 0
        if (hasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.linearVelocity.x), 1f);
        }
    }

    void ClimbLadder()
    {
        if (!capsuleCl.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            myRigidbody.gravityScale = gravityScaleAtStart;
            return;
        }
        anim.SetBool("isClimbing", Mathf.Abs(myRigidbody.linearVelocity.y) > Mathf.Epsilon);
        myRigidbody.gravityScale = 0f;
        myRigidbody.linearVelocity = new Vector2(myRigidbody.linearVelocity.x, moveInput.y * climbSpeed);
    }
}
