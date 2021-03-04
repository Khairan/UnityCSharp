namespace RollABall
{
    public interface IInteractable : IAction, IInitialization
    {
        #region Fields
        
        bool IsInteractable { get; }

        #endregion
    }
}