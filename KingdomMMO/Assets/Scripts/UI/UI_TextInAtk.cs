using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TextInAtk : MonoBehaviour
{
    
    private void Start()
    {
        
    }

    private void Update()
    {
        Transform parent = transform.parent;
        transform.position = new Vector3(0, 1, 0);
        transform.rotation = Camera.main.transform.rotation;
    }

}
