using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        Console[] products = {
            new Console(2699.99f,"PlayStation 5","p.jpg",
                "\r\nTyp konsoli: PlayStation 5 Slim\r\n\r\nPojemność dysku twardego: 1 TB\r\n\r\nProcesor: AMD Ryzen Zen 2 (8 rdzeni, 3.5 GHz)\r\n\r\nWyposażenie: 2 stopki podstawki poziomej, Kabel HDMI, Kabel USB, Kabel zasilający, Kontroler DualSense\r\n\r\nInformacje dodatkowe: Kompatybilność wsteczna – możliwość uruchamiania gier z PS4, Technologia dźwięku 3D, Wsparcie 4K/HDR\r\n\r\nPamieć RAM: 16GB GDDR6\r\n\r\nUkład graficzny: AMD Radeon Navi RDNA\r\n\r\n", 
                "\r\nKonsola PlayStation 5 Slim wyróżnia się elegancką, smukłą konstrukcją, która robi niezwykłe wrażenie, a do tego zabiera mniej miejsca niż standardowa wersja PS5. W zestawie znajdują się 2 stopki podstawki poziomej, ale by bardziej wyeksponować konsolę, możesz ustawić ją w pionie - do tego potrzebna będzie opcjonalna podstawka pionowa (brak w zestawie).\r\n\r\nTak jak podstawowa wersja, PS5 Slim występuje w dwóch wariantach - Digital i Standard z napędem Blu-ray. Względem poprzedniej wersji, w Slim zmieniono porty USB z wersji A na wersję C, a napęd w wersji Standard ma konstrukcję modułową - możesz go wyjąć z konsoli bez użycia narzędzi.\r\n\r\nUltraszybki dysk SSD o pojemności 1 TB zapewnia błyskawiczne czasy ładowania. Zainstalowane na konsoli PS5 gry będą ładować się w mgnieniu oka. Wykorzystując moc procesora niestandardowego, procesora graficznego i dysku SSD ze zintegrowanym We/Wy, stworzono nowe zasady tego, na co stać konsolę PlayStation. Co oznacza mniej czekania na loading!"),
            new Console(2999.99f,"Xbox Series X","xsx.jpg",
                "\r\nTyp konsoli: Xbox Series X\r\n\r\nPojemność dysku twardego: 1 TB\r\n\r\nProcesor: AMD Zen 2 - 3.8 GHz (8 rdzeni, 3.6 GHz z SMT)\r\n\r\nWyposażenie: Bezprzewodowy kontroler, Kabel HDMI, Kabel zasilający\r\n\r\nInformacje dodatkowe: Kompatybilność wsteczna – możliwość uruchamiania gier z Xbox 360, Xbox One, Możliwość podłączenia dysku twardego\r\n\r\nPamieć RAM: 16GB GDDR6\r\n\r\nUkład graficzny: AMD RDNA 2, 52 CUs 1.825GHz, 12 TFLOPS\r\n\r\n",
                "\r\nPoznaj Xbox Series X, szybką i potężną konsolę Xbox w historii. Odkryj ekscytujące światy 12 teraflopów czystej mocy przetwarzania grafiki, śledzenia promieni DirectX i gier 4K. Wykorzystaj w pełni każdą minutę gry dzięki funkcji szybkiego wznawiania, szybkiemu ładowaniu i szybkości do 120 klatek na sekundę dzięki technologii Xbox Velocity Architecture.\r\n\r\nWykorzystaj w pełni każdą minutę gry dzięki technologii Quick Resume, zapewniającej możliwość szybkiego wznowienia wcześniej zakończonej rozgrywki. Dodatkowo możesz uzyskać w grach aż do 120 klatek na sekundę dzięki architekturze Xbox Velocity*.\r\n\r\nZminimalizuj czas ładowania i zwiększ liczbę klatek na sekundę dzięki specjalnie zaprojektowanemu dyskowi SSD NVMe, który umożliwia działanie większych, bardziej wymagających gier z pełną wydajnością. Ożyw swoje gry i filmy dzięki bogatemu, dynamicznemu i wysokiej jakości dźwiękowi."),
            new Console(1399.99f,"Xbox Series S","xss.jpg",
                "\r\nTyp konsoli: Xbox Series S\r\n\r\nPojemność dysku twardego: 512 GB\r\n\r\nProcesor: AMD Zen 2 - 3.8 GHz (8 rdzeni, 3.6 GHz z SMT)\r\n\r\nWyposażenie: Bezprzewodowy kontroler, Kabel HDMI, Kabel zasilający\r\n\r\nInformacje dodatkowe: Kompatybilność wsteczna – możliwość uruchamiania gier z Xbox 360, Xbox One\r\n\r\nPamieć RAM: 10 GB GDDR6\r\n\r\nUkład graficzny: AMD RDNA 2, 20 CUs 1.565GHz, 4 TFLOPS\r\n\r\n",
                "\r\nXbox Series S w kolorze białym zapewnia szybkość i wydajność. Wykorzystaj w pełni każdą minutę gry dzięki funkcji szybkiego wznawiania, szybkiemu ładowaniu i szybkości do 120 klatek na sekundę dzięki technologii Xbox Velocity Architecture. Graj w gry cyfrowe z czterech generacji konsol Xbox dzięki setkom zoptymalizowanych gier, które wyglądają lepiej i zapewniają lepsze wrażenia z gry niż kiedykolwiek wcześniej.\r\n\r\nWykorzystaj w pełni każdą minutę gry dzięki technologii Quick Resume, zapewniającej możliwość szybkiego wzowienia wcześniej zakończonej rozgrywki. Dodatkowo możesz uzystakać w grach aż do 120 klatek na sekundę dzięki architekturze Xbox Velocity*.\r\n\r\nDzięki dostępowi do Disney+, Netflix, Amazon, Hulu, Filmy i TV Microsoft i nie tylko*, możesz cieszyć się filmami i serialami nawet na swojej konsoli. Rozrywka ma więcej niż jedno oblicze!")
        };

        int actual = 0;
        float discount = 0f;

        public MainWindow()
        {
            InitializeComponent();
            setProduct(actual);
        }

        void setProduct(int i)
        {
            Console console = products[i];
            Title.Text = console.name;
            Price.Text = console.price.ToString() + " zł";
            string path = "zdj/" + console.path;
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new System.Uri(path, System.UriKind.Relative);
            bitmapImage.EndInit();
            Img.Source = bitmapImage;
            Specs.Text = console.GetSpecs();
            desc.Text = console.GetDesc();
        }

        void changeProduct(bool operation)
        {
            actual = operation ? (actual + 1) % products.Length : (actual == 0 ? products.Length - 1 : actual - 1);
            setProduct(actual);
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            changeProduct(true);
        }

        private void PreBtn_Click(object sender, RoutedEventArgs e)
        {
            changeProduct(false);
        }

        void cart(Console product)
        {
            string path = "tx/cart.txt";
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(product.name);
                }
            }
            catch
            {
                MessageBox.Show("Błąd podczas dodawania do koszyka");
            }
        }

        void cart()
        {
            File.WriteAllText("tx/cart.txt", string.Empty);
        }

        float getCartPrice()
        {
            float cartPrice = 0f;
            string[] dataFromFile = File.ReadAllLines("tx/cart.txt");
            foreach (string line in dataFromFile)
            {
                foreach (Console product in products)
                {
                    if (product.name == line)
                    {
                        cartPrice += product.price;
                    }
                }
            }

            cartPrice -= discount;

            return cartPrice;
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            cart(products[actual]);
        }

        private void ApplyDiscountBtn_Click(object sender, RoutedEventArgs e)
        {
            string discountCode = DiscountCodeTextBox.Text.Trim().ToUpper(); 

            Console console = products[actual];

            if (console.IsDiscountApplied)
            {
                MessageBox.Show("Rabat został już wykorzystany dla tego produktu.", "Błąd");
                return;
            }

            if (discountCode == "RABAT")
            {
                float discountAmount = 200f;
                float originalPrice = console.price;
                float discountedPrice = originalPrice - discountAmount;

                discountedPrice = discountedPrice < 0 ? 0 : discountedPrice;

                MessageBox.Show($"Został uwzględniony rabat 200 zł. Nowa cena produktu: {Math.Round(discountedPrice, 2)} zł", "Rabat został zastosowany");

                Price.Text = $"{Math.Round(discountedPrice, 2)} zł";

                console.price = discountedPrice;

                console.IsDiscountApplied = true;
            }
            else
            {
                MessageBox.Show("Niepoprawny kod rabatowy.", "Błąd");
            }
        }

        private void cartBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string[] dataFromFile = File.ReadAllLines("tx/cart.txt");

            string cartDetails = "";
            float totalPrice = 0f;

            foreach (string line in dataFromFile)
            {
                foreach (Console product in products)
                {
                    if (product.name == line)
                    {
                        cartDetails += $"{product.name} - {product.price} zł\n";
                        totalPrice += product.price;
                    }
                }
            }

            cartDetails += $"\nSuma: {totalPrice} zł";

            MessageBoxResult result = MessageBox.Show(cartDetails, "Czy potwierdzasz swój zakup?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Koszt całkowity: " + Math.Round(totalPrice,2) + " zł");
                cart();
            }

        }
    }

    public class Console
    {
        public float price;
        public string name;
        public string path;
        private string specs;
        private string description;
        public bool IsDiscountApplied { get; set; }

        public Console(float price, string name, string path, string specs, string description)
        {
            this.price = price;
            this.name = name;
            this.path = path;
            this.specs = specs;
            this.description = description;
            this.IsDiscountApplied = false;
        }

        public string GetSpecs() { return specs; }
        public string GetDesc() { return description; }
    }
}