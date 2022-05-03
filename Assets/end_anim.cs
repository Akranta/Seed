using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end_anim : MonoBehaviour
{
    public int waittime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForLevel());
    }

    IEnumerator WaitForLevel()
    {
        yield return new WaitForSeconds(waittime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    // Update is called once per frame
 
}
