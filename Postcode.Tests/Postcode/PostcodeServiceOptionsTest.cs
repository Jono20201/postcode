using System;
using FluentAssertions;
using NUnit.Framework;
using Postcode.Exceptions;

namespace Postcode.Tests.Postcode
{
    [TestFixture]
    public class PostcodeServiceOptionsTest
    {
        [Test]
        public void GivenProviderRegistered_WhenRegisterProviderCalled_ThenClientAssignedToProperty()
        {
            var fakeClient = new FakeClient();
            
            var sut = new PostcodeServiceOptions();
            
            sut.RegisterProvider(fakeClient);

            sut.Client.Should().Be(fakeClient);
        }

        [Test]
        public void GivenMoreThanOneCall_WhenRegisterProviderCalled_ThenThrowProviderAlreadyRegisteredException()
        {
            var fakeClient = new FakeClient();
            
            var sut = new PostcodeServiceOptions();
            sut.RegisterProvider(fakeClient);

            Action act = () => sut.RegisterProvider(fakeClient);

            act.Should().Throw<ProviderAlreadyRegisteredException>();
        }
    }
}