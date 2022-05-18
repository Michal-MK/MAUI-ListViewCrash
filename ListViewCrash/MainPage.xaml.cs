using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ListViewCrash;

public partial class MainPage : ContentPage {
	public MainPage() {
		InitializeComponent();
		DeleteCommand = new MyCommand(DeleteAction);
		BindingContext = this;
	}

	private void DeleteAction(object obj) {
		Items.Remove(obj as string);
	}

	public ICommand DeleteCommand { get; set; }

	public ObservableCollection<string> Items { get; set; } = new() {
		"Hello",
		"World",
	};
}

public class MyCommand : ICommand {
	public event EventHandler CanExecuteChanged;

	public MyCommand(Action<object> a) {
		aa = a;
	}

	Action<object> aa;

	public bool CanExecute(object parameter) {
		return true;
	}

	public void Execute(object parameter) {
		aa?.Invoke(parameter);
	}
}

