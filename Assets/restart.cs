using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
