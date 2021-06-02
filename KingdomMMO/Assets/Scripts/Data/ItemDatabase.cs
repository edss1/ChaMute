using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item1> items = new List<Item1>();
    // List라는 기능을 이용해 아이템의 데이터베이스를 구축합니다.
    /*
     * 리스트란, 데이터를 간결하게 구성할 수 있는 기능 중 하나로써,
     * 예를 들어, 학생의 정보를 구성하고자 할때,
     * 학생 개개인은 이름, 집주소, 전화번호, 부모님 성함, 나이, 생일 등으로
     * 구성되어질 수 있다.
     * 학생의 정보를 한개의 종합된 속성으로 설정하여, 
     * 어떠한 학생의 정보를 열람한다면, 해당 학생의 모든 정보를 볼 수 있도록
     * 도와주는 기능이다.
     * 
     */

    void Start()
    {
        items.Add(new Item1("5_0", "Iron Sword", 1001, "This sword is normal style sword", 10, 1, 0, 0, Item1.ItemType.Weapon));
        // 위와 같이 원하는 아이템을 모두 추가해줍니다.(수업 중 예시니까 조금만 만들거임 ' ㅅ'
       //items.Add(new Item("8_0", "Iron Spear", 1011, "This spear is normal style spear", 12, 2, 0, 0, Item.ItemType.Weapon));
       //
       //items.Add(new Item("7_1", "Boxing Gloves", 2001, "This Gloves is fast gloves", 10, 1, 0, 1, Item.ItemType.Weapon));
       //items.Add(new Item("7_2", "Drill Gloves", 2002, "This Gloves is Drill gloves", 13, 2, 0, 1, Item.ItemType.Weapon));
       //
       //items.Add(new Item("2_7", "Red Potion", 4001, "This potion is restores hp(+50)", 0, 0, 0, 0, Item.ItemType.Useable));
       //items.Add(new Item("2_8", "Orange Potion", 4011, "This potion is increase sight (+5)", 0, 0, 0, 0, Item.ItemType.Useable));
    }
}
