using UnityEngine;
using UnityEngine.UIElements;

public class enemy_spawner : MonoBehaviour
{
    [SerializeField]
    float wait = 0.5f;
    float waited = 0;
    [SerializeField]
    GameObject redLightPreFab;

    [SerializeField]
    GameObject enemyPrefab;
    int whatToSpawn;

    // Update is called once per frame
    void Update()
    {
        waited += Time.deltaTime;
        if (wait < waited)
        {
            whatToSpawn = Random.Range(1,11);
            waited = 0;
            if (whatToSpawn < 7)
            {
                Instantiate(enemyPrefab);
            }
            else if (whatToSpawn >= 7)
            {
                Instantiate(redLightPreFab);
            }
            
        }

    }
}
