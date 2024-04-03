
namespace UnitTests_video1.Tests
{
    public static class WorldsDumbestFunctionTest
    {
        //Naming Convention- ClassName_MethodName_ExpectedResults
        public static void WorldsDumbestFunction_ReturnsPikachuIfZero_ReturnString()
        {
            try
            {
                //Arrange - go get our variables, whatever you need
                int num = 0;
                WorldsDumbestFunction worldsDumbest =  new WorldsDumbestFunction();

                //Act - execute this function
                string result = worldsDumbest.ReturnsPikachuIfZero(num);

                //Assert - Whatever ever is returned is it what you want
                if (result == "PIKACHU!")
                {
                    Console.WriteLine("PASSED: WorldsDumbestFunction_ReturnsPikachuIfZero_ReturnString");
                }
                else 
                { 
                    Console.WriteLine("FAILED: WorldsDumbestFunction_ReturnsPikachuIfZero_ReturnString"); 
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
