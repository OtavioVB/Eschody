﻿namespace Eschody.Domain.Models.ValueObjects;

public class Version
{
    public string Value { get; private set; }

    public Version(string value)
    {
        Value = value;
    }
}
