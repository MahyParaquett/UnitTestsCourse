using FluentAssertions;
using FluentAssertions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using UnitTests_video3.Ping;

namespace UnitTests_video3.Test.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _networkService;
        public NetworkServiceTests()
        {//SUT- System under test

            _networkService = new NetworkService();
            
        }


        [Fact]//possibilita que ele seja identficado como um teste
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange -  variables, classes, mocks....
            

            //Act
            var result = _networkService.SendPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent !");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory] //permite que voce passe variaveis
        [InlineData(1, 1, 2)]//
        [InlineData(2, 2, 4)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            //Arrange
            

            //Act
            var result = _networkService.PingTimeout(a, b);

            //Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-1000, 0);
        }

        [Fact]//possibilita que ele seja identficado como um teste
        public void NetworkService_LastPingDate_ReturnDate()
        {
            //Arrange -  variables, classes, mocks....


            //Act
            var result = _networkService.LastPingDate();

            //Assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));
            
        }

        [Fact]
        public void NetworkService_GetPingOptions_RetursObject()
        {
            //Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
            //Act
            var result = _networkService.GetPingOptions();

            //Assert WARNING: "Be" careful
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
        }

        [Fact]
        public void NetworkService_MostRecentsPings_RetursObject()
        {
            //Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
            //Act
            var result = _networkService.MostRecentPings();

            //Assert WARNING: "Be" careful
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x=> x.DontFragment == true);
        }

    }
}
