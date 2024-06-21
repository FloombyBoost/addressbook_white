using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.White.UIItems;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.Finders;
using System.Windows.Automation;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.Actions;




namespace addressbook_white
{
    public class GroupHepler : HelperBase
    {

        public static string WINGROUPTITLE = "Group editor";
        public static string WINDELETEGROUP = "Delete group";
        public GroupHepler(ApplicationManager manager) : base(manager) 
        {

            

        }

        public void AddGroup(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialogue();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);



          // aux.Send(newGroup.Name);
            //aux.Send("{ENTER}");
            CloseGroupDialogue(dialogue);

        }

        public void CloseGroupDialogue(Window dialog)
        {
            dialog.Get<Button>("uxCloseAddressButton").Click();
        }

        public Window OpenGroupsDialogue()
        {

            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(WINGROUPTITLE);
        

        }


        public Window OpenGroupsDialogueDelete()
        {

            manager.MainWindow.ModalWindow(WINGROUPTITLE).Get<Button>("uxDeleteAddressButton").Click();
            return manager.MainWindow.ModalWindow(WINGROUPTITLE).ModalWindow(WINDELETEGROUP);


        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue =  OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }

            

            CloseGroupDialogue(dialogue);
            return list;

        }

        public void RemoveGroup(GroupData oldData, bool FlagSaveContact)
        {

            if (FlagSaveContact == false)
            {

                Window dialogue = OpenGroupsDialogue();
             
                var SelecttextBox = dialogue.Get(SearchCriteria.ByText(oldData.Name));
                //SelecttextBox.Focus();
                SelecttextBox.Click();
                Window dialogueDelete = OpenGroupsDialogueDelete();

                dialogueDelete.Get<RadioButton>("uxDeleteAllRadioButton").Click();
               
                dialogueDelete.Get<Button>("uxOKAddressButton").Click();

                CloseGroupDialogue(dialogue);
            }
            else
            {
                Window dialogue = OpenGroupsDialogue();
                var SelecttextBox = dialogue.Get(SearchCriteria.ByText(oldData.Name));
                SelecttextBox.Click();
                Window dialogueDelete = OpenGroupsDialogueDelete();
                dialogueDelete.Get<RadioButton>("uxDeleteGroupsOnlyRadioButton").Click();
                dialogueDelete.Get<Button>("uxOKAddressButton").Click();
                CloseGroupDialogue(dialogue);
            }


            
           



        }
    }
}