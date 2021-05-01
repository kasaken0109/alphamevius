using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldObject : MonoBehaviour
{
    [SerializeField] protected MaterialType[] DropItems;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FieldItemManager.Instance.DropMaterial(DropItems, transform.position);
        gameObject.SetActive(false);
    }
}
