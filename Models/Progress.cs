using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

[Table("Progress",Schema="js")]
public class Progress
{
    public Progress(){
        Task=new HashSet<Task>();
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProgressId { get; set; }
    [StringLength(64)]
    public string ProgressName { get; set; }
    
    public virtual ICollection<Task> Task { get; set; }
}