using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLevel1 : MonoBehaviour
{
    private Image Panel;
    private bool ended = false;
    void Start()
    {
        Panel = transform.Find("Canvas").Find("PanelEndLevel").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ended)
        {
            Panel.color = new Color(1f, 1f, 1f, Panel.color.a + 0.002f);
        }
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene02");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ended = true;
            Panel.gameObject.active = true;
            Time.timeScale = 0;
        }
    }
}
