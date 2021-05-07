using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
    None,
    Hit,
    Smoke1,
    Smoke2,
}
public class EffectManager : MonoBehaviour
{
    [SerializeField] GameObject[] effectPrefab;
    Dictionary<EffectType, GameObject> effectList = new Dictionary<EffectType, GameObject>();
    static EffectManager instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < effectPrefab.Length; i++)
        {
            var id = (EffectType)(i + 1);
            effectList.Add(id, effectPrefab[i]);
        }
    }
    public static void PlayEffect(EffectType effectID, Vector3 pos)
    {
        Instantiate(instance.effectList[effectID]).transform.position = pos;
    }
}
