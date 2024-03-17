using System;
using System.Text.Json;
using Xunit;
using APIC;

public class ApiSimpleResponseTests
{
    [Fact]
    public void SerializationAndDeserialization_WorksCorrectly()
    {
        var original = new ApiSimpleResponse
        {
            Id = "1",
            Url = "http://example.com/image.jpg",
            Tags = new List<string> { "cute", "fluffy" },
            CreatedAt = new DateTime(2020, 1, 1),
            UpdatedAt = new DateTime(2020, 1, 2),
            Mimetype = "image/jpeg",
            Size = 1024
        };
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        var jsonString = JsonSerializer.Serialize(original, options);
        var deserialized = JsonSerializer.Deserialize<ApiSimpleResponse>(jsonString, options);

        Assert.NotNull(deserialized);
        Assert.Equal(original.Id, deserialized?.Id);
        Assert.Equal(original.Url, deserialized?.Url);
        Assert.Equal(original.Tags.Count, deserialized?.Tags.Count);
        Assert.Equal(original.CreatedAt, deserialized?.CreatedAt);
        Assert.Equal(original.UpdatedAt, deserialized?.UpdatedAt);
        Assert.Equal(original.Mimetype, deserialized?.Mimetype);
        Assert.Equal(original.Size, deserialized?.Size);
    }
}
