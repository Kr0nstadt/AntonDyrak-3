using System.ComponentModel.DataAnnotations.Schema;

namespace Perchev_Kyrsach.Model;

public class User
{
    [Column("name")]
    public string Name { get; set; }

    [Column("points")]
    public int Points { get; set; }
}