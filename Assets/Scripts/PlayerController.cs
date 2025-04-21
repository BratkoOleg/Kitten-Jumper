using System.Collections.Generic;
using System;
using UnityEngine; 
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float JumpForce = 0.1f;
    [SerializeField] private float MaxJumpForce;
    [SerializeField] private float MaxJumpDistance;
    [SerializeField] private Main main;
    public List<float> previousPlats = new List<float>(); 

    public static int coins;
    
    private Rigidbody2D _rb => gameObject.GetComponent<Rigidbody2D>();
    private bool isGRounded;
    private enum JumpSide { left,right}
    public Image image;
    public TextMeshProUGUI text;
    public int platforms;
    public float magnitude;

    public Action isPreparing;
    public Action isFlying;
    public Action isIdle;
    public Action isFullPowered;
    public Action<int> onTakeCoin;

    void Update()
    {
        magnitude = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;

        if (isGRounded)
        {
            Move();
            SetLocalScale();
        }
        
        DrawPower();
    }

    private void DrawPower()
    {
        float curFuelInPercent = JumpForce / MaxJumpForce;
        image.fillAmount = curFuelInPercent;
    }

    private void Jump(JumpSide jumpSide)
    {
        if(JumpForce > MaxJumpForce)
            JumpForce = MaxJumpForce;

        switch (jumpSide)
        {
            case JumpSide.left:
                AddForce(-MaxJumpDistance);
                Debug.Log("left");
                break;
            case JumpSide.right:
                AddForce(MaxJumpDistance);
                Debug.Log("right");
                break;
        }
        JumpForce = 0.1f;
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) && isGRounded && JumpForce <= MaxJumpForce)
        {
            isPreparing?.Invoke();
            JumpForce += Time.deltaTime * 10;
        }

        if(JumpForce >= MaxJumpForce)
            isFullPowered?.Invoke();

        if(Input.GetKeyUp(KeyCode.A) && isGRounded && !Input.GetKey(KeyCode.D))
            Jump(JumpSide.left);

        if(Input.GetKeyUp(KeyCode.D) && isGRounded && !Input.GetKey(KeyCode.A))
            Jump(JumpSide.right);
    }

    private void SetLocalScale()
    {
        if(Input.GetKey(KeyCode.A))
            gameObject.transform.localScale = new Vector3(-1, 1,1);

        if(Input.GetKey(KeyCode.D))
            gameObject.transform.localScale = new Vector3(1, 1,1);
    }

    private void AddForce(float maxJumpDistance)
    {
        _rb.AddForce(new Vector2(maxJumpDistance,3) * JumpForce, ForceMode2D.Impulse);
        isFlying?.Invoke();
        
    }

    void OnCollisionEnter2D(Collision2D collision) 
    { 
        if (collision.gameObject.CompareTag("Ground")) 
        { 
            isIdle?.Invoke();
            isGRounded = true;
        } 

        if (collision.gameObject.CompareTag("wall")) 
        { 
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1f, 1, 1);
        }

        if (collision.gameObject.CompareTag("Ground") && gameObject.GetComponent<Rigidbody2D>().velocity.magnitude == 0
            && collision.gameObject.transform.position.x != 0.0007f) 
        { 
            Debug.Log("check");
            bool same = CheckPlats(collision.gameObject);

            if (same == false)
            {
                platforms++;
                text.text = platforms.ToString();
                PlayerPrefs.SetInt("currentScore", platforms);
            }
        } 
    } 

    private bool CheckPlats(GameObject gameObject)
    {
        
        bool same = false;

        if (previousPlats.Contains(gameObject.transform.position.x) == true)
        {
            same = true;
        }
        else
        {
            same = false;
            previousPlats.Add(gameObject.transform.position.x);
        }
        return same;
    }

    public void Save()
    {
        int oldscore = PlayerPrefs.GetInt("score");
        if(platforms > oldscore)
            PlayerPrefs.SetInt("score", platforms);
        Debug.Log("Saved score " + PlayerPrefs.GetInt("score"));
    }

    void OnCollisionExit2D(Collision2D collision) 
    { 
        if (collision.gameObject.CompareTag("Ground")) 
        { 
            isGRounded = false;
        } 
    } 

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if(other.gameObject.tag == "coin")
    //     {
    //         Destroy(other.gameObject);
    //         coins++;
    //         onTakeCoin?.Invoke(coins);
    //     }
    // }
}
