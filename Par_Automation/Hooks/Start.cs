using TechTalk.SpecFlow;
using Par.Utils;

namespace Par.Hooks
{
    public class Start : Driver
    {
        [BeforeScenario("@local")]
        public void SetupFirefox()
        {
            Intitialize("local");
        }

        [BeforeScenario("@firefox")]
        public void SetupFirefox()
        {
            Intitialize("WIN_10_FIREFOX");
        }

        [BeforeScenario("@chrome")]
        public void SetupChrome()
        {
            Intitialize("WIN_10_CHROME");
        }

        [AfterScenario()]
        public void TearDown()
        {
            Close();
        }
        
    }
}
