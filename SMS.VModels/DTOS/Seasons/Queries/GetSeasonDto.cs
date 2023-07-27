﻿namespace SMS.VModels.DTOS;

public class GetSeasonDto
{
    public int Id { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public bool IsCurrent { get; set; }
    public string School { get; set; } = string.Empty;
}
