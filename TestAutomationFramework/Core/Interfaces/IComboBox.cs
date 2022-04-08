using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IComboBox
    {
        public List<string> GetList();

        public void ClickOn(string item);
    }
}
