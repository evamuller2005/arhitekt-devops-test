using System.Text.Json;

namespace Arhitekt.Models;

public class Project
{
    public int ProjectID { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime? DateCreated { get; set; }

    // JSON v bazi
    public string? ImagesJson { get; set; }

    // JavaScript-style list in C#
    public List<string> Images
    {
        get => string.IsNullOrEmpty(ImagesJson)
            ? new List<string>()
            : JsonSerializer.Deserialize<List<string>>(ImagesJson);

        set => ImagesJson = JsonSerializer.Serialize(value);
    }
}
