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
        private static int ChiccoPrice = 22;
        private static int GiraffePrice = 60;
        private static int ZoboPrice = 80;
        private static int CimcaPrice = 100;
        private static int TucnacekPrice = 500;
        private static string DatabaseFilePath { get { return "db.txt"; } }

        private enum ExampleType
        {
            /// <summary>2 + 3 =</summary>
            Num1PlusNum2,

            /// <summary>3 - 2 =</summary>
            Num1MinusNum2,

            /// <summary>2 + x = 4</summary>
            Num1PlusXEqualsNum2,
        
            /// <summary>x + 3 = 4</summary>
            XPlusNum1EqualsNum2,

            /// <summary>2 + 3 = x</summary>
            Num1PlusNum2EqualsX,

            /// <summary>2 . x = 6</summary>
            Num1MultipliedByXEqualsNum2,
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private int _result;
        private int _successPrice;
        private int _failPrice;
        private string _exampleText;
        private bool _isEquation;
        private int _settingsMoney;
        private string _settingsSelectedMonster;
        private bool _settingsHasChicco;
        private bool _settingsHasGiraffe;
        private bool _settingsHasZobo;
        private bool _settingsHasCimca;
        private bool _settingsHasTucnacek;
        private string _image1Location;
        private string _image2Location;

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
                new SoundPlayer(@"Zvuky/cinkot peněz.wav").Play();

                IncreaseMoney(_successPrice);
                SaveSettings();
            }
            // špatný výsledek
            else
            {
                new SoundPlayer(@"Zvuky/špatně.wav").Play();
                MessageBox.Show(string.Format("Ale néé, máš to blbě, správný výsledek je {0}.", _result));
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
            LoadSettings();
            CreateNewExample();
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
                fileContent = "0;Nikdo;False;False;False;False;False";
            }

            string[] values = fileContent.Split(new [] {";"}, StringSplitOptions.RemoveEmptyEntries);

            if (values.Length >= 1) _settingsMoney = Convert.ToInt32(values[0]);
            if (values.Length >= 2) _settingsSelectedMonster = values[1];
            if (values.Length >= 3) _settingsHasChicco = Convert.ToBoolean(values[2]);
            if (values.Length >= 4) _settingsHasGiraffe = Convert.ToBoolean(values[3]);
            if (values.Length >= 5) _settingsHasZobo = Convert.ToBoolean(values[4]);
            if (values.Length >= 6) _settingsHasCimca = Convert.ToBoolean(values[5]);
            if (values.Length >= 7) _settingsHasTucnacek = Convert.ToBoolean(values[6]);

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
            string fileContent = string.Format("{0};{1};{2};{3};{4};{5};{6}",
                _settingsMoney,
                _settingsSelectedMonster,
                _settingsHasChicco,
                _settingsHasGiraffe,
                _settingsHasZobo,
                _settingsHasCimca,
                _settingsHasTucnacek);

            File.WriteAllText(DatabaseFilePath, fileContent);
        }

        private void UpdateMonster()
        {
            if (_settingsSelectedMonster == "Nikdo")
            {
                _image1Location = "Obrázky/Nikdo.png";
                _image2Location = "Obrázky/Nikdo s penízkem.png";
            }
            else if (_settingsSelectedMonster == "Chicco")
            {
                _image1Location = "Obrázky/Čiko.png";
                _image2Location = "Obrázky/Čiko s penízkem.png";
            }
            else if (_settingsSelectedMonster == "Giraffe")
            {
                _image1Location = "Obrázky/Žirafka.png";
                _image2Location = "Obrázky/Žirafka s penízkem.png";
            }
            else if (_settingsSelectedMonster == "Zobo")
            {
                _image1Location = "Obrázky/Zobo.png";
                _image2Location = "Obrázky/Zobo s penízkem.png";
            }
            else if (_settingsSelectedMonster == "Cimca")
            {
                _image1Location = "Obrázky/Čimča.png";
                _image2Location = "Obrázky/Čimča s penízkem.png";
            }
            else if (_settingsSelectedMonster == "Tucnacek")
            {
                _image1Location = "Obrázky/Tučňáček.png";
                _image2Location = "Obrázky/Tučňáček s penízkem.png";
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
            if (_settingsHasChicco)
            {
                buttonChicco.Text = "Čiko";
                buttonChicco.Enabled = true;
            }
            else
            {
                buttonChicco.Text = string.Format("Čiko {0} Kč", ChiccoPrice);
                buttonChicco.Enabled = (_settingsMoney >= ChiccoPrice);
            }

            if (_settingsHasGiraffe)
            {
                buttonGiraffe.Text = "Žirafka";
                buttonGiraffe.Enabled = true;
            }
            else
            {
                buttonGiraffe.Text = string.Format("Žirafka {0} Kč", GiraffePrice);
                buttonGiraffe.Enabled = (_settingsMoney >= GiraffePrice);
            }

            if (_settingsHasZobo)
            {
                buttonZobo.Text = "Zobo";
                buttonZobo.Enabled = true;
            }
            else
            {
                buttonZobo.Text = string.Format("Zobo {0} Kč", ZoboPrice);
                buttonZobo.Enabled = (_settingsMoney >= ZoboPrice);
            }

            if (_settingsHasCimca)
            {
                buttonCimca.Text = "Čimča";
                buttonCimca.Enabled = true;
            }
            else
            {
                buttonCimca.Text = string.Format("Čimča {0} Kč", CimcaPrice);
                buttonCimca.Enabled = (_settingsMoney >= CimcaPrice);
            }

            if (_settingsHasTucnacek)
            {
                buttonTucnacek.Text = "Tučňáček";
                buttonTucnacek.Enabled = true;
            }
            else
            {
                buttonTucnacek.Text = string.Format("Tučňáček {0} Kč", TucnacekPrice);
                buttonTucnacek.Enabled = (_settingsMoney >= TucnacekPrice);
            }
        }

        private void UpdateLabelMoney()
        {
            labelMoney.Text = string.Format("{0} Kč", _settingsMoney);
        }

        private void buttonChicco_Click(object sender, EventArgs e)
        {
            if (_settingsHasChicco)
            {
                _settingsSelectedMonster = "Chicco";
                SaveSettings();
            }
            else if (_settingsMoney >= ChiccoPrice && MessageBox.Show(string.Format("Chcete koupit Čika za {0} Kč?", ChiccoPrice), "Obchod", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _settingsHasChicco = true;
                _settingsMoney -= ChiccoPrice;
                _settingsSelectedMonster = "Chicco";
                SaveSettings();
                new SoundPlayer(@"Zvuky/fanfára.wav").Play();
            }
            textBox.Focus();
        }

        private void buttonGiraffe_Click(object sender, EventArgs e)
        {
            if (_settingsHasGiraffe)
            {
                _settingsSelectedMonster = "Giraffe";
                SaveSettings();
            }
            else if (_settingsMoney >= GiraffePrice && MessageBox.Show(string.Format("Chcete koupit Žirafku za {0} Kč?", GiraffePrice), "Obchod", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _settingsHasGiraffe = true;
                _settingsMoney -= GiraffePrice;
                _settingsSelectedMonster = "Giraffe";
                SaveSettings();
                new SoundPlayer(@"Zvuky/fanfára.wav").Play();
            }
            textBox.Focus();
        }

        private void buttonZobo_Click(object sender, EventArgs e)
        {
            if (_settingsHasZobo)
            {
                _settingsSelectedMonster = "Zobo";
                SaveSettings();
            }
            else if (_settingsMoney >= ZoboPrice && MessageBox.Show(string.Format("Chcete koupit Zoba za {0} Kč?", ZoboPrice), "Obchod", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _settingsHasZobo = true;
                _settingsMoney -= ZoboPrice;
                _settingsSelectedMonster = "Zobo";
                SaveSettings();
                new SoundPlayer(@"Zvuky/fanfára.wav").Play();
            }
            textBox.Focus();
        }

        private void buttonCimca_Click(object sender, EventArgs e)
        {
            if (_settingsHasCimca)
            {
                _settingsSelectedMonster = "Cimca";
                SaveSettings();
            }
            else if (_settingsMoney >= CimcaPrice && MessageBox.Show(string.Format("Chcete koupit Čimču za {0} Kč?", CimcaPrice), "Obchod", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _settingsHasCimca = true;
                _settingsMoney -= CimcaPrice;
                _settingsSelectedMonster = "Cimca";
                SaveSettings();
                new SoundPlayer(@"Zvuky/fanfára.wav").Play();
            }
            textBox.Focus();
        }

        private void buttonTucnacek_Click(object sender, EventArgs e)
        {
            if (_settingsHasTucnacek)
            {
                _settingsSelectedMonster = "Tucnacek";
                SaveSettings();
            }
            else if (_settingsMoney >= TucnacekPrice && MessageBox.Show(string.Format("Chcete koupit Tučňáčka za {0} Kč?", TucnacekPrice), "Obchod", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _settingsHasTucnacek = true;
                _settingsMoney -= TucnacekPrice;
                _settingsSelectedMonster = "Tucnacek";
                SaveSettings();
                new SoundPlayer(@"Zvuky/fanfára.wav").Play();
            }
            textBox.Focus();
        }
    }
}
