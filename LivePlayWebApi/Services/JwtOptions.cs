namespace LivePlayWebApi.Services;

public class JwtOptions
{
    public string SecretKey { get; set; } = string.Empty;
    public int ExpitersHours { get; set; }
}
