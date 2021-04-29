using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Joystic : UI_Scene
{
    enum GameObjects
    {
        JoysticBackground,
    }


    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        GameObject joysticBackground = Get<GameObject>((int)GameObjects.JoysticBackground);

        foreach (Transform child in joysticBackground.transform)
            Managers.Resource.Destroy(child.gameObject);


        GameObject joystic = Managers.UI.MakeSubItem<UI_JoysticPad>(joysticBackground.transform).gameObject;
        UI_JoysticPad joysticPad = joystic.GetOrAddComponent<UI_JoysticPad>();

    }

}
