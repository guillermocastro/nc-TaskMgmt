using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

[Table("Bucket",Schema="js")]
public class Bucket
{
    public Bucket(){
        Task=new HashSet<Task>();
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BucketId { get; set; }
    [StringLength(64)]
    public string BucketName { get; set; }
    
    public virtual ICollection<Task> Task { get; set; }
}