using Microsoft.AspNetCore.Identity;

namespace DotNetAuthDemo.Entities;

public class Person:IdentityUser
{
    public string? Initials { get; set; } = null!;
}