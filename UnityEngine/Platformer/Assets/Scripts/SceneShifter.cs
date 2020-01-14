using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneShifter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShiftScene()
    {
        SceneManager.LoadScene(1);
    }
}
