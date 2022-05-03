using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public float FollowSpeed = 7f;
    public Transform player;
    public string _tag = "Player";
    private void Update()
    {
        Vector3 newPos = new Vector3(player.position.x, player.position.y + 3.74f, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, newPos, FollowSpeed * Time.deltaTime);
        //Vector3 newPos = new Vector3(target.position.x, transform.position.y, -10f);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    //private void OnEnable()
    //{
      //  player = gameObject.FindWithTag(_tag).transform;
    //}
}
