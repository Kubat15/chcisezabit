using System.Collections.ObjectModel;
using System.ComponentModel;

namespace chcisezabit;

public partial class NewPage2 : ContentPage
{
    private List<string> abilities = new List<string> { "aatroxw", "aurelionsolr", "tristanap", "xinzhaor", "alistarq", "akshan_p", "akali_p", "ahrir", "amumur",
    "aniviae", "anniep", "apheliosw", "ashee", "azirr", "bardw", "belvethw", "blitzcrankw", "brandp", "braumr", "caitlynr", "camillee", "cassiopeiar", "corki_p",
    "dariusr", "dianatel", "drmundo_p", "dravene", "ekko_p", "elisehumanq", "evelynne", "ezrealp", "fiddlesticksw", "fiorap", "fizzw", "galior", "gangplankw", "garenw", "gnare",
    "gragasp", "gravesq", "gwenp", "hecarimp", "heimerdingerw", "illaoie", "ireliae", "iverne", "jannap", "jarvanivp", "jaxe", "jaycep", "jhinw", "jinxw", "ksantee", "kaisaw",
    "kalistar", "karmaw", "karthusr", "kassadinp", "katarinap", "kaylee", "kaynw", "kennenw", "khazixw", "kindredq", "kledq", "kogmawe", "leblancr", "leesinr", "leonaq", "lilliar",
    "lissandrar", "lucianp", "lulur", "luxw", "malphiteq", "malzaharq", "maokaiq", "masteryip", "miliop", "missfortunee", "mordekaiserp", "morganae", "namiw", "nasusp", "nautilusp",
    "neekoe", "nidaleee", "nilahp", "nocturnew", "nunuwillumpp", "olafe", "orianaq", "ornnq", "pantheonq", "poppyr", "pyker", "qiyanaq", "quinne", "rakanq", "rammusr", "reksaip",
    "rellp", "renataq", "renektonq", "rengarq", "rivenw", "rumblep", "ryzep", "samirar", "sejuanir", "sennaw", "seraphineq", "settp", "shacop", "shenq", "shyvanaw", "singedq",
    "sionq", "sivire", "skarnere", "sonaq", "sorakae", "swainq", "sylasp", "syndrae", "tahmkenchw", "taliyahq", "talonq", "taricr", "teemoq", "threshr", "trundlep", "tryndameree",
    "twistedfatep", "twitchr", "udyrq", "urgotp", "varusr", "vaynep", "veigarr", "velkoze", "vexe", "vir", "viegop", "viktorr", "vladimirq", "volibearp", "warwickp", "wukongp",
    "xayahe", "xerathw", "xinzhaoq", "yasuow", "yonew", "yoricke", "yuumie", "zacq", "zede", "zeriw", "ziggsw", "zileanr", "zoee", "zyraw"};
    private int score = 0;
    private int streak = 0;
    private int bestStreak = 0;

    string selectedNameString;


    private string correctAnswer;

    public NewPage2()
    {
        InitializeComponent();
        ShowRandomImage();
        UpdateLabels();
        BindingContext = new MainPageViewModel();
    }

    public void ShowRandomImage()
    {
        // vyberte náhodnou schopnost z listu schopnosí
        var randomAbility = abilities[new Random().Next(abilities.Count)];

        // urèete název obrázku na základì náhodné schopnosti
        var imageName = $"{randomAbility}.png";

        // najdìte správnou odpovìï na základì názvu schopnosti
        correctAnswer = GetChampionNameByAbility(randomAbility);




        // najdìte ostatní náhodné odpovìdi z listu všech championù, kde správná odpovìï není obsažena
        var allChampions = new List<string> { "Aatrox", "Aurelion Sol", "Tristana", "Xin Zhao", "Alistar", "Akshan", "Akali", "Ahri", "Amumu", "Anivia", "Annie",
        "Aphelios", "Ashe", "Azir", "Bard", "Bel'Veth", "Blitzcrank", "Brand", "Braum", "Caitlyn", "Camille", "Cassiopeia", "Corki", "Darius", "Diana", "DrMundo", "Draven",
        "Ekko", "Elise", "Evelynn", "Ezreal", "FiddleSticks", "Fiora", "Fizz", "Galio", "Gangplank", "Garen", "Gnar", "Gragas", "Graves", "Gwen", "Hecarim", "Heimerdinger",
        "Illaoi", "Irelia", "Ivern", "Janna", "JarvanIV", "Jax", "Jayce", "Jhin", "Jinx", "K'Sante", "Kai'sa", "Kalista", "Karma", "Karthus", "Kassadin", "Katarina", "Kayle",
        "Kayn", "Kennen", "Kha'zix", "Kindred", "Kled", "Kog'Maw", "Leblanc", "Lee Sin", "Leona", "Lillia", "Lissandra", "Lucian", "Lulu", "Lux", "Malphite", "Malzahar", "Maokai",
        "MasterYi", "Milio", "Miss Fortune", "Mordekaiser", "Morgana", "Nami", "Nasus", "Nautilus", "Neeko", "Nidalee", "Nilah", "Nocturne", "Nunu & Willump", "Olaf", "Oriana",
        "Ornn", "Pantheon", "Poppy", "Pyke", "Qiyana", "Quinn", "Rakan", "Rammus", "Rek'Sai", "Rell", "Renata Glasc", "Renekton", "Rengar", "Riven", "Rumble", "Ryze", "Samira",
        "Sejuani", "Senna", "Seraphine", "Sett", "Shaco", "Shen", "Shyvana", "Singed", "Sion", "Sivir", "Skarner", "Sona", "Soraka", "Swain", "Sylas", "Syndra", "Tahm Kench",
        "Taliyah", "Talon", "Taric", "Teemo", "Thresh", "Trundle", "Tryndamere", "Twisted Fate", "Twitch", "Udyr", "Urgot", "Varus", "Vayne", "Veigar", "Vel'koz", "Vex", "Vi",
        "Viego", "Viktor", "Vladimir", "Volibear", "Warwick", "Wukong", "Xayah", "Xerath", "Xin Zhao", "Yasuo", "Yone", "Yorick", "Yuumi", "Zac", "Zed", "Zeri", "Ziggs", "Zilean", "Zoe", "Zyra"};
        allChampions.Remove(correctAnswer);






        // zobrazte obrázek a odpovìdi na obrazovce
        vobrazek.Source = ImageSource.FromFile($"{imageName}");


    }




    private string GetChampionNameByAbility(string ability)
    {

        switch (ability)
        {
            case "aatroxw":
                return "Aatrox";
            case "aurelionsolr":
                return "Aurelion Sol";
            case "tristanap":
                return "Tristana";
            case "xinzhaor":
                return "Xin Zhao";
            case "alistarq":
                return "Alistar";
            case "akshan_p":
                return "Akshan";
            case "akali_p":
                return "Akali";
            case "ahrir":
                return "Ahri";
            case "amumur":
                return "Amumu";
            case "aniviae":
                return "Anivia";
            case "anniep":
                return "Annie";
            case "apheliosw":
                return "Aphelios";
            case "ashee":
                return "Ashe";
            case "azirr":
                return "Azir";
            case "bardw":
                return "Bard";
            case "belvethw":
                return "Bel'Veth";
            case "blitzcrankw":
                return "Blitzcrank";
            case "brandp":
                return "Brand";
            case "braumr":
                return "Braum";
            case "caitlynr":
                return "Caitlyn";
            case "camillee":
                return "Camille";
            case "cassiopeiar":
                return "Cassiopeia";
            case "corki_p":
                return "Corki";
            case "dariusr":
                return "Darius";
            case "dianatel":
                return "Diana";
            case "drmundo_p":
                return "DrMundo";
            case "dravene":
                return "Draven";
            case "ekko_p":
                return "Ekko";
            case "elisehumanq":
                return "Elise";
            case "evelynne":
                return "Evelynn";
            case "ezrealp":
                return "Ezreal";
            case "fiddlesticksw":
                return "FiddleSticks";
            case "fiorap":
                return "Fiora";
            case "fizzw":
                return "Fizz";
            case "galior":
                return "Galio";
            case "gangplankw":
                return "Gangplank";
            case "garenw":
                return "Garen";
            case "gnare":
                return "Gnar";
            case "gragasp":
                return "Gragas";
            case "gravesq":
                return "Graves";
            case "gwenp":
                return "Gwen";
            case "hecarimp":
                return "Hecarim";
            case "heimerdingerw":
                return "Heimerdinger";
            case "illaoie":
                return "Illaoi";
            case "ireliae":
                return "Irelia";
            case "iverne":
                return "Ivern";
            case "jannap":
                return "Janna";
            case "jarvanivp":
                return "JarvanIV";
            case "jaxe":
                return "Jax";
            case "jaycep":
                return "Jayce";
            case "jhinw":
                return "Jhin";
            case "jinxw":
                return "Jinx";
            case "ksantee":
                return "K'Sante";
            case "kaisaw":
                return "Kai'sa";
            case "kalistar":
                return "Kalista";
            case "karmaw":
                return "Karma";
            case "karthusr":
                return "Karthus";
            case "kassadinp":
                return "Kassadin";
            case "katarinap":
                return "Katarina";
            case "kaylee":
                return "Kayle";
            case "kaynw":
                return "Kayn";
            case "kennenw":
                return "Kennen";
            case "khazixw":
                return "Kha'zix";
            case "kindredq":
                return "Kindred";
            case "kledq":
                return "Kled";
            case "kogmawe":
                return "Kog'Maw";
            case "leblancr":
                return "Leblanc";
            case "leesinr":
                return "Lee Sin";
            case "leonaq":
                return "Leona";
            case "lilliar":
                return "Lillia";
            case "lissandrar":
                return "Lissandra";
            case "lucianp":
                return "Lucian";
            case "lulur":
                return "Lulu";
            case "luxw":
                return "Lux";
            case "malphiteq":
                return "Malphite";
            case "malzaharq":
                return "Malzahar";
            case "maokaiq":
                return "Maokai";
            case "masteryip":
                return "MasterYi";
            case "miliop":
                return "Milio";
            case "missfortunee":
                return "Miss Fortune";
            case "mordekaiserp":
                return "Mordekaiser";
            case "morganae":
                return "Morgana";
            case "namiw":
                return "Nami";
            case "nasusp":
                return "Nasus";
            case "nautilusp":
                return "Nautilus";
            case "neekoe":
                return "Neeko";
            case "nidaleee":
                return "Nidalee";
            case "nilahp":
                return "Nilah";
            case "nocturnew":
                return "Nocturne";
            case "nunuwillumpp":
                return "Nunu & Willump";
            case "olafe":
                return "Olaf";
            case "orianaq":
                return "Oriana";
            case "ornnq":
                return "Ornn";
            case "pantheonq":
                return "Pantheon";
            case "poppyr":
                return "Poppy";
            case "pyker":
                return "Pyke";
            case "qiyanaq":
                return "Qiyana";
            case "quinne":
                return "Quinn";
            case "rakanq":
                return "Rakan";
            case "rammusr":
                return "Rammus";
            case "reksaip":
                return "Rek'Sai";
            case "rellp":
                return "Rell";
            case "renataq":
                return "Renata Glasc";
            case "renektonq":
                return "Renekton";
            case "rengarq":
                return "Rengar";
            case "rivenw":
                return "Riven";
            case "rumblep":
                return "Rumble";
            case "samirar":
                return "Samira";
            case "sejuanir":
                return "Sejuani";
            case "sennaw":
                return "Senna";
            case "seraphineq":
                return "Seraphine";
            case "settp":
                return "Sett";
            case "shacop":
                return "Shaco";
            case "shenq":
                return "Shen";
            case "shyvanaw":
                return "Shyvana";
            case "singedq":
                return "Singed";
            case "sionq":
                return "Sion";
            case "sivire":
                return "Sivir";
            case "skarnere":
                return "Skarner";
            case "sonaq":
                return "Sona";
            case "sorakae":
                return "Soraka";
            case "swainq":
                return "Swain";
            case "sylasp":
                return "Sylas";
            case "syndrae":
                return "Syndra";
            case "tahmkenchw":
                return "Tahm Kench";
            case "taliyahq":
                return "Taliyah";
            case "talonq":
                return "Talon";
            case "taricr":
                return "Taric";
            case "teemoq":
                return "Teemo";
            case "threshr":
                return "Thresh";
            case "trundlep":
                return "Trundle";
            case "tryndameree":
                return "Tryndamere";
            case "twistedfatep":
                return "Twisted Fate";
            case "twitchr":
                return "Twitch";
            case "udyrq":
                return "Udyr";
            case "urgotp":
                return "Urgot";
            case "varusr":
                return "Varus";
            case "vaynep":
                return "Vayne";
            case "veigarr":
                return "Veigar";
            case "velkoze":
                return "Vel'koz";
            case "vexe":
                return "Vex";
            case "vir":
                return "Vi";
            case "viegop":
                return "Viego";
            case "viktorr":
                return "Viktor";
            case "vladimirq":
                return "Vladimir";
            case "volibearp":
                return "Volibear";
            case "warwickp":
                return "Warwick";
            case "wukongp":
                return "Wukong";
            case "xayahe":
                return "Xayah";
            case "xerathw":
                return "Xerath";
            case "xinzhaoq":
                return "Xin Zhao";
            case "yasuow":
                return "Yasuo";
            case "yonew":
                return "yonew";
            case "yoricke":
                return "Yorick";
            case "yuumie":
                return "Yuumi";
            case "zacq":
                return "Zac";
            case "zede":
                return "Zed";
            case "zeriw":
                return "Zeri";
            case "ziggsw":
                return "Ziggs";
            case "zileanr":
                return "Zilean";
            case "zoee":
                return "Zoe";
            case "zyraw":
                return "Zyra";

            default:
                throw new Exception("Invalid ability name");
        }
    }
    public class NameModel
    {
        public string Name { get; set; }
    }
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<NameModel> Names { get; set; } = new ObservableCollection<NameModel>();

        private string searchQuery;
        public string SearchQuery
        {
            get { return searchQuery; }
            set
            {
                searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
                UpdateFilteredNames();
            }
        }

        private ObservableCollection<NameModel> filteredNames;
        public ObservableCollection<NameModel> FilteredNames
        {
            get { return filteredNames; }
            set
            {
                filteredNames = value;
                OnPropertyChanged(nameof(FilteredNames));
            }
        }

        public MainPageViewModel()
        {
            List<string> allChampions = new List<string> { "Aatrox", "Aurelion Sol", "Tristana", "Xin Zhao", "Alistar", "Akshan", "Akali", "Ahri", "Amumu", "Anivia", "Annie",
        "Aphelios", "Ashe", "Azir", "Bard", "Bel'Veth", "Blitzcrank", "Brand", "Braum", "Caitlyn", "Camille", "Cassiopeia", "Corki", "Darius", "Diana", "DrMundo", "Draven",
        "Ekko", "Elise", "Evelynn", "Ezreal", "FiddleSticks", "Fiora", "Fizz", "Galio", "Gangplank", "Garen", "Gnar", "Gragas", "Graves", "Gwen", "Hecarim", "Heimerdinger",
        "Illaoi", "Irelia", "Ivern", "Janna", "JarvanIV", "Jax", "Jayce", "Jhin", "Jinx", "K'Sante", "Kai'sa", "Kalista", "Karma", "Karthus", "Kassadin", "Katarina", "Kayle",
        "Kayn", "Kennen", "Kha'zix", "Kindred", "Kled", "Kog'Maw", "Leblanc", "Lee Sin", "Leona", "Lillia", "Lissandra", "Lucian", "Lulu", "Lux", "Malphite", "Malzahar", "Maokai",
        "MasterYi", "Milio", "Miss Fortune", "Mordekaiser", "Morgana", "Nami", "Nasus", "Nautilus", "Neeko", "Nidalee", "Nilah", "Nocturne", "Nunu & Willump", "Olaf", "Oriana",
        "Ornn", "Pantheon", "Poppy", "Pyke", "Qiyana", "Quinn", "Rakan", "Rammus", "Rek'Sai", "Rell", "Renata Glasc", "Renekton", "Rengar", "Riven", "Rumble", "Ryze", "Samira",
        "Sejuani", "Senna", "Seraphine", "Sett", "Shaco", "Shen", "Shyvana", "Singed", "Sion", "Sivir", "Skarner", "Sona", "Soraka", "Swain", "Sylas", "Syndra", "Tahm Kench",
        "Taliyah", "Talon", "Taric", "Teemo", "Thresh", "Trundle", "Tryndamere", "Twisted Fate", "Twitch", "Udyr", "Urgot", "Varus", "Vayne", "Veigar", "Vel'koz", "Vex", "Vi",
        "Viego", "Viktor", "Vladimir", "Volibear", "Warwick", "Wukong", "Xayah", "Xerath", "Xin Zhao", "Yasuo", "Yone", "Yorick", "Yuumi", "Zac", "Zed", "Zeri", "Ziggs", "Zilean", "Zoe", "Zyra"};
            foreach (var name in allChampions)
            {
                Names.Add(new NameModel { Name = name });
            }
            // Inicializace seznamu jmen


            // a další...

            // Zpoèátku zobrazíme všechna jména
            FilteredNames = Names;
        }

        private void UpdateFilteredNames()
        {
            // Aktualizace filtrovaných jmen na základì vstupního dotazu
            var filtered = Names.Where(n => n.Name.StartsWith(SearchQuery, StringComparison.OrdinalIgnoreCase));
            FilteredNames = new ObservableCollection<NameModel>(filtered);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {

        if (e.Item is NameModel selectedName)
        {
            selectedNameString = selectedName.Name;

        }


        // ovìøení správnosti odpovìdi
        if (selectedNameString == correctAnswer)
        {
            score++;
            streak++;
            if (streak > bestStreak)
            {
                bestStreak = streak;
            }
            UpdateLabels();
            ShowRandomImage();
            psani.Text = "";
        }
        else
        {
            score--;
            streak = 0;
            UpdateLabels();
        }
    }

    private void UpdateLabels()
    {
        skore.Text = $"Score: {score}";
        serie.Text = $"Streak: {streak}";
        streakk.Text = $"Best Streak: {bestStreak}";
    }
}
