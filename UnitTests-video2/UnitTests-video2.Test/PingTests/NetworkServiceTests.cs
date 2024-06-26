﻿
using FluentAssertions;
using UnitTests_video2.Ping;

namespace UnitTests_video2.Test.PingTests
{
    public class NetworkServiceTests
    {
        [Fact]//possibilita que ele seja identficado como um teste
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange -  variables, classes, mocks....
            var pingService = new NetworkService();

            //Act
            var result = pingService.SendPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent !");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory] //permite que voce passe variaveis
        [InlineData(1,1,2)]//
        [InlineData(2,2,4)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            //Arrange
            var pingService = new NetworkService();

            //Act
            var result = pingService.PingTimeout(a, b);

            //Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-1000, 0);

        }
    }
}
