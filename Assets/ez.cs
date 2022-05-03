using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ez : MonoBehaviour
{
    [SerializeField] private string _tag;
    private Transform target;
    private Transform trans_camera;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Clone;
    [SerializeField] private GameObject Stone;
    [SerializeField] private float speed = 3f;
    private bool flag = false;
    private bool one_times = true;
    private Animator anim;
    Rigidbody2D PlayerRB;
    Rigidbody2D RBStone;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Player && one_times)
        {
            //Player.SetActive(false);
            //Clone.SetActive(true);
            //Clone.transform.position = place;
            flag = true;
            //trans_camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
            //Vector3 newPosCam = new Vector3(130f, trans_camera.position.y, trans_camera.position.z);
            //GameObject.FindGameObjectWithTag("MainCamera").transform.position = Vector3.Slerp(transform.position, newPos, speed * Time.deltaTime);
            //93.71f
            PlayerRB.simulated = false;
            RBStone.simulated = false;
            Player.transform.position = new Vector3(83.74f, -1.434206f, 0f);
            one_times = false;
            Player.GetComponent<Motion>().enabled = false;
            Player.GetComponent<Animator>().SetBool("isrun", false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        PlayerRB = Player.GetComponent<Rigidbody2D>();
        RBStone = Stone.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            Vector3 newPos1 = new Vector3(128f, transform.position.y, 0f);
            Vector3 newPos2 = new Vector3(128f, -1.434206f, 0f);
            //-1.68f
            if (transform.position.x < newPos1.x)
            {
                anim.SetBool("isrun", true);
              
                transform.position = Vector3.MoveTowards(transform.position, newPos1, speed * Time.deltaTime);
                Player.transform.position = Vector3.MoveTowards(Player.transform.position, newPos2, speed * Time.deltaTime);
            }
            else
            {
                anim.SetBool("isrun", false);
                flag = false;
                PlayerRB.simulated = true;
                RBStone.simulated = true;
                Player.GetComponent<Motion>().enabled = true;
            }
        }
    }
}
