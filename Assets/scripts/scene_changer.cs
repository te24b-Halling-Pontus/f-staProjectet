using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_changer : MonoBehaviour
{
 public void ChangeScene()
    {
        SceneManager.LoadScene("main");
    }

}
