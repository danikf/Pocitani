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
        private ExampleCollection _examples;
        private IMonster _currentMonster;

        //promenne prikladu
        private IExample _currentExample;
        //private int _successPrice;
        //private int _failPrice;
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
            if (result == _currentExample.Result)
            {
                new SoundPlayer(@"Zvuky/správně.wav").Play();
                pictureBoxMonster.ImageLocation = _image2Location;
                MessageBox.Show("Super! Paráda! Máš to správně.");
                pictureBoxMonster.ImageLocation = _image1Location;
                if (_currentMonster != null)
                    _currentMonster.OnSuccess();
                new SoundPlayer(@"Zvuky/cinkot peněz.wav").Play();

                IncreaseMoney(_currentExample.SuccessPrice);
                SaveSettings();
            }
            // špatný výsledek
            else
            {
                new SoundPlayer(@"Zvuky/špatně.wav").Play();
                MessageBox.Show($"Ale néé, máš to blbě, správný výsledek je {_currentExample.Result}.");
                if (_currentMonster != null)
                    _currentMonster.OnFail();
                new SoundPlayer(@"Zvuky/odebrání peněz.wav").Play();

                DecreaseMoney(_currentExample.FailPrice);
                SaveSettings();
            }

            CreateNewExample();
        }

        private void CreateNewExample()
        {
            var exampleFrequecies = _examples.ToDictionary(exampleDef => exampleDef, exampleDef => _currentMonster != null ? _currentMonster.GetExampleFrequencyByMonster(exampleDef) : exampleDef.Frequency);

            var examplesForMonster = exampleFrequecies.SelectMany(exampleDefPair => Enumerable.Repeat(exampleDefPair.Key, exampleDefPair.Value));
                
            if (!examplesForMonster.Any())
            {
                MessageBox.Show("Vyber si jiného plyšáka. Tomuto už příklady došly.");
            }
            else
            {
                var random = new Random();
                int randomIndex = random.Next(examplesForMonster.Count());

                var exampleDef = examplesForMonster.ToArray()[randomIndex];
                _currentExample = exampleDef.CreateExample(random);
                if (_currentMonster != null)
                    _currentMonster.UpdateExampleByMonster(_currentExample); //callback na potvoru - muze menit example       //TODO tato implementace ma za nasledek, ze zmena zvirete po zadani prikladu se uz neprojevi        

                labelExample.Text = _currentExample.Text;
                labelX.Visible = _currentExample.IsEquation;
                labelEquals.Visible = _currentExample.IsEquation;
                textBox.Text = "";
                textBox.Focus();
                UpdateLabelMoney();
                pictureBoxMonster.ImageLocation = _image1Location;
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadMonsters();
            LoadExamples();
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

        private void LoadExamples()
        {
            _examples = new ExampleCollection("examples.xml");
        }

        private void FocusOrBuyAnimal(IMonster monster)
        {
            if (monster != _currentMonster)
            {
                if (monster.Bought)
                {
                    _currentMonster = monster;
                    SaveSettings();
                }
                else if (_settingsMoney >= monster.Price && MessageBox.Show($"Chcete koupit {monster.NameGenitive} za {monster.Price} Kč?", "Obchod", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    monster.Bought = true;
                    _settingsMoney -= monster.Price;
                    _currentMonster = monster;
                    SaveSettings();
                    new SoundPlayer(@"Zvuky/fanfára.wav").Play();
                }

                // CreateNewExample(); //TODO pri zmene plysaka vygenerujeme priklad, dle jeho specifikace ??
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
                _currentMonster = _monsters.FindById(values[1]);
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
                string.Join(";", new List<string>() { _settingsMoney.ToString(), _currentMonster != null ? _currentMonster.Id : "nikdo" }
                                    .Concat(_monsters.Select(m => m.Bought.ToString())));
               
            File.WriteAllText(DatabaseFilePath, fileContent);
        }

        private void UpdateMonster()
        {
            if (_currentMonster == null)
            {
                _image1Location = "Obrázky/Nikdo.png";
                _image2Location = "Obrázky/Nikdo s penízkem.png";
            }
            else
            {
                _image1Location = Path.Combine("Obrázky", _currentMonster.Image);
                _image2Location = Path.Combine("Obrázky", _currentMonster.Image2);
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
