using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelfHealing : MonoBehaviour
{
    public float updatedHealth;
    public float maxHealth;
    public float pointIncreasePersecond;
    public Text healthUI;
    // Start is called before the first frame update
    void Start()
    {
        updatedHealth = 2;
        maxHealth = 5;
        pointIncreasePersecond = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        updatedHealth += pointIncreasePersecond * Time.deltaTime;
        if(updatedHealth > maxHealth)
        {
            updatedHealth = 3;
        }
        if(updatedHealth < 0)
        {
            updatedHealth = 0;
        }
        healthUI.text = (int)updatedHealth + " Health";
    }
}
