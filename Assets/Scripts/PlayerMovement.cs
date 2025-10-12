using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Vector2 moveInput;
    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        myRigidbody.linearVelocity = new Vector2(moveInput.x*moveSpeed, myRigidbody.linearVelocity.y); //myRigidbody.linearVelocity.y oznacza ze w osi y obiekt dziala
                                                                                                       //zgodnie z fizyka (np grawitacja)

    }
}
