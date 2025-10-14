using UnityEngine;

public class missilcontroler : MonoBehaviour
{
    [SerializeField]
    float waitTime = 2;
    [SerializeField]
    float spawn = 3;
    
   
    void Start()
    {
        
    }

    // gör i enemycontroller 
    void Update()
    {
        waitTime = Time.deltaTime;
        if (waitTime > 3)
        {
            Instantiate(missilcontrolerprefab);
        }
    }
}
