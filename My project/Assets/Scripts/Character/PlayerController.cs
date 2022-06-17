using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;
    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    const float offsetY = 0.3f;
    PhotonView view;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
    }

    public void Update() 
    {
        if (view.IsMine)
        {
            if (GameController._instance.state == GameState.FreeRoam)
            {
                if (!isMoving)
                {
                    input.x = Input.GetAxisRaw("Horizontal");
                    input.y = Input.GetAxisRaw("Vertical");

                    if (input.x != 0) input.y = 0; //rm diagonale mvt

                    if (input != Vector2.zero)
                    {
                        animator.SetFloat("moveX", input.x);
                        animator.SetFloat("moveY", input.y);
                        var targetPos = transform.position;
                        targetPos.x += input.x;
                        targetPos.y += input.y;

                        if (IsWalkable(targetPos))
                            StartCoroutine(Move(targetPos));
                    }
                }
                animator.SetBool("isMoving", isMoving);
                if (Input.GetKeyDown(KeyCode.E))
                    Interact();

            }
        }
    }

    void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

        //Debug.DrawLine(transform.position, interactPos, Color.green, 0.5f);
        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }

    private void OnMoveOver()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position - new Vector3(0, offsetY), 0.2f, GameLayers.i.TriggerableLayers);
        foreach (var collider in colliders)
        {
            var triggerable = collider.GetComponent<IPlayerTriggerable>();
            if (triggerable != null)
            {
                triggerable.OnPlayerTriggered(this);
                break;
            }
        }
    }
    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactableLayer) != null)
        {
            return false;
        }
        return true;
    }
 
}