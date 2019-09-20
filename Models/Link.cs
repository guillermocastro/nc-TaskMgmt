using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;


[Table("Link",Schema="js")]
public class Link
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LinkId { get; set; }
    [ForeignKey("Task")]
    public int TaskId { get; set; }
    [StringLength(256)]
    public string URL { get; set; }
    [StringLength(128)]
    public string LinkName { get; set; }

    public virtual Task Task { get; set; }
}