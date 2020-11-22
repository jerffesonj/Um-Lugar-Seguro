using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarOpcao : MonoBehaviour
{
    public GameObject panelOptions;

    public void AbrirOpcao()
    {
        panelOptions.SetActive(true);
    }

    public void FecharOpcao()
    {
        panelOptions.SetActive(false);
    }
}
