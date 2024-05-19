using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    private float speed;
    private float currentDistance;
    private float walkingSpeed;
    private float maxWalkingDistance = 800f;

    private int randomSpot;

    [SerializeField] 
    private Transform[] moveSpot;

    [SerializeField] 
    private DistanceBar distanceBar;

    private void Start()
    {
        randomSpot = Random.Range(0, moveSpot.Length);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot[randomSpot].localPosition,
            speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot[randomSpot].localPosition) < .2f)
        {
            randomSpot = Random.Range(0, moveSpot.Length);
        }
    }

    private void FixedUpdate()
    {
        currentDistance += walkingSpeed;
        distanceBar.SetWalkingDistance(walkingSpeed);

        if (currentDistance >= maxWalkingDistance)
        {
            GameManager.Instance.WinGame();
        }
    }

    public void SetEnemyWalkingSpeed(float speed, float walkingSpeed)
    {
        this.speed = speed;
        this.walkingSpeed = walkingSpeed;
    }
}
