using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;


namespace addressbook_white
{
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void TestGroupeCreation () 
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData newGroup = new GroupData()
            { Name = "TestTEST03!!" };
            app.Groups.AddGroup(newGroup);
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();
            //Assert.That(oldGroups, Is.EquivalentTo(newGroups));
           ClassicAssert.AreEqual(oldGroups,newGroups);
           // Assert.That(oldGroups.Count, Is.EqualTo(newGroups.Count));
        }
    }
}
