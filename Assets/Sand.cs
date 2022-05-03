using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Sand : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Cam;
    [SerializeField] private float spawnX;
    [SerializeField] private float spawnY;
    public void Reload()
    {
        Player.transform.position = new Vector3(spawnX, spawnY, 0f);
        Cam.transform.position = new Vector3(spawnX, spawnY + 3.74f, 0f);
    }
    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(_tag))
        {
            Reload();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
