using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float currentDistance;
    private float walkingSpeed;
    private float maxWalkingDistance = 800f;

    [SerializeField] 
    private DistanceBar distanceBar;
    
    private void FixedUpdate()
    {
        currentDistance += walkingSpeed;
        distanceBar.SetWalkingDistance(walkingSpeed);

        if (currentDistance >= maxWalkingDistance)
        {
            GameManager.Instance.WinGame();
        }
    }

    public void SetEnemyWalkingSpeed(float walkingSpeed)
    {
        this.walkingSpeed = walkingSpeed;
    }
}
