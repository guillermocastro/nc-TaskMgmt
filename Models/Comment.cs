using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

[Table("Comment",Schema="js")]
public class Comment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CommentId { get; set; }
    [ForeignKey("Task")]
    public int TaskId { get; set; }
    [DataType(DataType.MultilineText)]
    public string Text { get; set; }
    [StringLength(128)]
    public string Author { get; set; }

    public virtual Task Task { get; set; }
}