using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_13_WPF_ToDo_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> items = new List<string>();
        List<Task> tasks = new List<Task>();
        Task task;
        List<Category> categories = new List<Category>();
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }
        //void InitialiseListBoxOfStrings()
        //{

        //   ListBoxTasks.ItemsSource = items;

        //    using(var db = new TasksDBEntities())
        //    {


        //        tasks = db.Tasks.ToList();

        //    }
        //    // get the description and add to list
        //    foreach (var item in tasks)
        //    {
        //        items.Add($"{item.TaskId,-10}{item.Description,-40}{item.Done,-10}{item.DateCompleted}");
        //    }
        //}

        void Initialise()
        {
            using (var db = new TasksDBEntities())
            {
                tasks = db.Tasks.ToList();
                categories = db.Categories.ToList();
            }
            ListBoxTasks.ItemsSource = tasks;
            ListBoxTasks.DisplayMemberPath = "Description";
            ComboBoxCategory.ItemsSource = categories;
            ComboBoxCategory.DisplayMemberPath = "CategroyName";
            
        }

        private void ListBoxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //print out details of selecgted item
            // instance = (convert to task) the item selected in listbox by user
            task = (Task)ListBoxTasks.SelectedItem;
            if (task != null)
            {
                TextBoxID.Text = task.TaskId.ToString();
                TextBoxDescription.Text = task.Description;
                CategoryID.Text = task.CategoryId.ToString();
                ButtonEdit.IsEnabled = true;
                ButtonDelete.IsEnabled = true;

                if (task.CategoryId != null)
                {
                    ComboBoxCategory.SelectedIndex = (int)task.CategoryId-1;
                }
                else
                {
                    ComboBoxCategory.SelectedItem = null;
                }
            }
           
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonEdit.Content.ToString() == "Edit")
            {
                TextBoxDescription.IsReadOnly = false;
                CategoryID.IsReadOnly = false;
                ButtonEdit.Content = "Save";
                TextBoxDescription.Background = Brushes.White;
                CategoryID.Background = Brushes.White;
            }
            else
            {
                using (var db = new TasksDBEntities())
                {
                    var taskToEdit = db.Tasks.Find(task.TaskId);
                    // update description & categoryId
                    taskToEdit.Description = TextBoxDescription.Text;

                    //converting categoryid to integer from text box (string)
                    // tryparse is a safe way to do conversion: null if fails
                    int.TryParse(CategoryID.Text, out int categoryid);
                    taskToEdit.CategoryId = categoryid;

                    if (task.CategoryId != null)
                    {
                        ComboBoxCategory.SelectedIndex = (int)task.CategoryId - 1;
                    }
                    else
                    {
                        ComboBoxCategory.SelectedItem = null;
                    }
                    // save to database
                    db.SaveChanges();

                    ListBoxTasks.ItemsSource = null; //  reset list box
                    tasks = db.Tasks.ToList();       // get fresh link

                    ListBoxTasks.ItemsSource = tasks; // re-link 
                }
                ButtonEdit.Content = "Edit";
                ButtonEdit.IsEnabled = false;
                TextBoxDescription.IsReadOnly = true;
                CategoryID.IsReadOnly = true;
                var brush = new BrushConverter();
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#E8FBFF");
                CategoryID.Background = (Brush)brush.ConvertFrom("#E8FBFF");
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if(ButtonAdd.Content.ToString() == "Add")
            {
                //set boxes to editable
                ButtonAdd.Content = "Confirm";
                TextBoxDescription.Background = Brushes.White;
                CategoryID.Background = Brushes.White;

                TextBoxDescription.IsReadOnly = false;
                CategoryID.IsReadOnly = false;
                //clear out boxes
                TextBoxID.Text = " ";
                TextBoxDescription.Text = " ";
                CategoryID.Text = " ";
            }
            else
            {
                ButtonAdd.Content = "Add";
                TextBoxDescription.IsReadOnly = true;
                CategoryID.IsReadOnly = true;
                var brush = new BrushConverter();
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#E8FBFF");
                CategoryID.Background = (Brush)brush.ConvertFrom("#E8FBFF");

                using (var db = new TasksDBEntities())
                {
                    Task newTask = new Task
                    {
                        Description = TextBoxDescription.Text,
                        CategoryId = Convert.ToInt32(CategoryID.Text)

                        
                    };

                    db.Tasks.Add(newTask);

                    // save to database
                    db.SaveChanges();

                    ListBoxTasks.ItemsSource = null; //  reset list box
                    tasks = db.Tasks.ToList();       // get fresh link

                    ListBoxTasks.ItemsSource = tasks; // re-link 
                }
                ButtonAdd.Content = "Add";
                TextBoxDescription.IsReadOnly = true;
                CategoryID.IsReadOnly = true;
                brush = new BrushConverter();
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#E8FBFF");
                CategoryID.Background = (Brush)brush.ConvertFrom("#E8FBFF");
            }

        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonDelete.Content.ToString() == "Delete")
            {
                
                ButtonDelete.Content = "Are You Sure?";
                TextBoxDescription.Background = Brushes.White;
                CategoryID.Background = Brushes.White;
                TextBoxDescription.IsReadOnly = false;
                CategoryID.IsReadOnly = false;
                TextBoxID.Background = Brushes.Red;
                TextBoxDescription.Background = Brushes.Red;
                CategoryID.Background = Brushes.Red;
            }
            else
            {
                
                using (var db = new TasksDBEntities())
                {
                    

                    var taskToDelete = db.Tasks.Find(task.TaskId);
                        db.Tasks.Remove(taskToDelete);

                        db.SaveChanges();

                        ListBoxTasks.ItemsSource = null; //  reset list box
                        tasks = db.Tasks.ToList();       // get fresh link

                        ListBoxTasks.ItemsSource = tasks; // re-link 
                    
                }

                ButtonDelete.Content = "Delete";
                ButtonDelete.IsEnabled = false;
                TextBoxID.Text = " ";
                TextBoxDescription.Text = " ";
                CategoryID.Text = " ";
                var brush = new BrushConverter();
                TextBoxID.Background = (Brush)brush.ConvertFrom("#E8FBFF");
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#E8FBFF");
                CategoryID.Background = (Brush)brush.ConvertFrom("#E8FBFF");
            }

        }

        private void ListBoxTasks_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            // set the boxes for edit conditions
            task = (Task)ListBoxTasks.SelectedItem;

            if(task != null)
            {

                TextBoxID.Text = task.TaskId.ToString();
                TextBoxDescription.Text = task.Description;
                CategoryID.Text = task.CategoryId.ToString();
                ButtonEdit.IsEnabled = true;
                ButtonEdit.Content = "Save";
                TextBoxDescription.Background = Brushes.White;
                CategoryID.Background = Brushes.White;

                if (task.CategoryId != null)
                {
                    ComboBoxCategory.SelectedIndex = (int)task.CategoryId - 1;
                }
                else
                {
                    ComboBoxCategory.SelectedItem = null;
                }

                
            }

            TextBoxID.Text = task.TaskId.ToString();
            TextBoxDescription.Text = task.Description;
            CategoryID.Text = task.CategoryId.ToString();
            ButtonEdit.IsEnabled = true;
            ButtonEdit.Content = "Save";
        }
        private void TableSwitch()
        {

        }
    }
    
}
