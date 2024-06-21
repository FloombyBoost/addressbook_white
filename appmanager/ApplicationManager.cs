using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;



namespace addressbook_white
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
      
        public ApplicationManager() 
        {
            Application app = Application.Launch(@"C:\C#\AddressBook.exe");
             
             MainWindow = app.GetWindow(WINTITLE);

      
            groupHepler = new GroupHepler(this);
        }
        private GroupHepler groupHepler;
        public void Stop ()
        {
            MainWindow.Get<Button>("uxExitAddressButton").Click();
            

        }

       public Window MainWindow { get; private set; }
        public GroupHepler Groups 
        {
            get { return groupHepler; }
        }
    }
}
