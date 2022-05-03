using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class pazzle : MonoBehaviour
{
    public int score = 0;
    [SerializeField] Text scoreText;
    [SerializeField] private Image img;
    bool flag = false;
    float timer = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "pazzle")
        {
            Destroy(other.gameObject);
            score++;
        }
        if (score == 4)
        {
            img.gameObject.SetActive(true);
            flag = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
            timer += Time.deltaTime;

        if (flag && timer > 4)
        {
            img.gameObject.SetActive(false);
            flag = false;
        }

        scoreText.text = score.ToString() + "/4";
    }
}
