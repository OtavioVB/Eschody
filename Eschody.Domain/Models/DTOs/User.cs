﻿namespace Eschody.Domain.Models.DTOs;

public class User
{
    public int DataIdentifier { get; set; }
    public Guid ApplicationIdentifier { get; set; }
    public string? Username { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime Created { get; set; }
}
