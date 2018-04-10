using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour 
{
    ItemDatabase itemDatabase;
    float timer = 0f;
    bool canSpawn = true;
    public bool CanSpawn
    {
        get { return canSpawn; }
        set { canSpawn = value;}
    }


	// Use this for initialization
	void Start () 
    {
        itemDatabase = GameObject.Find("ItemManager").GetComponent<ItemDatabase>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;

        if (CanSpawn && timer >= 10f)
        {
            ChooseSpawnItem();

            timer = 0f;
        }
	}

    void ChooseSpawnItem()
    {
        if (gameObject.name == "HealthSpawner")
            Spawn(itemDatabase.items["health"]);
        else if (gameObject.name == "DamageSpawner")
            Spawn(itemDatabase.items["damage"]);
        else if (gameObject.name == "RandomSpawner")
        {
            int rand = Random.Range(0, 2);

            switch (rand)
            {
                case 0:
                    Spawn(itemDatabase.items["health"]);
                    break;
                case 1:
                    Spawn(itemDatabase.items["damage"]);
                    break;
                default:
                    Debug.LogError("Something Went Wrong!");
                    break;
            }
        }
    }

    void Spawn(GameObject gameObjToSpawn)
    {
        GameObject temp = Instantiate(gameObjToSpawn, transform.position, Quaternion.identity, transform) as GameObject;

        switch (gameObject.name)
        {
            case "HealthSpawner":
                temp.name = "Health Pack";
                break;
            case "DamageSpawner":
                temp.name = "Damage Pack";
                break;
            case "RandomSpawner":
                if (temp.CompareTag("Health"))
                    temp.name = "Health Pack";
                else if (temp.CompareTag("Damage"))
                    temp.name = "Damage Pack";
                break;
        }            

        CanSpawn = false;
    }
}
