using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ViewTextByAttack : MonoBehaviour
{
    GameObject player;
    Transform parent;
    float viewText;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        parent = transform.parent;
        transform.position = new Vector3(parent.position.x, parent.position.y + 2.5f, parent.position.z);
    }

    private void Update()
    {
        
        transform.rotation = Camera.main.transform.rotation;

        Vector3 upMovement = Vector3.up* 0.2f * Time.deltaTime;

        transform.position += upMovement;

        if (parent == player.transform)
            transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        
        viewText += Time.deltaTime;
        if (viewText >= 2.0f)
            Managers.Destroy(this.gameObject);
        
    }

}
