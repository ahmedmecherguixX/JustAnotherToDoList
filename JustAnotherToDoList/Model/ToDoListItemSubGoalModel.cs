namespace JustAnotherToDoList.Model
{
    public class ToDoListItemSubGoalModel
    {
        private int _id;
        public string SubGoalName = "";
        public bool IsComplete = false;
        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public ToDoListItemSubGoalModel(string subGoalName)
        {
            SubGoalName = subGoalName;
            Id = ToDoListModel.TotalItemsAdded;
        }
    }
}
