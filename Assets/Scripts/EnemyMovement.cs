using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidbody;
    BoxCollider2D boxCl;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        boxCl = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        myRigidbody.linearVelocity = new Vector2(moveSpeed, 0);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.linearVelocity.x)), 1f);
    }
}
