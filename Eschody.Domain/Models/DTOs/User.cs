﻿namespace Eschody.Domain.Models.DTOs;

public class User
{
    public Guid Identifier { get; set; }
    public string? Nickname { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
    public DateTime RegisteredOn { get; set; }
}