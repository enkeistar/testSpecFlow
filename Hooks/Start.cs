using TechTalk.SpecFlow;
using Par.Utils;

namespace Par.Hooks
{
    public class Start : Driver
    {
        
        [BeforeScenario()]
        public void Setup()
        {
            Intitialize();
        }

        [AfterScenario()]
        public void TearDown()
        {
            Close();
        }
        
    }
}
