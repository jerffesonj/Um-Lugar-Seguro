using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjScript : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
