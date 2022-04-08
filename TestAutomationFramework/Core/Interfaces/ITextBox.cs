namespace Core.Interfaces
{
    public interface ITextBox
    {
        public void SendKeys(string text);

        public string GetValue();
    }
}
