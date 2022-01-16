using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crystal : MonoBehaviour
{

    public string currentLevel;
    public int nextLevel;

    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().name;
        currentLevel = currentLevel.Trim(new char[] { 'L', 'e', 'v', 'l', ' '});
        Debug.Log(currentLevel);
        nextLevel = Int32.Parse(currentLevel) + 1;
        if (nextLevel == 4) GetComponent<SpriteRenderer>().color = new Color (0f, 1f, 0f, 1f);
    }

    // Update is called once per frame
    public void Smash()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (nextLevel < 4)
        {
            int addHealth = player.currentHealth + 50 >= 100 ? 100 : player.currentHealth + 50;
            PlayerPrefs.SetInt("Health", addHealth);
            SceneManager.LoadScene("Level " + nextLevel);
        }
        else
        {
            PlayerPrefs.DeleteKey("Health");
            SceneManager.LoadScene("Win");
        }
        Destroy(this.gameObject);
    }
}
