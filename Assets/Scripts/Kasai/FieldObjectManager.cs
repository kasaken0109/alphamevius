using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldObjectManager : MonoBehaviour
{
    [SerializeField] ItemEnum item = ItemEnum.Wood;
    [SerializeField] Transform m_dropPosition = null;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Enter Player");
        if (collision.tag == "Player")
        {
            //Debug.Log("itemcollect");
            animator.SetBool("Get", true);  
        }
    }

    public void SetActive()
    {
        this.gameObject.SetActive(false);
        FieldItemManager.Instance.DropItem(item, m_dropPosition.position);
    }
}
