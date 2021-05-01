using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterialController : MonoBehaviour
{
    [SerializeField] int m_MaxDropNum = 5;
    [SerializeField] MaterialType[] m_items;
    [SerializeField] Transform[] m_dropPoint;
    List<MaterialType> itemList = new List<MaterialType>();
    int m_materialNum;
    MaterialType m_item;

    void RandomNum()
    {
        int m_size = Random.Range(0, 10);
        if (m_size <= 4)
        {
            m_materialNum = 3;
        }
        else if (m_size <= 7)
        {
            m_materialNum = 4;
        }
        else
        {
            m_materialNum = 5;
        }
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
        //Debug.Log("Enter Player");
        if (collision.tag == "Player")
        {
            itemList.Clear();
            //Debug.Log("itemcollect");
            RandomNum();
            for (int i = 0; i < m_materialNum; i++)
            {
                //FieldItemManager.Instance.DropItem(RandomSelect()[i], m_dropPoint[i].position);
                RandomSelect();
            }
            MaterialType[] itemArray = itemList.ToArray();
            FieldItemManager.Instance.DropMaterial(itemArray, this.transform.position);
            gameObject.SetActive(false);
            
        }
    }
}
