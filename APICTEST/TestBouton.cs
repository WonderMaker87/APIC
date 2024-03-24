using Bunit;

public class ImageDetailIntegrationTests : TestContext
{
    [Fact]
    public void ImageDetailComponent_RendersCorrectly()
    {
        // Arrange
        var jsInterop = this.JSInterop.Setup<String>("getFavoriteImages");
        jsInterop.SetResult("[]");

        var testImageId = "testImage123";

        // Act
        var component = RenderComponent<APIC.Pages.ImageDetail>(parameters =>
        {
            parameters.Add(p => p.ImageId, testImageId);
        });

        // Assert
        Assert.NotEmpty(component.Markup);
    }
}
