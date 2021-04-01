using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHealthScript : MonoBehaviour
{
    public int health;

    public int buttonNum;

    public Image[] buttons;
    public Sprite fullButton;
    public Sprite emptyButton;


    private void Start()
    {

    }

    private void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {

            if (health > buttonNum)
            {
                health = buttonNum;
            }
            if (i < health)
            {
                buttons[i].sprite = fullButton;

            }
            else
            {
                buttons[i].sprite = emptyButton;

            }
            if (i < buttonNum)
            {
                buttons[i].enabled = true;
            }
            else
            {
                buttons[i].enabled = false;

            }
        }
    }
}
