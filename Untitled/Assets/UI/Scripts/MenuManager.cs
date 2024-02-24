using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public static MenuManager instance;

    [SerializeField] private List<Menu> _menus;

    public GameEVManager game;

    public void OpenMenu(string menuName)
    {
        foreach (Menu menu in _menus)
        {
            if(menu.menuName == menuName)
            {
                menu.Open();
            }
            else
            {
                menu.Close();
            }
        }
    }

    public void play()
    {
        OpenMenu("Game");
        game.startGame();

    }



    void Start()
    {
        instance = this;
    }
}
