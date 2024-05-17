using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D rigidbody;
    
    [SerializeField]
    private float speed = 3f;
    
    private bool isMove;

    private Vector2 moveDirection;

    private void FixedUpdate()
    {
        if (ControlManager.Instance.IsClassicControl())
        {
            if (isMove)
            {
                rigidbody.velocity = moveDirection;
            }
            else
            {
                rigidbody.velocity = new Vector2(0, 0);
            }
        }

        if (ControlManager.Instance.IsExpertControl())
        {
            if (isMove)
            {
                rigidbody.velocity = moveDirection;
            }
            else
            {
                rigidbody.velocity = new Vector2(Input.acceleration.x * speed, 0);
            }
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void ActivateBoostSpeed()
    {
        StartCoroutine(BoostSpeedCO());
    }

    private IEnumerator BoostSpeedCO()
    {
        float currentSpeed = speed;
        speed += 2f;

        yield return new WaitForSeconds(3f);

        speed = currentSpeed;

    }

    #region ButtonsAction

    public void ResetMove()
    {
        isMove = false;
    }

    public void MovePlayerUp()
    {
        isMove = true;
        moveDirection = new Vector2(rigidbody.velocity.x, speed);
    }

    public void MovePlayerDown()
    {
        isMove = true;
        moveDirection = new Vector2(rigidbody.velocity.x, -speed);
    }

    public void MovePlayerLeft()
    {
        isMove = true;
        moveDirection = new Vector2(-speed, rigidbody.velocity.y);
    }

    public void MovePlayerRight()
    {
        isMove = true;
        moveDirection = new Vector2(speed, rigidbody.velocity.y);
    }
    
    public void MovePlayerUpAccelerometer()
    {
        isMove = true;
        moveDirection = new Vector2(Input.acceleration.x * speed, speed);
    }
    
    public void MovePlayerDownAccelerometer()
    {
        isMove = true;
        moveDirection = new Vector2(Input.acceleration.x * speed, -speed);
    }

    #endregion
}
