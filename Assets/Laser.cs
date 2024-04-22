using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : StateMachineBehaviour
{
    public string triggerName = "Laser"; // Nombre del trigger que activará la segunda animación
    public Animator targetAnimator; // Referencia al Animator del objeto de destino

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (targetAnimator != null)
        {
            targetAnimator.SetTrigger(triggerName); // Activa el trigger en el objeto de destino
        }
    }
}
