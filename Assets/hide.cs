using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide : MonoBehaviour
{
    [SerializeField] private string _tag = "Player";
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Eyes;
    [SerializeField] private float spawnX;
    [SerializeField] private float spawnY;
    private bool plhide = false;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!plhide && other.gameObject == Player && Input.GetKeyDown(KeyCode.E))
        {
            Player.SetActive(false);
            Eyes.SetActive(true);
            plhide = true;
            Player.transform.position = new Vector3(spawnX, spawnY, 0f);
            //Destroy(Player);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (plhide == true && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
    {
        Player.SetActive(true);
        Eyes.SetActive(false);
        plhide = false;
        }
    }
}
