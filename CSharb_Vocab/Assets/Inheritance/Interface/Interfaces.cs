public interface IHit<T1, T2>
{
    void GotHit(T1 attacker, T2 damageTaken);
}

public interface Iinteract
{
    void Interacted();    
}
