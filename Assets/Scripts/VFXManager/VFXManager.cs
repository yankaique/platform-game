using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.core.Singleton;

public class VFXManager : Singleton<VFXManager>
{
    public enum VFXType
    {
        JUMP,
        VFX_2
    }

    public List<VFXManagerSetup> vfxSetup;

    public void PlayVFXByType(VFXType vfxType, Vector2 position)
    {
        foreach(var i in vfxSetup)
        {
            if(i.vfxType == vfxType)
            {
                var item  = Instantiate(i.prefab);
                item.transform.position = position;
                Destroy(item.gameObject, 1f);
                break;
            }
        }
    }
}

[System.Serializable]
public class VFXManagerSetup 
{ 
    public VFXManager.VFXType vfxType;
    public GameObject prefab;
}
