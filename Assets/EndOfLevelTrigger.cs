using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndOfLevelTrigger : MonoBehaviour
{
    private bool isEnd = false;
    private Image GameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel = GameObject.FindWithTag("Player").transform.Find("Canvas").Find("EndOfLevel").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd)
        {
            GameOverPanel.color = new Color(1f, 1f, 1f, GameOverPanel.color.a + 0.002f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (SceneManager.GetActiveScene().name == "Scene02")
            {
                SceneManager.LoadScene("SceneTY");
            }
            else
            {
                GameOverPanel.gameObject.SetActive(true);
                isEnd = true;
            }
        }
    }
}
