namespace Projectile
{
    public interface IProjectile
    {
        void TickApproaching();

        // попали ли в данный момент
        bool DidHit();
        void DestroyProjectile();
    }
}
