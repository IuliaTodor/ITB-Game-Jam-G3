public interface IDamageable
{
    public abstract float MaxLife { get; set; }
    public abstract float CurrentLife { get; set; }
    public abstract void TakeDamage(float damageTaken);

    public abstract void SetLife(float life);

    public abstract void Die();
}
