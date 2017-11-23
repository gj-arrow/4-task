using System.Collections.Generic;
using OpenQA.Selenium;
using UISelectElement = OpenQA.Selenium.Support.UI.SelectElement;

namespace Framework.Elements
{
    public class SelectElement : BaseElement
    {
        private UISelectElement _select;
        public SelectElement(By locator) : base (locator)
        {
            WaitUntilDisplayed();
            _select = new UISelectElement(Element);
        }

        public SelectElement(By locator, string name) : base (locator, name)
        {
            WaitUntilDisplayed();
            _select = new UISelectElement(Element);
        }

        public List<string> Options ()
        {
            List<string> optionsString = new List<string>();
            foreach (var option in _select.Options)
            {
                optionsString.Add(option.Text);
            }
             return optionsString; 
        }

        public void SelectValue(string value)
        {
            WaitUntilDisplayed();
            _select.SelectByText(value);
        }

        public string SelectedOption()
        {
            WaitUntilDisplayed();
            var selectedOption =_select.SelectedOption.Text;
            return selectedOption;
        }
    }
}
