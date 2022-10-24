using UnityEngine;


public class items : MonoBehaviour
{
    public ItemToSpawn[] itemToSpawn;

    void Start()
    {

        for (int i = 0; i < itemToSpawn.Length; i++)
        {

            if (i == 0)
            {

                itemToSpawn[i].minSpawnProb = 0;
                itemToSpawn[i].maxSpawnProb = itemToSpawn[i].spawnRate - 1;
            }
            else
            {
                itemToSpawn[i].minSpawnProb = itemToSpawn[i - 1].maxSpawnProb + 1;
                itemToSpawn[i].maxSpawnProb = itemToSpawn[i].minSpawnProb + itemToSpawn[i].spawnRate - 1;
            }
            
        }
        Spawnner();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Spawnner();
        }
    }
    void Spawnner()
    {
        float randomNum = Random.Range(0, 100);
        for (int i = 0; i <itemToSpawn.Length; i++)
        {
            if(randomNum>=itemToSpawn[i].minSpawnProb && randomNum<= itemToSpawn[i].maxSpawnProb)
            {
                Debug.Log(randomNum + " " + itemToSpawn[i].item.name);

                Instantiate(itemToSpawn[i].item, transform.position, Quaternion.identity);
                break;
            }
        }
    }
}
