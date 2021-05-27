using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterialController : MonoBehaviour
{
    [SerializeField] int m_MaxDropNum = 5;
    [SerializeField] MaterialType[] m_items;
    [SerializeField] MaterialType[] m_certainItems;
    [SerializeField] Transform[] m_dropPoint;
    [SerializeField] int m_materialNum = 3;
    int m_minimunNum = 1;
    [SerializeField] bool m_certainModeSelect = false;
    List<MaterialType> itemList = new List<MaterialType>();
    MaterialType m_item;

    int RandomNum(int num)
    {
        int m_size = Random.Range(0, 10);
        
        if (m_size > 4 && m_size <7)
        {
            num += 1;
        }
        else if(m_size >= 7)
        {
            num += 2;
        }

        return num;
    }

    List<MaterialType> RandomSelect()
    {
        int m_randomNum = Random.Range(0,5);
        switch (m_randomNum)
        {
            case 0:
                m_item = m_items[0];
                break;
            case 1:
                m_item = m_items[1];
                break;
            case 2:
                m_item = m_items[2];
                break;
            case 3:
                m_item = m_items[3];
                break;
            case 4:
                m_item = m_items[4];
                break;
            default:
                break;
        }
        itemList.Add(m_item);
        return itemList;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            itemList.Clear();
            if (!m_certainModeSelect)
            {
                RandomNum(m_materialNum);
                for (int i = 0; i < m_materialNum; i++)
                {
                    RandomSelect();
                }
            }
            else
            {
                foreach (var item in m_certainItems)
                {
                    itemList.Add(item);
                }
                RandomNum(m_minimunNum);
                for (int i = 0; i < m_materialNum - m_certainItems.Length; i++)
                {
                    RandomSelect();
                }
                m_certainModeSelect = false;
            }
            MaterialType[] itemArray = itemList.ToArray();
            FieldItemManager.Instance.DropMaterial(itemArray, this.transform.position);
            gameObject.SetActive(false);
            
        }
    }
}
