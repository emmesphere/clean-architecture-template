using NetArchTest.Rules;

using Shouldly;

namespace CleanArchitectureTemplate.ArchitectureTests;
public class LayeringTests
{
    [Fact]
    public void Domain_ShouldNotDependOn_Infrastructure()
    {
        var result = Types.InAssembly(typeof(Domain.CleanArchitectureTemplateDomainMarker).Assembly)
            .ShouldNot()
            .HaveDependencyOn("CleanArchitectureTemplate.Infrastructure")
            .GetResult();

        result.IsSuccessful.ShouldBeTrue(result.ToString());
    }

    [Fact]
    public void Application_ShouldNotDependOn_Infrastructure()
    {
        var result = Types.InAssembly(typeof(Application.Abstractions.CleanArchitectureTemplateApplicationMarker).Assembly)
            .ShouldNot()
            .HaveDependencyOn("CleanArchitectureTemplate.Infrastructure")
            .GetResult();

        result.IsSuccessful.ShouldBeTrue(result.ToString());
    }

    [Fact]
    public void Domain_ShouldNotDependOn_WebApi()
    {
        var result = Types.InAssembly(typeof(Domain.CleanArchitectureTemplateDomainMarker).Assembly)
            .ShouldNot()
            .HaveDependencyOn("CleanArchitectureTemplate.WebApi")
            .GetResult();

        result.IsSuccessful.ShouldBeTrue(result.ToString());
    }

    [Fact]
    public void Application_ShouldNotDependOn_WebApi()
    {
        var result = Types.InAssembly(typeof(Application.Abstractions.CleanArchitectureTemplateApplicationMarker).Assembly)
            .ShouldNot()
            .HaveDependencyOn("CleanArchitectureTemplate.WebApi")
            .GetResult();

        result.IsSuccessful.ShouldBeTrue(result.ToString());
    }
}
