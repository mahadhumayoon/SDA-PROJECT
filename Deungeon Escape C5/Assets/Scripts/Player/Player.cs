using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour , IDamageable
{
    public int diamond;

    private Rigidbody2D _rigid;
    [SerializeField]
    private float _jumpForce = 0.5f;
    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private bool grounded = false;
    [SerializeField]
    private bool resetjumpneeded = false;
    private bool _grounded = false;
    private PlayerAnimation _PlayerAnim;
    private SpriteRenderer _PlayerSprite;
    private SpriteRenderer _SwordArcSprite;

    public int Health { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _PlayerAnim = GetComponent<PlayerAnimation>();
        _PlayerSprite = GetComponentInChildren<SpriteRenderer>();
        _SwordArcSprite = transform.GetChild(1).GetComponentInChildren<SpriteRenderer>();
        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Fight();
        Jump();
    }

    void Movement()
    {
        float move = CrossPlatformInputManager.GetAxis("Horizontal"); //Input.GetAxisRaw("Horizontal");
        Jump();
        _grounded = CheckGrounded();

        if (move > 0)
        {
            Flip(true);
        }
        else if (move < 0)
        {
            Flip(false);
        }

        if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("B_Button")) && grounded == true)
        {
           // Debug.Log("jump!");
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            grounded = false;
            resetjumpneeded = true;

            StartCoroutine(Resetjumpneededroutine());

        }
        _rigid.velocity = new Vector2(move * speed, _rigid.velocity.y);
        _PlayerAnim.Move(move);
    }
    bool CheckGrounded()
    {
        RaycastHit2D Hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.green);
        if (Hit.collider != null)
        {
            if (resetjumpneeded == false)
            {
               // Debug.Log("Grounded");

                return true;
            }
        }
        return false;
    }
    void Flip(bool faceRight)
    {
        if (faceRight == true)
        {
            _PlayerSprite.flipX = false;
            _SwordArcSprite.flipX = false;
            _SwordArcSprite.flipY = false;
            Vector3 newPos = _SwordArcSprite.transform.localPosition;
            newPos.x = 0.83f;
            _SwordArcSprite.transform.localPosition = newPos;
        }
        else if (faceRight == false)
        {
            _PlayerSprite.flipX = true;
            _SwordArcSprite.flipX = true;
            _SwordArcSprite.flipY = true;
            Vector3 newPos = _SwordArcSprite.transform.localPosition;
            newPos.x = -0.83f;
            _SwordArcSprite.transform.localPosition = newPos;
        }
    }
    IEnumerator Resetjumpneededroutine()
    {

        yield return new WaitForSeconds(1.2f);
        resetjumpneeded = false;
        grounded = true;

    }
    void Fight()
    {
        if (CrossPlatformInputManager.GetButtonDown("A_Button") && grounded == true)
        {
            _PlayerAnim.Attack();
        }
    }
    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("B_Button")) && grounded == true)
        {
            _PlayerAnim.Jump(true);
        }
        else if (resetjumpneeded == false)
        {
            _PlayerAnim.Jump(false);
        }
    }

    public void Damage()
    {
        if(Health<1)
        {
            return;
        }
        Debug.Log("Player : Damage");
        Health--;
        UIManager.instance.UpdateLives(Health);
        if(Health < 1)
        {
            _PlayerAnim.Death();
        }
    }

    public void AddGems(int amount)
    {
        diamond += amount;
        UIManager.instance.UpdateGemCount(diamond);
    }
}
