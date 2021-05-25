using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HpBar : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    Image hpBar;
    [SerializeField]
    Text hpText;
    PlayerStatus stat;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stat = player.GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.fillAmount = (float)stat.Hp / (float)stat.MaxHp;
        
        hpText.text = string.Format("{0} / {1}", stat.Hp, stat.MaxHp);
    }
}
