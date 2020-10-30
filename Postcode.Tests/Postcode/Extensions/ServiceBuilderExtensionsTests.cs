using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Postcode.Contracts;
using Postcode.Extensions;
using Postcode.Models;

namespace Postcode.Tests.Postcode.Extensions
{
    [TestFixture]
    public class ServiceBuilderExtensionsTests
    {
        [Test]
        public void GivenNoProviderRegistered_WhenAddPostcodeCalled_ExpectNullArgumentThrown()
        {
            var serviceBuilderMock = new Mock<IServiceCollection>();

            var sut = serviceBuilderMock.Object;
            Action func = () => sut.AddPostcode(b => { });

            func.Should().Throw<ArgumentNullException>().WithMessage("*At least one provider must be registered.*");
        }

        [Test]
        public void GivenFakeProviderRegistered_WhenAddPostcodeCalled_ExpectPostcodeLookupRegistered()
        {
            var serviceBuilderMock = new Mock<IServiceCollection>();
            var fakeProvider = new FakeClient();

            var sut = serviceBuilderMock.Object;
            sut.AddPostcode(b => b.RegisterProvider(fakeProvider));

            serviceBuilderMock.Verify(v =>
                v.Add(It.Is<ServiceDescriptor>(s => s.ImplementationInstance == fakeProvider)), Times.Once);
        }
    }
}