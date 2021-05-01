using UnityEngine;

public class HorizontalMovingEnemy : HorizontalMovingObject
{
    private SpriteRenderer enemySpriteRenderer;

    protected override void Start()
    {
        base.Start();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (transform.position == InitialPosition.position)
        {
            enemySpriteRenderer.flipX = true;
        }
        else if (transform.position == FinalPosition.position)
        {
            enemySpriteRenderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
