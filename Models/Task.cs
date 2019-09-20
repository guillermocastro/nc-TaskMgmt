using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

[Table("Task",Schema="js")]
public class Task
{
    public Task(){
        Comment=new HashSet<Comment>();
        Link=new HashSet<Link>();
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TaskId { get; set; }
    [StringLength(128)]
    public string TaskName { get; set; }
    [ForeignKey("Bucket")]
    public int BucketId { get; set; }
    public int? ParentId { get; set; }
    [StringLength(128)]
    public string Customer { get; set; }
    [StringLength(128)]
    public string Owner { get; set; }
    [ForeignKey("Progress")]
    public int ProgressId { get; set; }
    public int Priority { get; set; }
    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime? DueDate { get; set; }
    [DataType(DataType.MultilineText)]
    public string Description { get; set; }

    public virtual ICollection<Comment> Comment { get; set; }
    public virtual ICollection<Link> Link { get; set; }
    public virtual Bucket Bucket { get; set; }
    public virtual Progress Progress { get; set; }
}