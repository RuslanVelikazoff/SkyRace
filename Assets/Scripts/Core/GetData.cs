using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GetData : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;
    
    [SerializeField] 
    private GameObject[] airplaneSprite;

    [SerializeField] 
    private GameObject[] enemySprite;
    
    [SerializeField] 
    private GameObject loadPanel;

    private float speedAirplane1 = 3;
    private float speedAirplane2 = 5;
    private float speedAirplane3 = 7;

    private float upgradeProcent1 = 14;
    private float upgradeProcent2 = 27;
    private float upgradeProcent3 = 10;

    private float speed;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);
        
        SetEnemy();
        SetAirplane();
        SetAirplaneDefaultSpeed();
        SetUpgrades();

        yield return new WaitForSeconds(.2f);
        playerMovement.SetSpeed(speed);
        loadPanel.SetActive(false);
        //Spawn first obstacle
    }

    private void SetAirplane()
    {
        switch (Data.Instance.GetSelectedAirplaneIndex())
        {
            case 0:
                airplaneSprite[0].SetActive(true);
                airplaneSprite[1].SetActive(false);
                airplaneSprite[2].SetActive(false);
                break;
            case 1:
                airplaneSprite[0].SetActive(false);
                airplaneSprite[1].SetActive(true);
                airplaneSprite[2].SetActive(false);
                break;
            case 2:
                airplaneSprite[0].SetActive(false);
                airplaneSprite[1].SetActive(false);
                airplaneSprite[2].SetActive(true);
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

    private void SetEnemy()
    {
        int randomEnemy = Random.Range(0, 2);

        switch (randomEnemy)
        {
            case 0:
                enemySprite[0].SetActive(true);
                enemySprite[1].SetActive(false);
                break;
            case 1:
                enemySprite[0].SetActive(false);
                enemySprite[1].SetActive(true);
                break;
            case 2:
                enemySprite[0].SetActive(true);
                enemySprite[1].SetActive(false);
                break;
        }
    }
}
