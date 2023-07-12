using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerController : MonoBehaviour
{
    public PlayerModel PlayerModel;
    private Rigidbody2D _playerRigidbody;

    [HideInInspector]
    public GameObject PlayerSword;

    public float PlayerSpeed;
    public float PlayerJumpForce;
    public bool HasWeapon;

    void Awake()
    {
        PlayerModel = new PlayerModel();
        _playerRigidbody = GetComponent<Rigidbody2D>();

        PlayerModel.IsUsingWeapon = false;

        PlayerModel.Score = 0f;
        PlayerModel.Speed = PlayerSpeed;
        PlayerModel.JumpForce = PlayerJumpForce;
        PlayerModel.HasWeapon = HasWeapon;
    }

    void Update()
    {
        Movement(PlayerModel.Speed, PlayerModel.JumpForce);
        if(Input.GetMouseButtonDown(0) && PlayerModel.HasWeapon && !PlayerModel.IsUsingWeapon) 
        {
            StartCoroutine(Attack(PlayerSword));
        }
    }


    private void Movement(float speed, float jumpForce)
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            if (Mathf.Abs(_playerRigidbody.velocity.y) < 0.001f)
            {
                _playerRigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }

        }
    }
    private IEnumerator Attack(GameObject weapon)
    {
        PlayerModel.IsUsingWeapon = true;
        weapon.transform.localPosition = new Vector3(0.8f, -0.2f, 0f);
        weapon.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        weapon.GetComponent<BoxCollider2D>().enabled = true;

        yield return new WaitForSeconds(0.5f);

        weapon.GetComponent<BoxCollider2D>().enabled = false;
        weapon.transform.localPosition = new Vector3(0.2f, 0.2f, 0f);
        weapon.transform.localRotation = Quaternion.Euler(0f, 0f, 95f);
        PlayerModel.IsUsingWeapon = false;
    }
}
