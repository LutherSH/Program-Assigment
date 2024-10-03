using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.SocialPlatforms.Impl;

public class ScriptTugas : MonoBehaviour
{
    public int health = 100;    public int armor = 0;
    public int decayH = 10;     public int gainA = 10;
    public int quality;


    public TMP_Text TextScore1; //TO SHOW HEALTH
    public TMP_Text TextScore2; //TO SHOW ARMOR
    public TMP_Text TextScore3; //TO SHOW HEALTH STATUS 
    public TMP_Text TextScore4; //TO SHOW ARMOR STATUS
    public TMP_Text TextScore5; //TO SHOW QUALITY STATUS
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("LOADING");
        Array();
        Mechanic5();
        StartCoroutine(healthDecay());
        StartCoroutine(armorGains());
    }
    // Update is called once per frame
    #region Mechanic No1 3
    void updateHealth()
    {
        TextScore1.text = "Health :" + health.ToString();
        Debug.Log("Health :" + health);
        Reminder();
    }

    private IEnumerator healthDecay()
    {
        while (health > 0)
        {
            health -= decayH;
            updateHealth();
            yield return new WaitForSeconds(3);
        }

    }
    #endregion
    #region Mechanic No2
    void Array()
    {
        int[] theScores = {100, 90, 80, 70, 60};

        for (int i = 0; i < theScores.Length; i++)
        {
            Debug.Log("Score : " + (i+1) + ": " + theScores[i]);
        }
    }
    #endregion
    #region Mechanic Reminder

        void Reminder()
    {
        if(health >= 50){TextScore3.text = "Player is Healty";}
        if(health < 50 && health >= 20 ){TextScore3.text = "Player need to take Care";}
        if(health <= 20){TextScore3.text = "Player is in Danger";}
        if(health <= 0){TextScore3.text = "Player is DEAD";}

        if(armor >= 30 && health >= 50){TextScore4.text = "Player is Ready";}
        else{TextScore4.text = "Player need to prepare";}

        if(quality >= 60){TextScore5.text = "You Are A High Quality Player";}
        else{TextScore5.text = "You Need More Practice";}

    }
    #endregion
    #region Mechanic No4, No5

    void Mechanic4()
    {
        TextScore2.text = "Armor :" + armor.ToString();
        Debug.Log("Armor :" + armor);
        Reminder();
    }

    private IEnumerator armorGains()
    {
        while (armor < 100)
        {
            armor += gainA;
            Mechanic4();
            yield return new WaitForSeconds(3);
        }

    }

    void Mechanic5()
    {
        if(quality <= 0 ){quality = 0;}
        if(quality >= 100 ){quality = 100;}
        Reminder();
    }
    #endregion 
}
