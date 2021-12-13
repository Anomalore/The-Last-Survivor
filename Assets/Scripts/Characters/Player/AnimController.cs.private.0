using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class AnimController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] float animationSpeedTweak = 0.0f;
    float currentWeight = 0.0f;
    [SerializeField]float layerSwitchSpeed = 0.0f;
    //[SerializeField] private TwoBoneIKConstraint RightArmIK, LeftArmIk;
    
    public void TriggerJumpAnimation()
    {
        animator.SetTrigger("Jump");
    }

    public IEnumerator Jump(float waitTime)
    {
        animator.SetBool("In Air", true);
        yield return new WaitForSeconds(waitTime);
        animator.SetBool("In Air", false);
    }

    public void setMovementAnimationSpeed(float playerSpeed)
    {
        if(animator != null)
        {
            animator.SetFloat("Movement Speed", (playerSpeed/10)/animationSpeedTweak);
        }
    }

    public void MovementAnimationNoAim(Vector2 input)
    {

        animator.SetFloat("VelX", input.x, 0.1f, Time.deltaTime);
        animator.SetFloat("VelY", input.y, 0.1f, Time.deltaTime);

        currentWeight = Mathf.Lerp(currentWeight,1.0f,Time.deltaTime * layerSwitchSpeed);

        // RightArmIK.weight = Mathf.Lerp(currentWeight,1.0f, Time.deltaTime * layerSwitchSpeed);
        // LeftArmIk.weight = Mathf.Lerp(currentWeight,1.0f, Time.deltaTime * layerSwitchSpeed);

        animator.SetLayerWeight(animator.GetLayerIndex("Upper Body"), currentWeight);
    }

    public void MovementAnimationAim(Vector2 rawInput, Vector2 input, float speedMultiplyer)
    {
        // RightArmIK.weight = 0;
        // LeftArmIk.weight = 0;
        animator.SetFloat("VelX", input.x, 0.1f, Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftControl) && rawInput.y > 0)
        {
            animator.SetFloat("VelY", input.y * speedMultiplyer, 0.1f, Time.deltaTime);
        }
        else
        {
            animator.SetFloat("VelY", input.y, 0.1f, Time.deltaTime);
        }

        currentWeight = Mathf.Lerp(currentWeight,0.0f,Time.deltaTime * layerSwitchSpeed);
        animator.SetLayerWeight(animator.GetLayerIndex("Upper Body"),currentWeight);
    }
}
