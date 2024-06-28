using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBarManager : MonoBehaviour
{
    public int maxHealth = 100;
    public healthBAr hbar;
    // Start is called before the first frame update
    void Start()
    {
        //staticClass.player1Health = maxHealth;
        staticClass.player2Health = maxHealth;
        hbar.setMaxHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        refreshbar();
    }
    void refreshbar()
    {
      
        hbar.setHealth(staticClass.player2Health);
    }
}
