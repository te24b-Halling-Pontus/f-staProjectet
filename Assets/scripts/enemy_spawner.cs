using UnityEngine;
using UnityEngine.UIElements;

public class enemy_spawner : MonoBehaviour
{
    [SerializeField]
    float wait = 0.5f;
    float wait2 = 0;
    
    [SerializeField]
    GameObject enemyPrefab;

    // Update is called once per frame
    void Update()
    {
        wait2 += Time.deltaTime;
        if (wait < wait2)
            {
            Instantiate(enemyPrefab);
            wait2 = 0;
            }
            
        
    }
}
