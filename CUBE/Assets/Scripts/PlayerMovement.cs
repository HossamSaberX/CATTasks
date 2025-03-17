using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rg;
    public float forwardForce = 1500f;
    public float sidewaysForce = 1000f;
    public float speedIncreaseFactor = 0.001f;

    private bool moveRight = false;
    private bool moveLeft = false;

    void Update()
    {
        moveRight = Input.GetKey(KeyCode.D);
        moveLeft = Input.GetKey(KeyCode.A);
    }

    void FixedUpdate()
    {
        float difficultyMultiplier = 1 + (transform.position.z * speedIncreaseFactor);
        float effectiveForwardForce = forwardForce * difficultyMultiplier;
        rg.AddForce(0, 0, effectiveForwardForce * Time.deltaTime);

        if (moveRight)
            rg.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        if (moveLeft)
            rg.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (rg.position.y <= -2)
            FindFirstObjectByType<GameManager>().GameOver();
    }
}
