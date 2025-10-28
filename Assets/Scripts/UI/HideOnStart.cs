using UnityEngine;
using UnityEngine.UI;
public class HideOnStart : MonoBehaviour
{
    [SerializeField] protected Canvas[] hideCanvases;
    void Start()
    {
        foreach(Canvas c in hideCanvases)
        {
            c.enabled = false;
        }
    }
}
