using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject itemToSpawn;
    public Transform spawnPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnItemAndDestroyBox();
        }
    }

    private void SpawnItemAndDestroyBox()
    {
        Instantiate(itemToSpawn, spawnPoint.position, Quaternion.identity);

        Destroy(gameObject);
    }
}

