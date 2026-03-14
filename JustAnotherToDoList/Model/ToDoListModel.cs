using System.Text.Json;
using System.Xml.Linq;

namespace JustAnotherToDoList.Model
{
    public static class ToDoListModel
    {
        public static readonly string FilePath = "ToDoList.json";

        private static int _totalItemsAdded;

        public static int TotalItemsAdded
        {
            get { return ++_totalItemsAdded; }
            private set { _totalItemsAdded = value; }
        }

        public static Dictionary<int, ToDoListItemModel> ToDoListItems = new();

        public static void AddItem(ToDoListItemModel itemAdded)
        {
            ToDoListItems.Add(itemAdded.Id, itemAdded);
            SaveList();
        }

        static ToDoListModel()
        {
            if (!File.Exists(FilePath)) 
            {
                SaveList();
                return;
            }

            string json = File.ReadAllText(FilePath);

            if(string.IsNullOrWhiteSpace(json))
            {
                return;
            }

            var state = JsonSerializer.Deserialize<ToDoListState>(json);

            if(state is not null)
            {
                _totalItemsAdded = state.TotalItemsAdded;
                ToDoListItems = state.ToDoListItems ?? new();
            }
        }

        public static void SaveList()
        {
            var state = new ToDoListState()
            {
                ToDoListItems = ToDoListItems,
                TotalItemsAdded = _totalItemsAdded
            };
            string json = JsonSerializer.Serialize(state,
                new JsonSerializerOptions { WriteIndented = true});
            File.WriteAllText(FilePath, json);
        }
    }
}

