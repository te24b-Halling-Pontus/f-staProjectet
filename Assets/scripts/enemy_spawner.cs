using UnityEngine;
using UnityEngine.UIElements;

public class enemy_spawner : MonoBehaviour
{
    [SerializeField]
    float wait = 0.5f;
    [SerializeField]
   
    float waited = 0;
    [SerializeField]
    GameObject missilprefab;

    [SerializeField]
    GameObject enemyPrefab;

    // Update is called once per frame
    void Update()
    {
        waited += Time.deltaTime;
        if (wait < waited)
        {
            Instantiate(enemyPrefab);
            Instantiate(missilprefab);

            waited = 0;
        }


    }
}
