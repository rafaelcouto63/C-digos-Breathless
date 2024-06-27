using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    //movimenta��o base
    public float moveSpeed = 5f;
    public float baseMoveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravityModifier;
    public bool isOnGround = true;
    //movimenta��o escalando
    public float climbSpeed = 5f;
    public bool isClimbing = false;
    private bool isInRange = false;
    private float inputVertical;
    //Controle de Caixa
    public float distance = 1f;
    public LayerMask boxMask;
    GameObject box;
    public static bool isHoldingBox = false;

    public Rigidbody rb;
    Vector3 movement;
    
    private Animator animator;

    

    void Start()
    {
        Physics.gravity *= gravityModifier;
        rb = GetComponent<Rigidbody>();
        moveSpeed = baseMoveSpeed; // Inicialize moveSpeed com baseMoveSpeed
        animator = GetComponent<Animator>();
        
    }
    void Update()
    {
        movement.z = Input.GetAxis("Horizontal");
        PlayerJump();
        PushPullBox();
        ClimbingMov();

        if (movement.magnitude > 0)
        {
           animator.SetBool("IsWalking", true);
        }
        else 
        {
            animator.SetBool("IsWalking", false);
        }
        
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement) * moveSpeed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
            isOnGround = true;
    }
    private void PlayerJump()
    {
        if (!isHoldingBox) // Modificado aqui
        {
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                animator.Play("Jumping");
            }
             
             
        }
    }
    private void ClimbingMov()
    {
        inputVertical = Input.GetAxisRaw("Vertical");
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            isClimbing = !isClimbing; // Toggle climbing on or off
            transform.rotation = Quaternion.Euler(0f, -90f, 0f); //gira quando sobe a escada
        }
        if (isClimbing)
        {
            animator.SetBool("IsClimbing", true);
            rb.useGravity = false;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                rb.velocity = new Vector3(0, inputVertical * climbSpeed, 0);
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
        else
        {
            rb.useGravity = true;
            animator.SetBool("IsClimbing", false);
        }
    }
    private void PushPullBox()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (box != null)
            {
                box.GetComponent<Rigidbody>().isKinematic = true;
                box.transform.SetParent(null);
                box = null;
                isHoldingBox = false;
                moveSpeed = baseMoveSpeed; // Restaure a velocidade de movimento quando soltar a caixa
            }
            else
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, distance, boxMask))
                {
                    box = hit.collider.gameObject;
                    box.GetComponent<Rigidbody>().isKinematic = true;
                    box.transform.SetParent(this.transform);  
                    isHoldingBox = true;
                    float speed = baseMoveSpeed / box.GetComponent<Box>().weight; // Ajuste a velocidade de movimento com base no peso da caixa
                    moveSpeed = Mathf.Min(speed, baseMoveSpeed); // Garanta que a velocidade de movimento nunca exceda a velocidade base
                }
            }
        }
    
    
      // Verifique se a caixa está colidindo com um objeto na camada "chão" ou "obstáculo"
    if (isHoldingBox)
    {
        // Detecte colisões com objetos na camada "chão" ou "obstáculo"
        Collider[] colliders = Physics.OverlapBox(box.transform.position, box.transform.localScale / 2f, Quaternion.identity, LayerMask.GetMask("Chao", "Obstaculo"));
        foreach (Collider collider in colliders)
        {
            // Impedir o movimento do jogador na direção da frente (eixo Z)
            Vector3 directionToCollider = collider.transform.position - transform.position;
            Debug.Log("" + directionToCollider);
            directionToCollider.x = 0f; // Ignorar movimento no eixo X
            
            // Verifique se o objeto colidido está à frente do jogador (produto escalar positivo)
            if (Vector3.Dot(directionToCollider, transform.forward) < 0f)
            {
                // Impedir o movimento do jogador na direção da frente (eixo Z)
                 movement.z = Mathf.Min(movement.z, 0f);
            }
            if (Vector3.Dot(directionToCollider, transform.forward) > 0f)
            {
                // Impedir o movimento do jogador na direção da traz (eixo Z)
                 movement.z = Mathf.Max(movement.z, 0f);
            }
        }
    }
        
       // caixa deixa de ser kinematic quando solta
        if (isHoldingBox == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, distance, boxMask))
            {
              box = hit.collider.gameObject;
              if(box != null)
             {
               box.GetComponent<Rigidbody>().isKinematic = false;
               box = null;
             }
           }
            
        }

        if (!isHoldingBox)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.forward = Vector3.back;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.forward = Vector3.forward;
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * distance);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            isInRange = true;
        }

       /* if (other.gameObject.CompareTag("Morte"))
        { 
            Destroy(gameObject);
        } */
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            isInRange = false;
            isClimbing = false;
        }
    }
}
