using OnboardingSIGDB1.Domain.Services;

namespace OnboardingSIGDB1.Tests;

public class UnitTest1
{
    [Fact]
    public void DeveCalcular()
    {
        var service = new EmpresaServices();

        var result = service.CalculoDoisMaisUm();

        Assert.Equal(3, result);
    }
}