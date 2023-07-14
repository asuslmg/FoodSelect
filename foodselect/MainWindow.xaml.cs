using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace FoodSelectionApp
{
    public partial class MainWindow : Window
    {
        private List<string> foods;
        private Random random;
        private bool isSelecting;

        public MainWindow()
        {
            InitializeComponent();

            random = new Random();
            isSelecting = false;

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFoodList();

            StartTimer();
        }

        private void LoadFoodList()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string foodListPath = Path.Combine(desktopPath, "foodlist.txt");
            foods = ReadFoodListFromFile(foodListPath);

            foodListBox.Items.Clear();
            foreach (string food in foods)
            {
                foodListBox.Items.Add(food);
            }
        }

        private void StartTimer()
        {
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
            dateLabel.Content = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!isSelecting)
            {
                isSelecting = true;
                DisableButtons();
                AnimateFoodSelection();
                
            }
        }

        private async void AnimateFoodSelection()
        {
            int foodListLength = foodListBox.Items.Count;
            bool allItemSame = false;
            if (foodListLength > 1)
            {
                var firstItem = foodListBox.Items[0];

                for (int i = 1; i < foodListBox.Items.Count; i++)
                {
                    if (!firstItem.Equals(foodListBox.Items[i]))
                    {
                        allItemSame = true;
                    }
                }
                if (allItemSame)
                {
                    StartFixedCountdown();
                    TimeSpan additionalTime = TimeSpan.FromSeconds(foodListLength - 5);
                    TimeSpan duration = TimeSpan.FromSeconds(5) + additionalTime;
                    var endTime = DateTime.Now.Add(duration);
                    resultTextBlock.Text = "";

                    TimeSpan interval = TimeSpan.FromMilliseconds(100); // 定义延迟的时间间隔

                    while (DateTime.Now < endTime)
                    {
                        int selectedIndex = random.Next(foodListBox.Items.Count);
                        foodListBox.SelectedIndex = selectedIndex;

                        if (DateTime.Now >= endTime)
                            break;

                        await Task.Delay(interval);
                    }

                    int finalIndex = random.Next(foodListBox.Items.Count);
                    foodListBox.SelectedIndex = finalIndex;

                    // 倒计时等待时间
                    var countdownDuration = TimeSpan.FromSeconds(3) + additionalTime;
                    var countdownEndTime = DateTime.Now.Add(countdownDuration);

                    //while (DateTime.Now < countdownEndTime)
                    //{
                    //    await Task.Delay(interval);
                    //}

                    resultTextBlock.Text = $"今天我要吃：\n{foodListBox.SelectedItem}";
                }
                else
                {
                    resultTextBlock.Text = $"都是一个菜\n你玩我呢？";
                }
            }
            else
            {
                resultTextBlock.Text = $"就一个菜\n你说你费什么劲！";

            }
            resultTextBlock.Visibility = Visibility.Visible;

            isSelecting = false;
            EnableButtons();
        }





        private List<string> ReadFoodListFromFile(string filePath)
        {
            List<string> foodList = new List<string>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                foreach (string line in lines)
                {
                    foodList.Add(line);
                }
            }

            return foodList;
        }

        private void DisableButtons()
        {
            selectButton.IsEnabled = false;
            //resetButton.IsEnabled = false;
            reloadButton.IsEnabled = false;
        }

        private void EnableButtons()
        {
            selectButton.IsEnabled = true;
            //resetButton.IsEnabled = true;
            reloadButton.IsEnabled = true;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            foodListBox.SelectedIndex = -1;
            resultTextBlock.Text = string.Empty;
            resultTextBlock.Visibility = Visibility.Hidden;
        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadFoodList();
        }

        private async void StartFixedCountdown()
        {
            int foodListLength = foodListBox.Items.Count;
            TimeSpan additionalTime = TimeSpan.FromSeconds(foodListLength - 5);
            var countdownDuration = TimeSpan.FromSeconds(3) + additionalTime;
            int countdownDurationInSeconds = (int)countdownDuration.TotalSeconds;
            int countdownDurationSeconds = countdownDurationInSeconds+2;
            var countdownEndTime = DateTime.Now.AddSeconds(countdownDurationSeconds);

            while (DateTime.Now < countdownEndTime)
            {
                int remainingSeconds = (int)Math.Ceiling((countdownEndTime - DateTime.Now).TotalSeconds);
                countdownTextBlock.Text = $"倒计时: {remainingSeconds}秒";
                await Task.Delay(1000);
                countdownTextBlock.Text = "";
            }

            
            await Task.Delay(1000);

            //AnimateFoodSelection();
        }

    }
}
