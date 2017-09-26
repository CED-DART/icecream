using System;

public partial class RequestChangePassword
{
    public int IdUser { get; set; }
    public string Password { get; set; }
    public string NewPassword { get; set; }
    public string Token { get; set; }
}