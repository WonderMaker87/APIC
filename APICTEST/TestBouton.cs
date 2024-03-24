using Bunit;
using RichardSzalay.MockHttp;
using Microsoft.Extensions.DependencyInjection;
using APIC.Pages;

public class CatImageComponentTests : TestContext
{
    [Fact]
    public void NewCatImage_IsLoadedOnClick()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("https://cataas.com/cat?json=true")
                .Respond("application/json", "{\"id\":\"abc\",\"url\":\"https://cataas.com/cat/abc\",\"tags\":[\"cute\"],\"createdAt\":\"\",\"updatedAt\":\"\",\"mimetype\":\"image/jpeg\",\"size\":123}"); // Réponse JSON simulée

        Services.AddSingleton<HttpClient>(new HttpClient(mockHttp));

        var component = RenderComponent<Home>();

        // Act
        component.Find("#call").Click();

        // Assert
        var imgElement = component.Find("img");
        Assert.NotNull(imgElement);
        Assert.Equal("https://cataas.com/cat/abc", imgElement.GetAttribute("src")); 
        Assert.Equal("cute", imgElement.GetAttribute("alt"));
    }
}
