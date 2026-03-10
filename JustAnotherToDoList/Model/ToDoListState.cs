namespace JustAnotherToDoList.Model
{
    public class ToDoListState
    {
        public int TotalItemsAdded { get; set; }
        public Dictionary<int, ToDoListItemModel> ToDoListItems { get; set; } = new();
    }
}
