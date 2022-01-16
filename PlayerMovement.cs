using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Movement")]
    public float speed = 2000;
    public float maximumSpeed = 10f;
    public Vector3 velocity;
    public float magnitude;
    [Space(10)]
    public float turnAroundCut = 5f;
    public float turnFactor = 3000f;

    [Header("Jumping")]
    public float jumpForce = 75000f;
    public float jumpCooldown = 0.3f;
    public LayerMask whatIsGround;
    public float walljumpForceSameWay = 50000f;
    public float walljumpForceOtherWay = 10000f;
    public bool grounded;
    public bool walljumpL;
    public bool walljumpR;
    public bool readyToJump = true;

    [Header("Turning")]
    public bool facingRight;
    public GameObject gun;
    public GameObject slash;

    public bool cum;


    void FixedUpdate()
    {
        movement();
    }

    #region movement
    void movement()
    {

        #region Add forces

        bool jumping = Input.GetButton("Jump");
        float inputX = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(speed * inputX, 0);

        if (grounded && readyToJump && jumping)
        {
            grounded = false;
            readyToJump = false;
            Invoke(nameof(ResetJump), jumpCooldown);
            if (walljumpL)
            {
                movement.x = inputX < -0.1f ? -walljumpForceSameWay : -walljumpForceOtherWay;
                walljumpL = false;
            }
            if (walljumpR)
            {
                movement.x = inputX > 0.1f ? walljumpForceSameWay : walljumpForceOtherWay;
                walljumpR = false;
            }
            movement.y = jumpForce;
        }



        #region limit velocity
        velocity = rb.velocity;
        magnitude = System.Math.Abs(velocity.x);

        if (magnitude > maximumSpeed)
        {
            float brakeSpeed = magnitude - maximumSpeed;

            Vector3 normalisedVelocity = velocity.normalized;
            float BrakeForce = normalisedVelocity.x * brakeSpeed;

            movement.x = BrakeForce;
        }
        #endregion

        #region turn around faster
        if (turnAroundCut < velocity.x && inputX < 0)
        {
            float turnSpeed = velocity.x * turnFactor;
            movement.x -= turnSpeed;
        }

        if (-turnAroundCut > velocity.x && inputX > 0)
        {
            float turnSpeed = velocity.x * turnFactor;
            movement.x -= turnSpeed;
        }
        #endregion

        movement *= Time.deltaTime;
        rb.AddForce(movement);

        #endregion

        #region check for flip

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x && !facingRight)
        {
            flip();
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x && facingRight)
        {
            flip();
        }

        #endregion
    }

    private void OnCollisionStay2D(Collision2D other)
    {

        if (other.gameObject.layer == 8 || other.gameObject.layer == 9 && !grounded)
        {
            grounded = true;
            Vector2 point = other.contacts[0].point;
            Vector2 direction = other.GetContact(0).normal;
            if (direction.x == 1) walljumpR = true;
            if (direction.x == -1) walljumpL = true;
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9 && grounded)
        {
            grounded = false;
            walljumpL = false;
            walljumpR = false;
        }

    }

    private void ResetJump() { readyToJump = true; }

    #endregion

    void flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
        gun.transform.Rotate(0f, 180f, 0f);
        slash.transform.Rotate(180f, 0f, 0f);
    }

}