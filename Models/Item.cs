using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Models;

public partial class Item
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public int? CategoryId { get; set; }

    public bool? IsDeleted { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }

    [StringLength(50)]
    public string? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Items")]
    public virtual Category? Category { get; set; }

    [InverseProperty("Item")]
    public virtual ICollection<ItemClients> ItemClients { get; set; } = new List<ItemClients>();

    [InverseProperty("Item")]
    public virtual ICollection<SerialNumber> SerialNumbers { get; set; } = new List<SerialNumber>();
}
