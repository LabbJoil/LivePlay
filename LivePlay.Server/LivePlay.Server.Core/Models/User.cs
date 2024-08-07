﻿
using LivePlay.Server.Core.Enums;

namespace LivePlay.Server.Core.Models;

public class User
{
    public Guid Id { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Points { get; set; }
    public Role[] Roles { get; set; } = [];
}
