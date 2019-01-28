using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingLevel : MonoBehaviour {

    public void LoadScene(string destinationLevel)
    {
        SceneManager.LoadScene(destinationLevel);
    }

}
