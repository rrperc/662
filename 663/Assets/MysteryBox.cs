using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemToSpawn
{
    public GameObject item;
    public float spawnRate;
    [HideInInspector] public float minSpawnProb, maxSpawnProb;
}

public class MysteryBox : MonoBehaviour

{
    public ItemToSpawn[] itemToSpawn;
    // Start is called before the first frame update
    public ItemToSpawn[] itemToSpawns;
    void Start()
    {
        for (int i = 0; i < itemToSpawn.Length; i++)
        {
            if (i == 0)
            {
                itemToSpawn[i].minSpawnProb = 0;
                itemToSpawn[i].maxSpawnProb = itemToSpawn[i].spawnRate - 1;//60-1 = 59
            }
            else
            {
                itemToSpawn[i].minSpawnProb = itemToSpawn[i - 1].maxSpawnProb + 1;//79+1=80
                itemToSpawn[i].maxSpawnProb = itemToSpawn[i].minSpawnProb + itemToSpawn[i].spawnRate - 1;//80+10=90-1=89
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Spawnner();
        }
    }
    void Spawnner()
    {
        float randomNum = Random.Range(0, 100);//56
        for(int i = 0; i < itemToSpawn.Length; i++)
        {
            if(randomNum>=itemToSpawn[i].minSpawnProb && randomNum<= itemToSpawn[i].maxSpawnProb)
            {
                Instantiate(itemToSpawn[i].item, transform.position, Quaternion.identity);
                break;
            }
        }
    }
}
