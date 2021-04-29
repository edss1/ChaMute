using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_JoysticPad : UI_Base
{
    enum GameObjects
    {
        UI_JoysticPad,
    }

    bool joysticTouch = false;

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        
        //TODO
        Get<GameObject>((int)GameObjects.UI_JoysticPad).BindEventClick((PointerEventData)=> { Debug.Log("Joysic Touch!"); });
        Get<GameObject>((int)GameObjects.UI_JoysticPad).BindEventEndDrag((PointerEventData)=> { this.gameObject.transform.position = new Vector2(0,0); });


    }
    
    void Update()
    {
        
    }

    public void OnTouch(Vector2 vec2)
    {
        Debug.Log("Joysic Touch!");
    }
}
