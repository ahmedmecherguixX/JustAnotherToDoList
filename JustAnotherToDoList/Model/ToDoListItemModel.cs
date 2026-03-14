using JustAnotherToDoList.Components.Pages;

namespace JustAnotherToDoList.Model
{
    public class ToDoListItemModel
    {
		private int _id;
		private string _name = "";
		private string _description = "";
		private bool _isComplete;
		public Dictionary<int, ToDoListItemSubGoalModel> SubGoals;

		public bool IsComplete
		{
			get { return _isComplete; }
			set { _isComplete = value; }
		}
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		public int Id
		{
			get { return _id; }
			private set { _id = value; }
		}

        public ToDoListItemModel(string name,string description)
        {
			Id = ToDoListModel.TotalItemsAdded;
			Name = name;
			Description = description;
			IsComplete = false;
			SubGoals = new();
        }

		public void AddSubGoal(ToDoListItemSubGoalModel subGoal)
		{
			SubGoals.Add(subGoal.Id, subGoal);
		}

    }
}
