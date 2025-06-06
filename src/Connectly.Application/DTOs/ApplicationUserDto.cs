﻿namespace Connectly.Application.DTOs;

public class ApplicationUserDto 
{
    public Guid Id { get; set; } = Guid.NewGuid(); 
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

}