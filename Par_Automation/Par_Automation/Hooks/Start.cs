using TechTalk.SpecFlow;
using Par.Utils;
using System.Configuration;
namespace Par.Hooks
{
    public class Start : Driver
    {
        [BeforeScenario()]
        public void SetupLocal()
        {
            var browser = ConfigurationManager.AppSettings["Browser"];
            Initialize(browser);
        }

        [AfterScenario()]
        public void TearDown()
        {
            Close();
        }
        
    }
}
