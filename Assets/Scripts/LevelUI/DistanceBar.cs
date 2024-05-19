using UnityEngine;
using UnityEngine.UI;

public class DistanceBar : MonoBehaviour
{
    [SerializeField] 
    private Slider distanceSlider;

    private float currentDistance = 0;

    public void SetWalkingDistance(float walkingDistance)
    {
        currentDistance += walkingDistance;
        distanceSlider.value = currentDistance;
    }
}
