using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_anim : MonoBehaviour
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); ;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
