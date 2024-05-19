using UnityEngine;

public class TemplateMovement : MonoBehaviour
{
    private Transform destroyPosition;
    private Transform spawnPosition;

    private float speed;

    private bool newSpawn = false;

    public void SpawnTemplate(float speed, Transform destroyPosition, Transform spawnPosition)
    {
        this.speed = speed;
        this.spawnPosition = spawnPosition;
        this.destroyPosition = destroyPosition;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            destroyPosition.localPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, spawnPosition.localPosition) < .2f && !newSpawn)
        {
            newSpawn = true;
            TemplateSpawner.Instance.SpawnTemplate();
        }
        
        if(Vector2.Distance(transform.position, destroyPosition.localPosition) < .2f)
        {
            Destroy(this.gameObject);
        }
    }
}
