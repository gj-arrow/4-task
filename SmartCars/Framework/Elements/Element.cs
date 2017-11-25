using OpenQA.Selenium;

namespace Framework.Elements
{
    public class Element : BaseElement
    {
        public Element(By locator) : base (locator)
        {
        }

        public Element(By locator, string name) : base(locator, name)
        {
        }
    }
}
