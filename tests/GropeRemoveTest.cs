using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;


namespace addressbook_white
{
    public class GroupRemoveTests : TestBase
    {
        [Test]
        public void TestGroupeRemoveWithDeleteContact()
        {
            bool FlagSaveContact = false;
            var NumberOfDelete = 0;
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[NumberOfDelete];
            
            app.Groups.RemoveGroup(oldData,FlagSaveContact);
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Remove(oldData);
            oldGroups.Sort();
            newGroups.Sort();
            //Assert.That(oldGroups, Is.EquivalentTo(newGroups));
            ClassicAssert.AreEqual(oldGroups,newGroups);
            // Assert.That(oldGroups.Count, Is.EqualTo(newGroups.Count));
        }


        [Test]
        public void TestGroupeRemoveWithSaveContact()
        {
            bool FlagSaveContact = true;
            var NumberOfDelete = 0;
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[NumberOfDelete];

            app.Groups.RemoveGroup(oldData, FlagSaveContact);
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Remove(oldData);
            oldGroups.Sort();
            newGroups.Sort();
            //Assert.That(oldGroups, Is.EquivalentTo(newGroups));
            ClassicAssert.AreEqual(oldGroups, newGroups);
            // Assert.That(oldGroups.Count, Is.EqualTo(newGroups.Count));
        }












    }




}
