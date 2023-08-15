﻿using Microsoft.AspNetCore.Http;

namespace VModels.ViewModels;

public class CreateSchoolViewModel
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PicturePath { get; set; } = string.Empty;
    public int OrganizationId { get; set; }
    public SelectList? OrganizationOptions { get; set; }
    public IFormFile Picture { get; set; }
}
