using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****************************************************
 * SpawnEnemies
 * 
 * This class is responsible for the spawning of enemies
 * it will contain a generic Enemy GameObject and set
 * values of that GameObject to values specific to
 * classes of enemies. It is done in this way to make
 * the editting of enemie's stats easier.
 ****************************************************/
public class SpawnEnemies : MonoBehaviour
{
    [System.Serializable]
    public struct spawnSections
    {
        public float greaterThan;
        public float scale;
    };

    // The outer radius of the circle that enemies should
    // be spawned at
    public float outerRadius;
    public gameManager gm;


    public GameObject enemy_prefab;

    public List<Enemy_Class> enemies;

    // Spawning stuff
    public float spawnTimer = 2;
    private float spawnCD = 0;

    public spawnSections[] sections;
    public float increaseSpawnCD;
    private float increaseCounter = 0;

    private void updateScalar()
    {
        foreach (spawnSections item in sections)
        {
            if (increaseCounter > item.greaterThan)
            {
                increaseSpawnCD *= item.scale;
                increaseCounter = 0;
                return;
            }
        }
    }

    private void Update()
    {
        increaseCounter += Time.deltaTime;
        if (increaseCounter >= increaseSpawnCD)
        {
            updateScalar();
        }

        if (spawnCD <= 0)
        {
            spawnEnemy();
            spawnCD = spawnTimer;
        }
        spawnCD -= Time.deltaTime;
    }

    

    /************************************
     * SpawnEnemy
     * 
     * This function creates an enemy and populates the
     * variables such that it is set to be of the rusher
     * class.
     * 
     * This enemy has no inner circle, so it is not
     * going to spawn using the tangent line point function.
     ************************************/
    public void spawnEnemy()
    {
        // Get a random angle to spawn the rusher at
        float angle = Random.Range(0, 360) * Mathf.Deg2Rad;

        // Convert the angle to a point in 2D space
        Vector2 pos = TrigCalculations.getPointOnRadius(angle, outerRadius);

        // Create a rotation such that the enemy is pointed towards the player
        float quatAngle = (Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg) + 90;
        Quaternion quaternion = Quaternion.Euler(0, 0, quatAngle);

        // Instantiate the enemy with the information created
        GameObject enemy = Instantiate(enemy_prefab, new Vector3(pos.x, pos.y, 0), quaternion);

        // Randomly choose a enemy class and spawn it
        int index = Random.Range(1, enemies.Count + 1) - 1;
        Enemy_Class enemy_Class = enemies[index];

        if (enemy_Class.name == "Rusher")
        {
            enemy.gameObject.AddComponent<Rush_enemy>();
        }
        if (enemy_Class.name == "gunner" || enemy_Class.name == "Sniper")
        {
            enemy.gameObject.AddComponent<Gunner_Behaviou>().bullet = enemy_Class.bullet;
        }
        if (enemy_Class.name == "Speedster")
        {
            enemy.gameObject.AddComponent<Speedster_behaviour>();
        }


        Generic_enemy generic_Enemy = enemy.GetComponent<Generic_enemy>();

        Instantiate(enemy_Class.mainPartSys, generic_Enemy.gameObject.transform);
        generic_Enemy.gm = gm;
        generic_Enemy.deathSR = enemy_Class.deathPartSys;
        generic_Enemy.angle = angle;
        generic_Enemy.inner_radius = enemy_Class.innerRadius;
        generic_Enemy.speed = enemy_Class.speed;
        generic_Enemy.onDataSet();
    }
}
