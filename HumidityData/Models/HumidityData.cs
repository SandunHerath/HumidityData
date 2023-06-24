using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HumidityData.Models;

public class HumidityData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int BuildingId { get; set; }
    public int FloorId { get; set; }
    public int RoomId { get; set; }
    [Column(TypeName = "float")]
    public float H { get; set; }
    public DateTime Timestamp { get; set; }
}