using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update

    public virtual void Interact()
    {
        Debug.Log("Intearacted with Intearactable class");
    }
}
