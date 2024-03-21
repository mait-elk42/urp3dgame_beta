using UnityEngine;

public class Is_Trigger_Checker : MonoBehaviour
{
    [HideInInspector]
    public Collider other;
    private void OnTriggerEnter(Collider other)
    {
        this.other = other;
    }

    private void OnTriggerExit(Collider other)
    {
        this.other = null;
    }
}
