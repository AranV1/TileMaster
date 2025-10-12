using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator anim;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        myRigidbody.linearVelocity = new Vector2(moveInput.x*moveSpeed, myRigidbody.linearVelocity.y); //myRigidbody.linearVelocity.y oznacza ze w osi y obiekt dziala
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
}
