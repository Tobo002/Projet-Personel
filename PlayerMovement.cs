using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);
    
    public bool grounded;
    public bool readyToJump = true;
    public LayerMask whatIsGround;
    public float jumpForce = 1000f;
    public float jumpCooldown = 0.5f;
    public float maximumSpeed = 10f;
    public float turnAroundCut = 5f;
    public float turnFactor = 2f;
    public Rigidbody2D rb;

    public Vector3 velocity;
    public float magnitude;

    void FixedUpdate()
	{
        #region movement

        bool jumping = Input.GetButton("Jump");
        float inputX = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(speed.x * inputX, 0);

        /*velocity = rb.velocity;
        magnitude = Vector3.Magnitude(rb.velocity);

        if (grounded && readyToJump && jumping)
        {
            grounded = false;
            readyToJump = false;
            Invoke(nameof(ResetJump), jumpCooldown);
            //rb.AddForce(Vector2.up * jumpForce);
            movement.y = jumpForce;
        }*/

        #region limit velocity
        /*if (magnitude > maximumSpeed)

        {
            float brakeSpeed = magnitude - maximumSpeed;

            Vector3 normalisedVelocity = rb.velocity.normalized;
            float brakeVelocity = normalisedVelocity.x * brakeSpeed;

            movement.x = brakeVelocity;
        }*/
        #endregion

        #region turn around faster
        /*if (turnAroundCut < velocity.x && inputX < 0)
        {
            Debug.Log("Left");
            float turnSpeed = rb.velocity.x * turnFactor;
            movement.x -= turnSpeed;
        }

        if (-turnAroundCut > velocity.x && inputX > 0)
        {
            Debug.Log("Right");
            float turnSpeed = rb.velocity.x * turnFactor;
            movement.x += turnSpeed;
        }*/
        #endregion

        movement *= Time.deltaTime;
        rb.AddForce(movement);

        #endregion
    }

    private void OnCollisionStay2D(Collision2D other)
	{

        if (other.gameObject.layer == 8 && !grounded)
		{
            grounded = true;
            Debug.Log("Bing");
		}

    }

    private void OnCollisionExit2D(Collision2D other)
	{
        if (other.gameObject.layer == 8 && grounded)
        {
            grounded = false;
            Debug.Log("Bong");
        }

    }

    private void ResetJump() { readyToJump = true; }
}