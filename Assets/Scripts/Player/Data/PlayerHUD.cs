using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeReference] protected Infographic[] infographics;

    void Update()
    {
        foreach(Infographic graph in infographics)
        {
            graph.setValue((float)ReflectionCaller.GetVariableValue("RunStats", "currentPlayerHeight"));
        }
    }
}
