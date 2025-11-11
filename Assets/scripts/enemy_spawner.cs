using UnityEngine;
using UnityEngine.UIElements;

public class enemy_spawner : MonoBehaviour
{
    [SerializeField]
    float wait = 0.5f;
    [SerializeField]
    float missilWait = 7f;
    float missilWaited = 0f;
    float waited = 0;
    [SerializeField]
    GameObject rödLjusPrefab;

    [SerializeField]
    GameObject enemyPrefab;
    

    // Update is called once per frame
    void Update()
    {
        missilWaited += Time.deltaTime;
        waited += Time.deltaTime;

        if (wait < waited)
        {
            Instantiate(enemyPrefab);
            waited = 0;
        }
        
        if (missilWait < missilWaited)
        {
            Instantiate(rödLjusPrefab);
            missilWaited = 0;
        }


    }
}
