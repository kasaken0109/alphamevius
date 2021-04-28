using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MinimapCreater : MonoBehaviour
{
    //[SerializeField] Tilemap m_tilemap = null;
    //[SerializeField] TileBase m_tile = null;
    // Start is called before the first frame update
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.tag == "PlayerTile")
        {
            Debug.Log("hit" + collision.transform.position);
            //m_tilemap.BoxFill(Vector3Int.CeilToInt(collision.transform.position),m_tile,0,0,10,1);
            //m_tilemap.SetTile(Vector3Int.CeilToInt(collision.transform.position), m_tile);
            Destroy(this.gameObject);
        }

    }

    //public void BoxFill(Tilemap map, TileBase tile, Vector3 start, Vector3 end)
    //{
    //    BoxFill(map, tile, map.WorldToCell(start), map.WorldToCell(end));
    //}
}
