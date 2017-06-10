using Počítání.Examples;
using Počítání.Monsters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Počítání
{
    public partial class MainForm : Form
    {
        private static string DatabaseFilePath { get { return "db.txt"; } }

        //plysaci
        private MonsterCollection _monsters;
        private IMonster _settingsSelectedMonster;

        //promenne prikladu
        private int _result;
        private int _successPrice;
        private int _failPrice;
        private string _exampleText;
        private bool _isEquation;
        private int _settingsMoney;

        //promenne grafickeho vyhledu
        private string _image1Location;
        private string _image2Location;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // test, zda je uživatelem napsaný text číslo
            int result;
            try
            {
                result = Convert.ToInt32(textBox.Text);
            }
            catch
            {
                new SoundPlayer(@"Zvuky/chybně zadané číslo.wav").Play();
                return;
            }

            // správný výsledek
            if (result == _result)
            {
                new SoundPlayer(@"Zvuky/správně.wav").Play();
                pictureBoxMonster.ImageLocation = _image2Location;
                MessageBox.Show("Super! Paráda! Máš to správně.");
                pictureBoxMonster.ImageLocation = _image1Location;
                if (_settingsSelectedMonster != null)
                    _settingsSelectedMonster.OnSuccess(ref _successPrice);
                new SoundPlayer(@"Zvuky/cinkot peněz.wav").Play();

                IncreaseMoney(_successPrice);
                SaveSettings();
            }
            // špatný výsledek
            else
            {
                new SoundPlayer(@"Zvuky/špatně.wav").Play();
                MessageBox.Show(string.Format("Ale néé, máš to blbě, správný výsledek je {0}.", _result));
                if (_settingsSelectedMonster != null)
                    _settingsSelectedMonster.OnFail(ref _failPrice);
                new SoundPlayer(@"Zvuky/odebrání peněz.wav").Play();

                DecreaseMoney(_failPrice);
                SaveSettings();
            }

            CreateNewExample();
        }

        private void CreateNewExample()
        {
            Action[] initExampleDelegates =
            {
                delegate { InitExample(ExampleType.Num1PlusNum2, 100, 100, 1, 3); },
                delegate { InitExample(ExampleType.Num1PlusNum2, 1000, 100, 2, 1); },
                delegate { InitExample(ExampleType.Num1PlusNum2, 1000, 1000, 3, 1); },
                delegate { InitExample(ExampleType.Num1MinusNum2, 100, 20, 1, 1); },
                //delegate { InitExample(ExampleType.Num1MinusNum2, 1000, 100, 2, 1); },
                delegate { InitExample(ExampleType.Num1PlusNum2EqualsX, 20, 20, 2, 1); },
                delegate { InitExample(ExampleType.Num1PlusXEqualsNum2, 20, 20, 3, 1); },
                delegate { InitExample(ExampleType.XPlusNum1EqualsNum2, 20, 20, 3, 1); },
                delegate { InitExample(ExampleType.Num1MultipliedByXEqualsNum2, 10, 30, 3, 1); },
            };

            var random = new Random();
            int randomIndex = random.Next(initExampleDelegates.Length);

            initExampleDelegates[randomIndex]();

            labelExample.Text = _exampleText;
            labelX.Visible = _isEquation;
            labelEquals.Visible = _isEquation;
            textBox.Text = "";
            textBox.Focus();
            UpdateLabelMoney();
            pictureBoxMonster.ImageLocation = _image1Location;
        }

        private void InitExample(ExampleType exampleType, int maxNumber1, int maxNumber2, int successPrice, int failPrice)
        {
            var random = new Random();
            _successPrice = successPrice;
            _failPrice = failPrice;

            if (exampleType == ExampleType.Num1PlusNum2)
            {
                int number1 = random.Next(maxNumber1) + 1;
                int number2 = random.Next(maxNumber2) + 1;
                _result = number1 + number2;
                _exampleText = string.Format("{0} + {1} =", number1, number2);
                _isEquation = false;
            }
            else if (exampleType == ExampleType.Num1MinusNum2)
            {
                int number1 = random.Next(maxNumber1) + 1;
                int number2 = random.Next(Math.Min(number1, maxNumber2)) + 1;
                _result = number1 - number2;
                _exampleText = string.Format("{0} - {1} =", number1, number2);
                _isEquation = false;
            }
            else if (exampleType == ExampleType.Num1PlusXEqualsNum2)
            {
                int number2 = random.Next(maxNumber1 - 1) + 2;
                int number1 = random.Next(Math.Min(number2, maxNumber1)) + 1;
                int x = number2 - number1;
                _result = x;
                _exampleText = string.Format("{0} + x = {1}", number1, number2);
                _isEquation = true;
            }
            else if (exampleType == ExampleType.XPlusNum1EqualsNum2)
            {
                int number2 = random.Next(maxNumber1 - 1) + 2;
                int number1 = random.Next(Math.Min(number2, maxNumber1)) + 1;
                int x = number2 - number1;
                _result = x;
                _exampleText = string.Format("x + {0} = {1}", number1, number2);
                _isEquation = true;
            }
            else if (exampleType == ExampleType.Num1PlusNum2EqualsX)
            {
                int number1 = random.Next(maxNumber1) + 1;
                int number2 = random.Next(maxNumber2) + 1;
                int x = number2 + number1;
                _result = x;
                _exampleText = string.Format("{0} + {1} = x", number1, number2);
                _isEquation = true;
            }
            else if (exampleType == ExampleType.Num1MultipliedByXEqualsNum2)
            {
                var possibleX = new int[] { 1, 2, 3, 10};
                int number1 = random.Next(maxNumber1) + 1;
                int index = random.Next(possibleX.Length);
                int x = possibleX[index];
                int number2 = number1 * x;
                _result = x;
                _exampleText = string.Format("{0} . x = {1}", number1, number2);
                _isEquation = true;
            }
            else
                throw new NotImplementedException(string.Format("Chyba, typ příkladu {0} není implementován.", exampleType));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadMonsters();
            LoadSettings();
            CreateNewExample();
        }

        private void LoadMonsters()
        {
            _monsters = new MonsterCollection("monsters.xml");

            //buttons
            int idx = 0;
            const int firstMonsterButtonLeft = 429;
            const int firstMonsterButtonTop = 129;
            const int monstersInRow = 5;
            foreach (var monster in _monsters)
            {
                //create button
                var monsterButton = new System.Windows.Forms.Button();
                monster.Button = monsterButton;

                monsterButton.Enabled = false;
                monsterButton.Image = System.Drawing.Image.FromFile(Path.Combine("Obrázky", monster.Thumbnail));
                monsterButton.Location = new System.Drawing.Point(firstMonsterButtonLeft + ((idx % monstersInRow) * 86), firstMonsterButtonTop + ((idx / monstersInRow) * 86)); //TODO
                monsterButton.Name = "button" + monster.Id;
                monsterButton.Size = new System.Drawing.Size(80, 70);
                monsterButton.TabIndex = 20 + idx;
                monsterButton.Text = monster.Name;
                monsterButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                monsterButton.UseVisualStyleBackColor = true;
                monsterButton.Click += (sender, args) => FocusOrBuyAnimal(monster);

                this.Controls.Add(monsterButton);

                idx++;
            }
        }

        private void FocusOrBuyAnimal(IMonster monster)
        {
            if (monster.Bought)
            {
                _settingsSelectedMonster = monster;
                SaveSettings();
            }
            else if (_settingsMoney >= monster.Price && MessageBox.Show($"Chcete koupit {monster.NameGenitive} za {monster.Price} Kč?", "Obchod", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                monster.Bought = true;
                _settingsMoney -= monster.Price;
                _settingsSelectedMonster = monster;
                SaveSettings();
                new SoundPlayer(@"Zvuky/fanfára.wav").Play();
            }
            textBox.Focus();
        }

        private void LoadSettings()
        {
            string fileContent;
            if (File.Exists(DatabaseFilePath))
            {
                fileContent = File.ReadAllText(DatabaseFilePath);
            }
            else
            {
                fileContent = "0;nikdo";
            }

            string[] values = fileContent.Split(new [] {";"}, StringSplitOptions.RemoveEmptyEntries);

            var monsterList = _monsters.ToList();

            if (values.Length >= 1) _settingsMoney = Convert.ToInt32(values[0]);
            if (values.Length >= 2)
                _settingsSelectedMonster = _monsters.FindById(values[1]);
            for(int idx = 0; idx < monsterList.Count; idx++ )
            {
                int arrayIdx = 2 + idx;
                if (values.Length >= arrayIdx + 1)
                    monsterList[idx].Bought = Convert.ToBoolean(values[arrayIdx]);
                else
                    monsterList[idx].Bought = false;
            }

            ApplySettings();
        }

        private void ApplySettings()
        {
            UpdateMonsterButtons();
            UpdateMonster();
            UpdateLabelMoney();
        }

        private void SaveSettings()
        {
            ApplySettings();
            string fileContent =
                string.Join(";", new List<string>() { _settingsMoney.ToString(), _settingsSelectedMonster != null ? _settingsSelectedMonster.Id : "nikdo" }
                                    .Concat(_monsters.Select(m => m.Bought.ToString())));
               
            File.WriteAllText(DatabaseFilePath, fileContent);
        }

        private void UpdateMonster()
        {
            if (_settingsSelectedMonster == null)
            {
                _image1Location = "Obrázky/Nikdo.png";
                _image2Location = "Obrázky/Nikdo s penízkem.png";
            }
            else
            {
                _image1Location = Path.Combine("Obrázky", _settingsSelectedMonster.Image);
                _image2Location = Path.Combine("Obrázky", _settingsSelectedMonster.Image2);
            }

            pictureBoxMonster.ImageLocation = _image1Location;
        }

        private void IncreaseMoney(int value)
        {
            _settingsMoney += value;
        }

        private void DecreaseMoney(int value)
        {
            _settingsMoney -= value;
            if (_settingsMoney < 0)
            {
                _settingsMoney = 0;
            }
        }

        private void UpdateMonsterButtons()
        {
            foreach(var monster in _monsters)
            {
                monster.Button.Text = monster.Bought ? monster.Name : $"{monster.Name} {monster.Price} Kč";
                monster.Button.Enabled = monster.Bought || _settingsMoney >= monster.Price;
            }
        }

        private void UpdateLabelMoney()
        {
            labelMoney.Text = string.Format("{0} Kč", _settingsMoney);
        }
    }
}
