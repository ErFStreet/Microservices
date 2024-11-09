namespace Microservice.Domain.Entities.Bussiness;

public class Blog : BaseEntity<int>
{
    [StringLength(100)]
    [Required]
    public string Title { get; set; } = default!;

    [StringLength(300)]
    [Required]
    public string Content { get; set; } = default!;

    [Required]
    public int UserId { get; set; } = default!;
}