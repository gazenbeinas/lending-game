namespace LendingGame.Infra.Identity.Models
{
    public enum AuthenticationResultCode
    {
        Succeeded = 1,
        IsLockedOut = 2,
        NotAllowed = 3
    }
}