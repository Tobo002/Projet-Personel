using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2000;
    
    bool grounded;
    bool readyToJump = true;
    public LayerMask whatIsGround;
    public float jumpForce = 75000f;
    public float jumpCooldown = 0.3f;
    public float maximumSpeed = 10f;
    public float turnAroundCut = 5f;
    public float turnFactor = 2000f;
    public Rigidbody2D rb;

    public bool facingRight;
    public GameObject gun;

    Vector3 velocity;
    float magnitude;

    void FixedUpdate()
	{
        movement();
    }

    #region movement
    void movement() {

        #region Add forces

        bool jumping = Input.GetButton("Jump");
        float inputX = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(speed * inputX, 0);

        velocity = rb.velocity;
        magnitude = Vector3.Magnitude(rb.velocity);

        if (grounded && readyToJump && jumping)
        {
            grounded = false;
            readyToJump = false;
            Invoke(nameof(ResetJump), jumpCooldown);
            movement.y = jumpForce;
        }

        #region limit velocity
        if (magnitude > maximumSpeed)

        {
            float brakeSpeed = magnitude - maximumSpeed;

            Vector3 normalisedVelocity = rb.velocity.normalized;
            float brakeVelocity = normalisedVelocity.x * brakeSpeed;

            movement.x = brakeVelocity;
        }
        #endregion

        #region turn around faster
        if (turnAroundCut < velocity.x && inputX < 0)
        {
            float turnSpeed = rb.velocity.x * turnFactor;
            movement.x -= turnSpeed;
        }

        if (-turnAroundCut > velocity.x && inputX > 0)
        {
            float turnSpeed = rb.velocity.x * turnFactor;
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
		}

    }

    private void OnCollisionExit2D(Collision2D other)
	{
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9 && grounded)
        {
            grounded = false;
        }

    }

    private void ResetJump() { readyToJump = true; }

    #endregion

    void flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
        gun.transform.Rotate(0f, 180f, 0f);
    }

}