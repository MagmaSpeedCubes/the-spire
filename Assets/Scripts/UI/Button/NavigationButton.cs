using UnityEngine.UI;
using UnityEngine;
public class NavigationButton : MonoBehaviour
{

    [SerializeField] protected Canvas[] closeCanvas;
    [SerializeField] protected Canvas[] openCanvas;

    public void onClick()
    {
        SoundHandler.playSound("buttonPress", ProfileStats.masterVolume * ProfileStats.uiVolume / 10000f);
        foreach (Canvas c in closeCanvas)
        {
            c.enabled = false;
        }
        foreach (Canvas c in openCanvas)
        {
            c.enabled = true;
        }
        
    }
}
