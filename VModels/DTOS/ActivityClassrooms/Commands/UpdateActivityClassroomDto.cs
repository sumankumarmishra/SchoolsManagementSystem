﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VModels.DTOS;

public class UpdateActivityClassroomDto
{
    public int Id { get; set; }
    public int ActivityId { get; set; }
    public int ClassroomId { get; set; }
}
