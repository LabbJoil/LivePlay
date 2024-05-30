namespace LivePlay.Infrastructure;

public class JwtOptions
{
    public string ISSUER { get; set; } = string.Empty;
    public string AUDIENCE { get; set; } = string.Empty;
    public string SecretKey { get; set; } = string.Empty;
    public int ExpitersHours { get; set; }
}
