using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GetData : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField] 
    private EnemyMovement enemyMovement;

    [SerializeField] 
    private GameObject[] playerGameObjects;

    [SerializeField] 
    private GameObject[] enemyGameObjects;

    [SerializeField] 
    private Image playerDistanceBarImage;
    [SerializeField]
    private Sprite[] playerSprites;

    [SerializeField] 
    private Image enemyDistanceBarImage;
    [SerializeField] 
    private Sprite[] enemySprites;
    
    [SerializeField] 
    private GameObject loadPanel;

    private float speedAirplane1 = 3;
    private float speedAirplane2 = 5;
    private float speedAirplane3 = 7;

    private float upgradeProcent1 = 14;
    private float upgradeProcent2 = 27;
    private float upgradeProcent3 = 10;

    private float easyEnemySpeed = 4.4f;
    private float mediumEnemySpeed = 7.4f;
    private float hardEnemySpeed = 10.4f;

    private float speed;
    private float walkingSpeed;

    private float enemyWalkingSpeed;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);
        
        SetEnemy();
        SetEnemyWalkingSpeed();
        SetAirplane();
        SetAirplaneDefaultSpeed();
        SetUpgrades();
        SetDistanceBarSpeed();

        yield return new WaitForSeconds(.2f);
        playerMovement.SetSpeed(speed);
        playerMovement.SetWalkingSpeed(walkingSpeed);
        enemyMovement.SetEnemyWalkingSpeed(enemyWalkingSpeed);
        loadPanel.SetActive(false);
        //Spawn first obstacle
        Debug.Log(speed);
    }

    private void SetAirplane()
    {
        switch (Data.Instance.GetSelectedAirplaneIndex())
        {
            case 0:
                playerGameObjects[0].SetActive(true);
                playerGameObjects[1].SetActive(false);
                playerGameObjects[2].SetActive(false);
                playerDistanceBarImage.sprite = playerSprites[0];
                break;
            case 1:
                playerGameObjects[0].SetActive(false);
                playerGameObjects[1].SetActive(true);
                playerGameObjects[2].SetActive(false);
                playerDistanceBarImage.sprite = playerSprites[1];
                break;
            case 2:
                playerGameObjects[0].SetActive(false);
                playerGameObjects[1].SetActive(false);
                playerGameObjects[2].SetActive(true);
                playerDistanceBarImage.sprite = playerSprites[2];
                break;
        }
    }

    private void SetAirplaneDefaultSpeed()
    {
        switch (Data.Instance.GetSelectedAirplaneIndex())
        {
            case 0:
                speed = speedAirplane1;
                break;
            case 1:
                speed = speedAirplane2;
                break;
            case 2:
                speed = speedAirplane3;
                break;
        }
    }

    private void SetUpgrades()
    {
        switch (Data.Instance.GetSelectedAirplaneIndex())
        {
            case 0:
                if (Data.Instance.IsPurchasedUpgrade(0))
                {
                    float newSpeed = speedAirplane1 * upgradeProcent1 / 100f;
                    speed += newSpeed;
                }
                if (Data.Instance.IsPurchasedUpgrade(1))
                {
                    float newSpeed = speedAirplane1 * upgradeProcent2 / 100f;
                    speed += newSpeed;
                }
                if (Data.Instance.IsPurchasedUpgrade(2))
                {
                    float newSpeed = speedAirplane1 * upgradeProcent3 / 100f;
                    speed += newSpeed;
                }
                break;
            case 1:
                if (Data.Instance.IsPurchasedUpgrade(0))
                {
                    float newSpeed = speedAirplane2 * upgradeProcent1 / 100f;
                    speed += newSpeed;
                }
                if (Data.Instance.IsPurchasedUpgrade(1))
                {
                    float newSpeed = speedAirplane2 * upgradeProcent2 / 100f;
                    speed += newSpeed;
                }
                if (Data.Instance.IsPurchasedUpgrade(2))
                {
                    float newSpeed = speedAirplane2 * upgradeProcent3 / 100f;
                    speed += newSpeed;
                }
                break;
            case 2:
                if (Data.Instance.IsPurchasedUpgrade(0))
                {
                    float newSpeed = speedAirplane3 * upgradeProcent1 / 100f;
                    speed += newSpeed;
                }
                if (Data.Instance.IsPurchasedUpgrade(1))
                {
                    float newSpeed = speedAirplane3 * upgradeProcent2 / 100f;
                    speed += newSpeed;
                }
                if (Data.Instance.IsPurchasedUpgrade(2))
                {
                    float newSpeed = speedAirplane3 * upgradeProcent3 / 100f;
                    speed += newSpeed;
                }
                break;
        }
    }

    private void SetDistanceBarSpeed()
    {
        walkingSpeed = speed / 100f;
    }

    private void SetEnemy()
    {
        int randomEnemy = Random.Range(0, 2);

        switch (randomEnemy)
        {
            case 0:
                enemyGameObjects[0].SetActive(true);
                enemyGameObjects[1].SetActive(false);
                enemyDistanceBarImage.sprite = enemySprites[0];
                break;
            case 1:
                enemyGameObjects[0].SetActive(false);
                enemyGameObjects[1].SetActive(true);
                enemyDistanceBarImage.sprite = enemySprites[1];
                break;
            case 2:
                enemyGameObjects[0].SetActive(true);
                enemyGameObjects[1].SetActive(false);
                enemyDistanceBarImage.sprite = enemySprites[0];
                break;
        }
    }

    private void SetEnemyWalkingSpeed()
    {
        switch (Data.Instance.GetDifficultyIndex())
        {
            case 0:
                enemyWalkingSpeed = easyEnemySpeed / 100f;
                break;
            case 1:
                enemyWalkingSpeed = mediumEnemySpeed / 100f;
                break;
            case 2:
                enemyWalkingSpeed = hardEnemySpeed / 100f;
                break;
        }
    }
}
