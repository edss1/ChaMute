using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Level : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    Text levelText;
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
        levelText.text = string.Format("{0}", stat.Level);
    }
}
