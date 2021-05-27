using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldObject : MonoBehaviour
{
    [SerializeField] protected MaterialType DropItems;
    [SerializeField] private int m_dropNum = 1;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (DropItems != MaterialType.None)
            {
                NewItemManager.Instance.AddItem(NewItemManager.Instance.GetMaterialId(DropItems), m_dropNum);
            }
            Player.Instance.CatchItem();
            EffectManager.PlayEffect(EffectType.Hit, transform.position);
            this.gameObject.SetActive(false);
        }
    }

    public MaterialType GetTouchMaterial()
    {
        return DropItems;
    }
}
