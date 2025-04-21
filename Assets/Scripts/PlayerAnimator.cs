using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    
    private Animator _animator => gameObject.GetComponent<Animator>();
    public GameObject rb;

    private void Start()
    {
        playerController.isFlying += Fly;
        playerController.isIdle += Idle;
        playerController.isPreparing += Prepare;
        playerController.isFullPowered += FullPower;
    }

    private void Update()
    {
        if(rb.GetComponent<Rigidbody2D>().velocity.magnitude > 0)
            Fly();

        if(rb.GetComponent<Rigidbody2D>().velocity.magnitude == 0 && (Input.GetKey(KeyCode.A) != true && Input.GetKey(KeyCode.D) != true))
            Idle();
    }

    private void OnDisable()
    {
        playerController.isFlying -= Fly;
        playerController.isIdle -= Idle;
        playerController.isPreparing -= Prepare;
        playerController.isFullPowered -= FullPower;
    }

    private void Prepare()
    {
        _animator.SetBool("isPreparing", true);
    }

    private void Idle()
    {
        _animator.SetBool("isFlying", false);
        _animator.SetBool("isPreparing", false);
    }

    private void Fly()
    {
        _animator.SetBool("isFlying", true);
        _animator.SetBool("isFullPower", false); 
    }

    private void FullPower()
    {
       _animator.SetBool("isFullPower", true); 
    }
}
