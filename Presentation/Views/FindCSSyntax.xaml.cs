using System.Windows.Controls;

using VNCCodeCommandConsole.Presentation.ViewModels;

using VNC;
using VNC.Core.Mvvm;

namespace VNCCodeCommandConsole.Presentation.Views
{
    public partial class FindCSSyntax : UserControl, IView
    {
        #region Constructors and Load

        // View First.  
        // View is passed ViewModel through Injection
        // or can declare ViewModel in Xaml or Code

        // ViewModel First.  
        // ViewModel creates View 
        // and sets DataContext by setting ViewModel property

        public FindCSSyntax()
        {
            long startTicks = Log.Trace("Enter", Common.PROJECT_NAME);

            InitializeComponent();

            // If View First with ViewModel in Xaml
            // Expose ViewModel
            ViewModel = (IFindCSSyntaxViewModel)DataContext;

            // Can create directly
            // ViewModel = new FindVBSyntaxViewModel();

            InitializeView();

            Log.Trace("Exit", Common.PROJECT_NAME, startTicks);
        }

        public FindCSSyntax(IFindCSSyntaxViewModel viewModel)
        {
            long startTicks = Log.Trace("Enter", Common.PROJECT_NAME);

            InitializeComponent();

            ViewModel = viewModel;

            InitializeView();

            Log.Trace("Exit", Common.PROJECT_NAME, startTicks);
        }

        private void InitializeView()
        {
            // TODO(crhodes)
            // Perform any initialization or configuration of View

            //gcRows.ItemsSource = ((FindCSSyntaxViewModel)ViewModel).Rows1;
            //lgMain.IsCollapsed = true;
        }

        #endregion

        #region Properties

        private IViewModel _viewModel;

        public IViewModel ViewModel
        {
            get { return _viewModel; }

            set
            {
                _viewModel = value;
                DataContext = _viewModel;
                _viewModel.View = this;
            }
        }

        #endregion
    }
}
