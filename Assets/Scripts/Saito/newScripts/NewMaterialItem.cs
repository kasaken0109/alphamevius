using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialItmes", menuName = "MaterialItems")]
public class NewMaterialItem : NewItem
{
    [SerializeField] MaterialType m_materialType;
}
