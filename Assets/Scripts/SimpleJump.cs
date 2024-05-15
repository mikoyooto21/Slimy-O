using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimpleJump : MonoBehaviour
{
    public float jumpForce = 10f; // Сила стрибка
    public float airControl = 2f; // Керування у повітрі
    public float squatScale = 0.5f; // Масштаб при присіданні
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private bool isSquatting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Знаходимо кнопки на екрані
        Button jumpButton = GameObject.Find("JumpButton").GetComponent<Button>();
        EventTrigger squatTrigger = GameObject.Find("SquatButton").GetComponent<EventTrigger>();

        // Налаштовуємо подію для стрибка
        jumpButton.onClick.AddListener(Jump);

        // Налаштовуємо події для присідання
        AddEventTrigger(squatTrigger, EventTriggerType.PointerDown, (data) => { StartSquat(); });
        AddEventTrigger(squatTrigger, EventTriggerType.PointerUp, (data) => { StopSquat(); });
    }

    void Update()
    {
        // Керування у повітрі
        if (!isGrounded)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            rb.velocity += new Vector2(horizontalInput * airControl, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5)
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        animator.SetBool("isGrounded", false);
    }

    private void Jump()
    {
        if (isGrounded && !isSquatting)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            rb.gravityScale = 1.65f; // Зменшення сили тяжіння
            animator.SetTrigger("isJumping");
        }
    }

    private void StartSquat()
    {
        if (isGrounded && !isSquatting)
        {
            isSquatting = true;
            transform.localScale = new Vector3(transform.localScale.x, squatScale * transform.localScale.y, transform.localScale.z);
            animator.SetBool("isSquatting", true);
        }
    }

    private void StopSquat()
    {
        if (isSquatting)
        {
            isSquatting = false;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / squatScale, transform.localScale.z);
            animator.SetBool("isSquatting", false);
        }
    }

    private void AddEventTrigger(EventTrigger trigger, EventTriggerType type, System.Action<BaseEventData> action)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;
        entry.callback.AddListener((data) => action(data));
        trigger.triggers.Add(entry);
    }
}
