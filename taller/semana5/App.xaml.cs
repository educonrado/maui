namespace econradoS5B
{
    public partial class App : Application
    {
        public static Models.PersonaRepository PersonaRepository { get; set; }  
        public App(Models.PersonaRepository personaRepository)
        {
            InitializeComponent();
            PersonaRepository = personaRepository;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vPrincipal()          );
        }
    }
}