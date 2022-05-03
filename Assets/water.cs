using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;
    [SerializeField] private GameObject Cam1;
    [SerializeField] private GameObject Cam2;
    [SerializeField] private GameObject ogr;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Player1)
        {
            Player1.SetActive(false);
            Player2.SetActive(true);
            Cam1.SetActive(false);
            Cam2.SetActive(true);
            ogr.SetActive(true);

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
        
    }
}
